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
            if (!IPAddress.TryParse(textBox1.Text.Trim(), out IPAddress ipAddress))
            {
                MessageBox.Show("IP không hợp lệ! Ví dụ: 127.0.0.1");
                return;
            }

            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(ipAddress, 8080));
                ns = tcpClient.GetStream();
                MessageBox.Show("Kết nối thành công!");
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Không kết nối được: " + ex.Message +
                                "\nHãy kiểm tra Server đã bấm Listen chưa, IP/port và Firewall.");
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