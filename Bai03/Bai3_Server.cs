using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai3_Server : Form
    {
        public Bai3_Server()
        {
            InitializeComponent();

            // Hiển thị dạng hàng, mỗi tin nhắn 1 dòng
            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.Add("Log", listView1.ClientSize.Width - 4);

            // Cột tự co giãn theo kích thước ListView
            listView1.Resize += (s, e) =>
            {
                if (listView1.Columns.Count > 0)
                    listView1.Columns[0].Width = listView1.ClientSize.Width - 4;
            };
        }

        Socket listenerSocket;
        bool isListening = false;

        void AddLog(string msg)
        {
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(new MethodInvoker(() => AddLog(msg)));
                return;
            }
            listView1.Items.Add(msg);
            listView1.Items[listView1.Items.Count - 1].EnsureVisible(); // tự cuộn xuống dòng mới nhất
        }

        void StartUnsafeThread()
        {
            Socket clientSocket = null;
            try
            {
                // 1. Tạo Socket TCP
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Xử lý cấp phát Port động an toàn
                try
                {
                    listenerSocket.Bind(new IPEndPoint(IPAddress.Any, 8080));
                }
                catch (SocketException)
                {
                    // Nếu lỗi (bị chiếm port), hủy socket lỗi và tạo socket mới yêu cầu OS cấp port bất kỳ (Port 0)
                    listenerSocket.Close();
                    listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    listenerSocket.Bind(new IPEndPoint(IPAddress.Any, 0));
                }

                // Lấy port thực tế đang được sử dụng
                int actualPort = ((IPEndPoint)listenerSocket.LocalEndPoint).Port;

                // 2. Lắng nghe
                listenerSocket.Listen(10);
                AddLog($"Server started! Đang lắng nghe trên cổng: {actualPort}");

                // 3. Chấp nhận kết nối liên tục bằng vòng lặp while
                while (isListening)
                {
                    clientSocket = listenerSocket.Accept();
                    AddLog("Đã kết nối với: " + clientSocket.RemoteEndPoint);

                    // 4. Nhận dữ liệu liên tục từ Client hiện tại
                    byte[] recv = new byte[1024];
                    while (true)
                    {
                        int bytesReceived = clientSocket.Receive(recv);
                        if (bytesReceived == 0) break;   // Client ngắt kết nối

                        string text = Encoding.UTF8.GetString(recv, 0, bytesReceived).Trim();
                        AddLog("Client: " + text);

                        if (text == "quit") break;
                    }

                    // Client hiện tại ngắt kết nối, đóng socket để chuẩn bị đón Client mới
                    clientSocket?.Close();
                    AddLog("Client đã ngắt kết nối. Đang chờ Client mới...");
                }
            }
            catch (SocketException ex)
            {
                // Bỏ qua lỗi nếu lỗi phát sinh do người dùng tắt server (hủy listening)
                if (isListening)
                {
                    AddLog("Lỗi socket: " + ex.Message);
                }
            }
            catch (ObjectDisposedException) { }   // form hoặc socket đã đóng
            finally
            {
                clientSocket?.Close();
                listenerSocket?.Close();
                isListening = false;
                AddLog("Server đã dừng.");
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                MessageBox.Show("Server đang chạy rồi!");
                return;
            }
            isListening = true;

            Thread serverThread = new Thread(StartUnsafeThread);
            serverThread.IsBackground = true;
            serverThread.Start();
        }
    }
}