using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai5_Client : Form
    {
        private Socket clientSocket;
        private Thread receiveThread;
        private bool isConnected = false;
        private static readonly HttpClient httpClient = new HttpClient();

        public Bai5_Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                Disconnect();
                return;
            }

            if (!IPAddress.TryParse(txtServerIP.Text.Trim(), out IPAddress serverIp))
            {
                MessageBox.Show("Địa chỉ IP không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtPort.Text.Trim(), out int port))
            {
                MessageBox.Show("Cổng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(serverIp, port);
                clientSocket.Connect(ep);

                isConnected = true;
                btnConnect.Text = "Ngắt kết nối";
                txtServerIP.Enabled = false;
                txtPort.Enabled = false;
                btnAddFood.Enabled = true;
                btnRandomAll.Enabled = true;
                btnRandomUser.Enabled = true;
                btnRefreshList.Enabled = true;

                receiveThread = new Thread(ReceiveLoop);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                // Lấy danh sách món ăn ngay khi vừa kết nối
                SendRequest("GET_ALL");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến Server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveLoop()
        {
            byte[] buffer = new byte[8192];
            try
            {
                while (isConnected && clientSocket != null && clientSocket.Connected)
                {
                    int bytesReceived = clientSocket.Receive(buffer);
                    if (bytesReceived == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    HandleServerResponse(message);
                }
            }
            catch
            {
            }
            finally
            {
                if (isConnected)
                {
                    this.Invoke(new Action(Disconnect));
                }
            }
        }

        private void HandleServerResponse(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(HandleServerResponse), message);
                return;
            }

            string[] parts = message.Split('|');
            string status = parts[0];

            if (status == "LIST")
            {
                lvMonAn.Items.Clear();
                if (parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]))
                {
                    string[] items = parts[1].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in items)
                    {
                        string[] itemParts = item.Split(';');
                        if (itemParts.Length >= 4)
                        {
                            ListViewItem lvi = new ListViewItem(itemParts[0]); // ID
                            lvi.SubItems.Add(itemParts[1]); // TenMonAn
                            lvi.SubItems.Add(itemParts[3]); // NguoiDongGop (HoVaTen)
                            lvMonAn.Items.Add(lvi);
                        }
                    }
                }
            }
            else if (status == "ADD_SUCCESS")
            {
                MessageBox.Show(parts.Length > 1 ? parts[1] : "Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFoodName.Clear();
                txtImageUrl.Clear();
                SendRequest("GET_ALL"); // Làm mới danh sách sau khi thêm
            }
            else if (status == "RESULT" && parts.Length >= 4)
            {
                lblResultFood.Text = parts[1];
                lblResultContributor.Text = $"Người đóng góp: {parts[3]}";
                LoadImageFromUrl(parts[2]);
            }
            else if (status == "ERROR")
            {
                MessageBox.Show(parts.Length > 1 ? parts[1] : "Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void LoadImageFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                picFood.Image = null;
                return;
            }

            try
            {
                byte[] imageBytes = await httpClient.GetByteArrayAsync(url.Trim());
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    picFood.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            catch
            {
                picFood.Image = null;
            }
        }

        private void SendRequest(string command)
        {
            if (!isConnected || clientSocket == null || !clientSocket.Connected)
            {
                MessageBox.Show("Chưa kết nối đến Server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(command);
                clientSocket.Send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Disconnect();
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string foodName = txtFoodName.Text.Trim();
            string imageUrl = txtImageUrl.Text.Trim();
            string user = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên người đóng góp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(foodName))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFoodName.Focus();
                return;
            }

            string request = $"ADD|{foodName}|{imageUrl}|{user}";
            SendRequest(request);
        }

        private void btnRandomAll_Click(object sender, EventArgs e)
        {
            SendRequest("RANDOM_ALL");
        }

        private void btnRandomUser_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên để lọc món ăn của bạn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            SendRequest($"RANDOM_USER|{user}");
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            SendRequest("GET_ALL");
        }

        private void Disconnect()
        {
            isConnected = false;
            try
            {
                if (clientSocket != null)
                {
                    clientSocket.Close();
                }
            }
            catch
            {
            }

            btnConnect.Text = "Kết nối";
            txtServerIP.Enabled = true;
            txtPort.Enabled = true;
            btnAddFood.Enabled = false;
            btnRandomAll.Enabled = false;
            btnRandomUser.Enabled = false;
            btnRefreshList.Enabled = false;
        }

        private void Bai5_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
    }
}