using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            FormServer04 frm = new FormServer04();

            frm.Show();

            this.Hide();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            FormClient04 frm = new FormClient04();

            frm.Show();

            this.Hide();
        }
    }
}
