using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            UdpClient udpClient = new UdpClient();
            string ipAddress = txtIPRemoteHost.Text;
            int port = int.Parse(txtPort.Text);
            string message = rtbMessages.Text;

            // Mã hóa dữ liệu chuỗi thành mảng byte với chuẩn UTF8
            Byte[] sendBytes = Encoding.UTF8.GetBytes(message);

            // Gửi dữ liệu đi qua UDP
            udpClient.Send(sendBytes, sendBytes.Length, ipAddress, port);
        }
    }
}
