using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai2_Client : Form
    {
        private Socket? tcpClient;

        public Bai2_Client()
        {
            InitializeComponent();
        }

        private void AddClientLog(string msg)
        {
            if (IsDisposed || !IsHandleCreated) return;

            if (lstClientLog.InvokeRequired)
            {
                lstClientLog.BeginInvoke(new Action(() => AddClientLog(msg)));
                return;
            }

            string time = DateTime.Now.ToString("HH:mm:ss");
            lstClientLog.Items.Add($"[{time}] {msg}");
            lstClientLog.TopIndex = lstClientLog.Items.Count - 1;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtServerIP.Text.Trim();
            if (!IPAddress.TryParse(ip, out IPAddress? ipAddress))
            {
                MessageBox.Show("Địa chỉ IP Server không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPort.Text.Trim(), out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Cổng Port không hợp lệ (1 - 65535)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint serverEP = new IPEndPoint(ipAddress, port);

                tcpClient.Connect(serverEP);

                AddClientLog($"Đã kết nối thành công tới {ip}:{port}");

                txtServerIP.Enabled = false;
                txtPort.Enabled = false;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                txtMessage.Enabled = true;
                btnSend.Enabled = true;
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối tới Server: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try { tcpClient?.Close(); } catch { }
                tcpClient = null;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
            AddClientLog("Đã ngắt kết nối khỏi Server.");
        }

        private void DisconnectFromServer()
        {
            try
            {
                if (tcpClient != null)
                {
                    if (tcpClient.Connected)
                    {
                        tcpClient.Shutdown(SocketShutdown.Both);
                    }
                    tcpClient.Close();
                }
            }
            catch { }
            finally
            {
                tcpClient = null;
                txtServerIP.Enabled = true;
                txtPort.Enabled = true;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                txtMessage.Enabled = false;
                btnSend.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                MessageBox.Show("Chưa kết nối tới Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DisconnectFromServer();
                return;
            }

            string msg = txtMessage.Text;
            if (string.IsNullOrEmpty(msg)) return;

            try
            {
                // Gửi kèm ký tự xuống dòng '\n' theo chuẩn dòng lệnh Telnet
                byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                tcpClient.Send(data);

                AddClientLog($"Đã gửi: {msg}");
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisconnectFromServer();
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            Bai2_Client newClient = new Bai2_Client();
            newClient.Show();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lstClientLog.Items.Clear();
        }

        private void Bai2_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFromServer();
        }
    }
}

