using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LAB03
{
    public partial class Bai5_Server : Form
    {
        private Socket listenerSocket;
        private Thread listenThread;
        private bool isListening = false;
        private readonly string connectionString = "Server=localhost;Database=Lab03_Bai05;Trusted_Connection=True;TrustServerCertificate=True;";

        public Bai5_Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text.Trim(), out int port))
            {
                MessageBox.Show("Cổng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
                listenerSocket.Bind(ep);
                listenerSocket.Listen(10);

                isListening = true;
                btnListen.Enabled = false;
                txtPort.Enabled = false;

                listenThread = new Thread(ListenLoop);
                listenThread.IsBackground = true;
                listenThread.Start();

                LogMessage($"[Hệ thống] Server đang lắng nghe tại cổng {port}...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động Server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenLoop()
        {
            while (isListening)
            {
                try
                {
                    Socket clientSocket = listenerSocket.Accept();
                    string clientEp = clientSocket.RemoteEndPoint.ToString();
                    LogMessage($"[Kết nối] Client {clientEp} đã kết nối.");

                    Thread clientThread = new Thread(() => HandleClient(clientSocket, clientEp));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch
                {
                    break;
                }
            }
        }

        private void HandleClient(Socket clientSocket, string clientEp)
        {
            byte[] buffer = new byte[8192];
            try
            {
                while (isListening && clientSocket.Connected)
                {
                    int bytesReceived = clientSocket.Receive(buffer);
                    if (bytesReceived == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    LogMessage($"[Nhận từ {clientEp}] {request}");

                    string response = ProcessRequest(request);

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    clientSocket.Send(responseBytes);
                    LogMessage($"[Gửi tới {clientEp}] {response.Substring(0, Math.Min(response.Length, 60))}...");
                }
            }
            catch
            {
            }
            finally
            {
                clientSocket.Close();
                LogMessage($"[Ngắt kết nối] Client {clientEp} đã rời đi.");
            }
        }

        private string ProcessRequest(string request)
        {
            string[] parts = request.Split('|');
            string command = parts[0];

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (command == "GET_ALL")
                    {
                        string query = "SELECT m.IDMA, m.TenMonAn, m.HinhAnh, nd.HoVaTen " +
                                       "FROM MonAn m JOIN NguoiDung nd ON m.IDNCC = nd.IDNCC";
                        StringBuilder sb = new StringBuilder("LIST|");
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sb.Append($"{reader["IDMA"]};{reader["TenMonAn"]};{reader["HinhAnh"]};{reader["HoVaTen"]}#");
                            }
                        }
                        return sb.ToString();
                    }
                    else if (command == "ADD" && parts.Length >= 4)
                    {
                        string tenMon = parts[1];
                        string hinhAnh = parts[2];
                        string hoVaTen = parts[3];

                        int idncc;
                        string findUserQuery = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @HoVaTen";
                        using (SqlCommand cmd = new SqlCommand(findUserQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@HoVaTen", hoVaTen);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                idncc = (int)result;
                            }
                            else
                            {
                                string insertUserQuery = "INSERT INTO NguoiDung (HoVaTen, QuyenHan) OUTPUT INSERTED.IDNCC VALUES (@HoVaTen, N'User')";
                                using (SqlCommand insertCmd = new SqlCommand(insertUserQuery, conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@HoVaTen", hoVaTen);
                                    idncc = (int)insertCmd.ExecuteScalar();
                                }
                            }
                        }

                        string insertFoodQuery = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@Ten, @Hinh, @IDNCC)";
                        using (SqlCommand cmd = new SqlCommand(insertFoodQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ten", tenMon);
                            cmd.Parameters.AddWithValue("@Hinh", hinhAnh);
                            cmd.Parameters.AddWithValue("@IDNCC", idncc);
                            cmd.ExecuteNonQuery();
                        }
                        return "ADD_SUCCESS|Thêm món ăn thành công.";
                    }
                    else if (command == "RANDOM_ALL")
                    {
                        string query = "SELECT TOP 1 m.TenMonAn, m.HinhAnh, nd.HoVaTen " +
                                       "FROM MonAn m JOIN NguoiDung nd ON m.IDNCC = nd.IDNCC ORDER BY NEWID()";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return $"RESULT|{reader["TenMonAn"]}|{reader["HinhAnh"]}|{reader["HoVaTen"]}";
                            }
                        }
                        return "ERROR|Chưa có món ăn nào trong hệ thống.";
                    }
                    else if (command == "RANDOM_USER" && parts.Length >= 2)
                    {
                        string user = parts[1];
                        string query = "SELECT TOP 1 m.TenMonAn, m.HinhAnh, nd.HoVaTen " +
                                       "FROM MonAn m JOIN NguoiDung nd ON m.IDNCC = nd.IDNCC " +
                                       "WHERE nd.HoVaTen = @User ORDER BY NEWID()";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@User", user);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return $"RESULT|{reader["TenMonAn"]}|{reader["HinhAnh"]}|{reader["HoVaTen"]}";
                                }
                            }
                        }
                        return $"ERROR|Không tìm thấy món ăn nào do '{user}' đóng góp.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"ERROR|Lỗi CSDL: {ex.Message}";
            }

            return "ERROR|Yêu cầu không hợp lệ.";
        }

        private void LogMessage(string message)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action<string>(LogMessage), message);
                return;
            }

            string time = DateTime.Now.ToString("HH:mm:ss");
            rtbLog.AppendText($"[{time}] {message}\r\n");
            rtbLog.ScrollToCaret();
        }

        private void Bai5_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            isListening = false;
            try
            {
                if (listenerSocket != null)
                {
                    listenerSocket.Close();
                }
            }
            catch
            {
            }
        }
    }
}