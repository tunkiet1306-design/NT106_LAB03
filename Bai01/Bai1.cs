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
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void btnUDPClient_Click(object sender, EventArgs e)
        {
            Bai1_Client formClient = new Bai1_Client();
            formClient.Show();
        }

        private void btnUDPServer_Click(object sender, EventArgs e)
        {
            Bai1_Server formServer = new Bai1_Server();
            formServer.Show();
        }
    }
}
