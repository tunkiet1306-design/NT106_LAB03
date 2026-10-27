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
        private Socket? clientSocket;

        public Bai2()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // Cho phép luồng ngầm cập nhật giao diện ListView
            CheckForIllegalCrossThreadCalls = false;

            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.IsBackground = true;
            serverThread.Start();

            btnListen.Enabled = false;
            listViewCommand.Items.Add(new ListViewItem("Telnet running on port 8080..."));
        }

        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];

            listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            // Dùng IPAddress.Any để nhận được cả Localhost (127.0.0.1) và mạng LAN (192.168.x.x)
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Any, 8081);

            try
            {
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(-1);

                clientSocket = listenerSocket.Accept();
                listViewCommand.Items.Add(new ListViewItem("New client connected"));

                while (clientSocket.Connected)
                {
                    string text = "";
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        if (bytesReceived == 0) break;
                        text += Encoding.ASCII.GetString(recv);
                    } while (text[text.Length - 1] != '\n');

                    if (bytesReceived == 0) break;

                    listViewCommand.Items.Add(new ListViewItem(text.TrimEnd('\r', '\n')));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listenerSocket?.Close();
            }
        }
    }
}