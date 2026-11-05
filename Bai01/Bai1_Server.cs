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
        public Bai1_Server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(new ThreadStart(StartListening));
            serverThread.IsBackground = true;
            serverThread.Start();

        }

        private void StartListening()
        {
            int port = int.Parse(txtPort.Text);
            UdpClient udpClient = new UdpClient(port);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                // Nhận dữ liệu
                Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                // Hỗ trợ tiếng Việt có dấu (UTF8)
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string message = $"{remoteIpEndPoint.Address}:{returnData}";

                UpdateUI(message);
            }
        }
        private void UpdateUI(string message)
        {
            // Thread-safe call để tránh lỗi InvalidOperationException
            if (rtbReceivedMessages.InvokeRequired)
            {
                rtbReceivedMessages.Invoke(new MethodInvoker(delegate {
                    rtbReceivedMessages.AppendText(message + Environment.NewLine);
                }));
            }
            else
            {
                rtbReceivedMessages.AppendText(message + Environment.NewLine);
            }
        }
        public void serverThread()
        {
            UdpClient udpClient = new UdpClient(8080);
            while (true)
            {
                IPEndPoint RemoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIPEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                string message = RemoteIPEndPoint.Address.ToString() + ":" + returnData.ToString();
                
            }
        }
    }
}
