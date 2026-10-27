using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai2 : Form
    {
        private Socket? listenerSocket;
        private bool isServerRunning = false;
        private Socket? tcpClient;

        public Bai2()
        {
            InitializeComponent();
        }

        // Hàm ép giao diện ListView phải hiện chữ ngay lập tức từ mọi Thread
        private void AddServerLog(string msg)
        {
            if (listViewCommand.InvokeRequired)
            {
                listViewCommand.Invoke(new Action(() => listViewCommand.Items.Add(new ListViewItem(msg))));
            }
            else
            {
                listViewCommand.Items.Add(new ListViewItem(msg));
            }
        }

        // =========================================================
        // PHẦN 1: TCP SERVER
        // =========================================================
        private void btnListen_Click(object sender, EventArgs e)
        {
            int port = int.Parse(txtPort.Text.Trim());

            try
            {
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                // Khóa độc quyền cổng để không bị dịch vụ Windows cướp kết nối
                listenerSocket.ExclusiveAddressUse = true;

                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Any, port);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(10);
                isServerRunning = true;

                btnListen.Enabled = false;
                AddServerLog($"Telnet running on port {port}...");

                Thread serverThread = new Thread(AcceptClients);
                serverThread.IsBackground = true;
                serverThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cổng {port} đang bị phần mềm khác chiếm! Hãy đổi số ở ô Port sang 8081 rồi bấm Listen lại.\nChi tiết: {ex.Message}");
            }
        }

        void AcceptClients()
        {
            try
            {
                while (isServerRunning && listenerSocket != null)
                {
                    Socket clientSocket = listenerSocket.Accept();
                    AddServerLog($"New client connected: {clientSocket.RemoteEndPoint}");

                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch
            {
                // Đóng form
            }
        }

        void HandleClient(Socket clientSocket)
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];

            try
            {
                while (clientSocket.Connected)
                {
                    string text = "";
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        if (bytesReceived == 0) break;
                        text += Encoding.UTF8.GetString(recv);
                    } while (text[text.Length - 1] != '\n');

                    if (bytesReceived == 0) break;

                    string cleanMessage = text.TrimEnd('\r', '\n');
                    AddServerLog(cleanMessage);
                }
            }
            catch
            {
            }
            finally
            {
                AddServerLog("Client disconnected");
                clientSocket.Close();
            }
        }

        // =========================================================
        // PHẦN 2: TCP CLIENT
        // =========================================================
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtServerIP.Text.Trim();
                int port = int.Parse(txtPort.Text.Trim());

                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(ip), port);

                tcpClient.Connect(serverEP);

                lstClientLog.Items.Add($"Đã kết nối tới Server {ip}:{port}");
                btnConnect.Enabled = false;
                txtMessage.Enabled = true;
                btnSend.Enabled = true;
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới Server: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected) return;

            string msg = txtMessage.Text;
            if (string.IsNullOrEmpty(msg)) return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                tcpClient.Send(data);

                lstClientLog.Items.Add("Đã gửi: " + msg);
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi: " + ex.Message);
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

        private void btnOpenNewWindow_Click(object sender, EventArgs e)
        {
            Bai2 newForm = new Bai2();
            newForm.Show();
        }

        private void Bai2_FormClosing(object sender, FormClosingEventArgs e)
        {
            isServerRunning = false;
            try { tcpClient?.Close(); } catch { }
            try { listenerSocket?.Close(); } catch { }
        }
    }
}