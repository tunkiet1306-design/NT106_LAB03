using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai3_Server server = new Bai3_Server();
            server.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai3_Client client = new Bai3_Client();
            client.Show();
        }
    }
}
