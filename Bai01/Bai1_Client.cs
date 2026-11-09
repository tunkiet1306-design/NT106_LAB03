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

        private void button1_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPRemoteHost.Text.Trim();
            string portText = txtPort.Text.Trim();
            string message = rtbMessages.Text;

            // 1. Kiểm tra định dạng IP Remote Host (Phục vụ TC_01_06)
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

            // 2. Kiểm tra định dạng Port (Phục vụ TC_01_05)
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

            // 3. Mã hóa UTF-8 và gửi gói tin qua UDP (Phục vụ TC_01_01 -> TC_01_04)
            try
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    // Mã hóa dữ liệu chuỗi thành mảng byte với chuẩn UTF8 (hỗ trợ tiếng Việt có dấu)
                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);

                    // Gửi dữ liệu đi qua UDP mà không cần thiết lập kết nối trước
                    udpClient.Send(sendBytes, sendBytes.Length, ipAddress, port);
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(
                    $"Không thể gửi gói tin UDP đến {ipAddress}:{port}!\nChi tiết lỗi: {ex.Message}",
                    "Lỗi kết nối UDP (SocketException)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi khi gửi dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private bool KiemTraIPv4HopLe(string input)
        {
            if (input.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            string[] parts = input.Split('.');
            if (parts.Length != 4)
            {
                return false;
            }

            return IPAddress.TryParse(input, out IPAddress ip) &&
                   ip.AddressFamily == AddressFamily.InterNetwork;
        }
    }
}
