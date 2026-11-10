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

        TcpClient tcpClient;
        NetworkStream ns;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            string ipStr = input;
            int port = 8080; // Port mặc định

            // Tách IP và Port nếu người dùng nhập theo định dạng IP:Port
            if (input.Contains(":"))
            {
                string[] parts = input.Split(':');
                ipStr = parts[0];
                int.TryParse(parts[1], out port);
            }

            if (!IPAddress.TryParse(ipStr, out IPAddress ipAddress))
            {
                MessageBox.Show("IP không hợp lệ! Vui lòng nhập định dạng IP hoặc IP:Port (VD: 127.0.0.1 hoặc 127.0.0.1:50443)");
                return;
            }

            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(ipAddress, port));
                ns = tcpClient.GetStream();
                MessageBox.Show($"Kết nối thành công tới {ipStr}:{port}!");
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Không kết nối được: " + ex.Message +
                                "\nHãy kiểm tra xem Server đã Listen chưa và có nhập đúng Port đang hiển thị trên log Server không.");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ns == null)
            {
                MessageBox.Show("Chưa kết nối tới Server!");
                return;
            }

            try
            {
                // Gửi tin nhắn tiếng Việt (UTF8)
                byte[] data = Encoding.UTF8.GetBytes(textBox2.Text + "\n");
                ns.Write(data, 0, data.Length);

                // THÊM MỚI: Ép gửi gói tin đi ngay lập tức tránh kẹt trong buffer
                ns.Flush();

                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi thất bại: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (ns == null) return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes("quit\n");
                ns.Write(data, 0, data.Length);
                ns.Flush(); // Ép gửi nốt lệnh quit trước khi đóng
            }
            catch { }
            finally
            {
                ns?.Close();
                tcpClient?.Close();
                ns = null;
                MessageBox.Show("Đã ngắt kết nối!");
            }
        }
    }
}