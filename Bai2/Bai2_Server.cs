using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai2_Server : Form
    {
        private Socket? listenerSocket;
        private bool isServerRunning = false;
        private readonly List<Socket> clientSockets = new List<Socket>();

        public Bai2_Server()
        {
            InitializeComponent();
        }

        private void Bai2_Server_Load(object sender, EventArgs e)
        {
            string localIP = GetLocalIPv4();
            lblLanIP.Text = $"IP LAN: {localIP}";
        }

        private string GetLocalIPv4()
        {
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            catch { }
            return "127.0.0.1";
        }

        private void AddServerLog(string msg)
        {
            if (IsDisposed || !IsHandleCreated) return;

            if (listViewCommand.InvokeRequired)
            {
                listViewCommand.BeginInvoke(new Action(() => AddServerLog(msg)));
                return;
            }

            ListViewItem item = new ListViewItem(msg);
            listViewCommand.Items.Add(item);
            listViewCommand.EnsureVisible(item.Index);
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text.Trim(), out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Vui lòng nhập số Port hợp lệ (1 - 65535)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Any, port);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(50);
                isServerRunning = true;

                btnListen.Enabled = false;
                txtPort.Enabled = false;
                lblStatus.Text = $"Đang lắng nghe trên cổng {port}...";
                lblStatus.ForeColor = System.Drawing.Color.Green;

                AddServerLog($"Telnet running on port {port}...");

                Thread serverThread = new Thread(AcceptClients);
                serverThread.IsBackground = true;
                serverThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể lắng nghe trên cổng {port}.\nChi tiết: {ex.Message}", "Lỗi khởi động Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AcceptClients()
        {
            try
            {
                while (isServerRunning && listenerSocket != null)
                {
                    Socket clientSocket = listenerSocket.Accept();
                    lock (clientSockets)
                    {
                        clientSockets.Add(clientSocket);
                    }

                    string clientInfo = clientSocket.RemoteEndPoint?.ToString() ?? "Unknown";
                    AddServerLog($"New client connected: {clientInfo}");

                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch
            {
                // listenerSocket bị đóng khi tắt Form hoặc dừng server
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            string clientInfo = clientSocket.RemoteEndPoint?.ToString() ?? "Client";
            byte[] recv = new byte[1];

            try
            {
                while (isServerRunning && clientSocket.Connected)
                {
                    string text = "";
                    int bytesReceived = 0;

                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        if (bytesReceived == 0) break;
                        text += Encoding.UTF8.GetString(recv);
                    } while (text.Length > 0 && text[text.Length - 1] != '\n');

                    if (bytesReceived == 0 && string.IsNullOrEmpty(text))
                    {
                        break;
                    }

                    string cleanMessage = text.TrimEnd('\r', '\n');
                    if (!string.IsNullOrEmpty(cleanMessage))
                    {
                        AddServerLog(cleanMessage);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                AddServerLog($"Client disconnected: {clientInfo}");
                lock (clientSockets)
                {
                    clientSockets.Remove(clientSocket);
                }
                try { clientSocket.Close(); } catch { }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listViewCommand.Items.Clear();
        }

        private void Bai2_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            isServerRunning = false;

            lock (clientSockets)
            {
                foreach (var socket in clientSockets)
                {
                    try { socket.Close(); } catch { }
                }
                clientSockets.Clear();
            }

            try
            {
                listenerSocket?.Close();
            }
            catch { }
        }
    }
}

