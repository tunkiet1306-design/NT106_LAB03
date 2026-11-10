using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai1_Client : Form
    {
        public Bai1_Client()
        {
            InitializeComponent();
        }

        private bool KiemTraIPv4HopLe(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Cho phép nhập "localhost" để tiện kiểm thử trên cùng máy
            if (input.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Đảm bảo địa chỉ có đúng 4 octet phân tách bằng dấu chấm (ví dụ: 192.168.1.1)
            string[] parts = input.Split('.');
            if (parts.Length != 4)
            {
                return false;
            }

            // Kiểm tra tính hợp lệ và xác định đúng chuẩn IPv4 (InterNetwork)
            return IPAddress.TryParse(input, out IPAddress ip) &&
                   ip.AddressFamily == AddressFamily.InterNetwork;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPRemoteHost.Text.Trim();
            string portText = txtPort.Text.Trim();
            string message = rtbMessages.Text;

            // 1. Kiểm tra định dạng IP Remote Host
            if (string.IsNullOrEmpty(ipAddress) || !KiemTraIPv4HopLe(ipAddress))
            {
                MessageBox.Show(
                    "Địa chỉ IP Remote Host không hợp lệ!\nVui lòng nhập đúng định dạng IPv4 (ví dụ: 127.0.0.1).",
                    "Lỗi định dạng IP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtIPRemoteHost.Focus();
                return;
            }

            // 2. Kiểm tra định dạng Port
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

            // 3. Gửi UDP và chờ phản hồi kiểm tra Port
            try
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    // Cài đặt thời gian chờ tối đa là 2 giây (2000 ms)
                    udpClient.Client.ReceiveTimeout = 2000;

                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);

                    // Gửi dữ liệu đi
                    udpClient.Send(sendBytes, sendBytes.Length, ipAddress, port);

                    // Chờ phản hồi ACK từ Server
                    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] ackBytes = udpClient.Receive(ref serverEndPoint);
                    string ackMessage = Encoding.UTF8.GetString(ackBytes);

                    if (ackMessage == "ACK")
                    {
                        MessageBox.Show(
                            "Đã gửi dữ liệu thành công đến Server!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (SocketException ex)
            {
                // Khi sai Port hoặc Server chưa bật:
                // - Quá hạn 2 giây: SocketErrorCode == TimedOut (10060)
                // - Hoặc bị hệ điều hành từ chối: SocketErrorCode == ConnectionReset (10054)
                if (ex.SocketErrorCode == SocketError.TimedOut ||
                    ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    MessageBox.Show(
                        $"Không nhận được phản hồi từ Server tại {ipAddress}:{port}!\n\n" +
                        "Nguyên nhân khả dĩ:\n" +
                        "- Server đang mở cổng khác với cổng Client nhập.\n" +
                        "- Server chưa bấm Listen hoặc chưa khởi động.\n" +
                        "- Tường lửa (Firewall) đang chặn gói tin UDP.",
                        "Lỗi kết nối / Sai Port",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(
                        $"Lỗi Socket: {ex.Message} (Mã lỗi: {ex.SocketErrorCode})",
                        "Lỗi SocketException",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
