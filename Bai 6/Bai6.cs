using System;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai6 : Form
    {
        public Bai6()
        {
            InitializeComponent();
        }

        private void btnServer_Click(
            object sender,
            EventArgs e)
        {
            FormServer06 server =
                new FormServer06();

            server.Show();
        }

        private void btnClient_Click(
            object sender,
            EventArgs e)
        {
            FormClient06 client =
                new FormClient06();

            client.Show();
        }

        private void Bai6_Load(
            object sender,
            EventArgs e)
        {

        }
    }
}