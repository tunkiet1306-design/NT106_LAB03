using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai3_Client : Form
    {
        public Bai3_Client()
        {
            InitializeComponent();
        }

        TcpClient? tcpClient;
        NetworkStream? ns;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ipStr = textBox1.Text.Trim();
            string portStr = textBox2.Text.Trim();
            int port = 8080;

            // Tách IP và Port nếu người dùng nhập theo định dạng IP:Port ở ô IP
            if (ipStr.Contains(":"))
            {
                string[] parts = ipStr.Split(':');
                ipStr = parts[0];
                int.TryParse(parts[1], out port);
            }
            else
            {
                if (string.IsNullOrEmpty(portStr))
                {
                    MessageBox.Show("Vui lòng nhập Port!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }

                if (!int.TryParse(portStr, out port) || port < 1 || port > 65535)
                {
                    MessageBox.Show("Port không hợp lệ! Vui lòng nhập số nguyên từ 1 đến 65535 (VD: 8080).", "Lỗi định dạng Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(ipStr) || !IPAddress.TryParse(ipStr, out IPAddress? ipAddress))
            {
                MessageBox.Show("IP không hợp lệ! Vui lòng nhập định dạng IPv4 hợp lệ (VD: 127.0.0.1).", "Lỗi định dạng IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(ipAddress, port));
                ns = tcpClient.GetStream();
                MessageBox.Show($"Kết nối thành công tới {ipStr}:{port}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Không kết nối được: " + ex.Message +
                                "\nHãy kiểm tra xem Server đã Listen chưa và có nhập đúng Port đang hiển thị trên log Server không.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected || ns == null)
            {
                MessageBox.Show("Chưa kết nối tới Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = richTextBox1.Text;
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập message trước khi gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox1.Focus();
                return;
            }

            try
            {
                // Gửi tin nhắn tiếng Việt (UTF8)
                byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                ns.Write(data, 0, data.Length);

                // Ép gửi gói tin đi ngay lập tức tránh kẹt trong buffer
                ns.Flush();

                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (ns == null && tcpClient == null) return;

            try
            {
                if (ns != null && tcpClient != null && tcpClient.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes("quit\n");
                    ns.Write(data, 0, data.Length);
                    ns.Flush(); // Ép gửi nốt lệnh quit trước khi đóng
                }
            }
            catch { }
            finally
            {
                ns?.Close();
                tcpClient?.Close();
                ns = null;
                tcpClient = null;
                MessageBox.Show("Đã ngắt kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                if (ns != null && tcpClient != null && tcpClient.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes("quit\n");
                    ns.Write(data, 0, data.Length);
                    ns.Flush();
                }
            }
            catch { }
            finally
            {
                ns?.Close();
                tcpClient?.Close();
                ns = null;
                tcpClient = null;
            }
        }
    }
}
