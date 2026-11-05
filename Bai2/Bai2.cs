using System;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            Bai2_Server serverForm = new Bai2_Server();
            serverForm.Show();
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            Bai2_Client clientForm = new Bai2_Client();
            clientForm.Show();
        }
    }
}

