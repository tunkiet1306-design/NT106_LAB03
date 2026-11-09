using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace LAB03
{
    public partial class Bai1_Server : Form
    {
        private readonly List<UdpClient> _danhSachServerDangChay = new List<UdpClient>();
        private bool _dangDongForm = false;
        public Bai1_Server()
        {
            InitializeComponent();
            this.FormClosing += Bai1_Server_FormClosing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string portText = txtPort.Text.Trim();

            // 1. Kiểm tra định dạng Port (Phục vụ TC_01_05)
            if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show(
                    "Port không hợp lệ!\nVui lòng nhập số nguyên trong khoảng từ 1 đến 65535 (ví dụ: 8080).",
                    "Lỗi định dạng Port",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPort.Focus();
                return;
            }

            // 2. Khởi tạo UdpClient gắn vào cổng Port (Phục vụ TC_01_07 khi bấm Listen 2 lần cùng Port)
            try
            {
                // Nếu cổng này đã được Listen trước đó, lệnh new UdpClient(port) sẽ lập tức ném SocketException
                UdpClient udpServer = new UdpClient(port);
                _danhSachServerDangChay.Add(udpServer);

                Thread serverThread = new Thread(() => StartListening(udpServer))
                {
                    IsBackground = true
                };
                serverThread.Start();

                UpdateUI($"[Hệ thống] Đang lắng nghe UDP tại cổng {port}...");
            }
            catch (SocketException ex)
            {
                // Bắt lỗi trùng cổng (Address already in use) khi nhấn Listen lần 2 trên cùng 1 Port
                MessageBox.Show(
                    $"Không thể lắng nghe trên cổng {port}!\nCổng này đã được mở hoặc đang bị chiếm dụng.\n\nChi tiết: {ex.Message}",
                    "Lỗi xung đột cổng (SocketException)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi khởi động UDP Server: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void StartListening(UdpClient udpClient)
        {
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (!_dangDongForm)
                {
                    // Nhận dữ liệu từ Client
                    byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);

                    // Giải mã chuẩn UTF8 hỗ trợ tiếng Việt có dấu
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    string message = $"{remoteIpEndPoint.Address}:{returnData}";

                    UpdateUI(message);
                }
            }
            catch (SocketException)
            {
                // Khi đóng Form, udpClient.Close() được gọi sẽ thoát vòng lặp Receive tại đây
            }
            catch (ObjectDisposedException)
            {
                // Bỏ qua khi Socket đã được giải phóng lúc đóng Form
            }
        }
        private void UpdateUI(string message)
        {
            if (this.IsDisposed || rtbReceivedMessages.IsDisposed)
            {
                return;
            }

            // Thread-safe call với InvokeRequired để tránh lỗi InvalidOperationException
            if (rtbReceivedMessages.InvokeRequired)
            {
                rtbReceivedMessages.Invoke(new MethodInvoker(delegate
                {
                    rtbReceivedMessages.AppendText(message + Environment.NewLine);
                }));
            }
            else
            {
                rtbReceivedMessages.AppendText(message + Environment.NewLine);
            }
        }
        private void Bai1_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dangDongForm = true;
            foreach (UdpClient server in _danhSachServerDangChay)
            {
                try
                {
                    server.Close();
                }
                catch
                {
                }
            }
            _danhSachServerDangChay.Clear();
        }
    }
}
