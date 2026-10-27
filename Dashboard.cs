using System;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            Bai1 formBai1 = new Bai1();
            formBai1.Show();
        }

        private void btnBai2_Click(object sender, EventArgs e)
        {
            Bai2 formBai2 = new Bai2();
            formBai2.Show();
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            Bai3 formBai3 = new Bai3();
            formBai3.Show();
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            Bai4 formBai4 = new Bai4();
            formBai4.Show();
        }

        private void btnBai5_Click(object sender, EventArgs e)
        {
            Bai5 formBai5 = new Bai5();
            formBai5.Show();
        }

        private void btnBai6_Click(object sender, EventArgs e)
        {
            Bai6 formBai6 = new Bai6();
            formBai6.Show();
        }
    }
}