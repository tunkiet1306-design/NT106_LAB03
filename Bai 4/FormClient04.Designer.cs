using System.Drawing;
using System.Windows.Forms;

namespace LAB03
{
    partial class FormClient04
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblIP;
        private Label lblName;
        private Label lblMovie;

        private TextBox txtIP;
        private TextBox txtName;

        private ComboBox cboMovie;

        private Button btnConnect;
        private Button btnDatVe;
        private Button btnXoa;
        private Button btnThoat;

        private FlowLayoutPanel flpSeat;

        private ListBox lstSelectedSeat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblIP = new Label();
            lblName = new Label();
            lblMovie = new Label();

            txtIP = new TextBox();
            txtName = new TextBox();

            cboMovie = new ComboBox();

            btnConnect = new Button();
            btnDatVe = new Button();
            btnXoa = new Button();
            btnThoat = new Button();

            flpSeat = new FlowLayoutPanel();

            lstSelectedSeat = new ListBox();

            SuspendLayout();

            // lblTitle

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold);

            lblTitle.Location = new Point(180, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "QUẢN LÝ PHÒNG VÉ CLIENT";

            // lblIP

            lblIP.AutoSize = true;
            lblIP.Location = new Point(30, 90);
            lblIP.Name = "lblIP";
            lblIP.Text = "IP Server:";

            // txtIP

            txtIP.Location = new Point(120, 87);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(200, 27);
            txtIP.Text = "127.0.0.1";

            // btnConnect

            btnConnect.Location = new Point(340, 85);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(120, 30);
            btnConnect.Text = "Kết Nối";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;

            // lblName

            lblName.AutoSize = true;
            lblName.Location = new Point(30, 140);
            lblName.Name = "lblName";
            lblName.Text = "Họ tên:";

            // txtName

            txtName.Location = new Point(120, 137);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);

            // lblMovie

            lblMovie.AutoSize = true;
            lblMovie.Location = new Point(30, 190);
            lblMovie.Name = "lblMovie";
            lblMovie.Text = "Phim:";

            // cboMovie

            cboMovie.FormattingEnabled = true;
            cboMovie.Location = new Point(120, 187);
            cboMovie.Name = "cboMovie";
            cboMovie.Size = new Size(250, 28);

            // flpSeat

            flpSeat.BorderStyle = BorderStyle.FixedSingle;
            flpSeat.Location = new Point(30, 240);
            flpSeat.Name = "flpSeat";
            flpSeat.Size = new Size(500, 200);

            // lstSelectedSeat

            lstSelectedSeat.FormattingEnabled = true;
            lstSelectedSeat.Location = new Point(560, 240);
            lstSelectedSeat.Name = "lstSelectedSeat";
            lstSelectedSeat.Size = new Size(180, 204);

            // btnDatVe

            btnDatVe.Location = new Point(30, 500);
            btnDatVe.Name = "btnDatVe";
            btnDatVe.Size = new Size(120, 40);
            btnDatVe.Text = "Đặt Vé";
            btnDatVe.UseVisualStyleBackColor = true;
            btnDatVe.Click += btnDatVe_Click;

            // btnXoa

            btnXoa.Location = new Point(170, 500);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.Text = "Xóa Chọn";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // btnThoat

            btnThoat.Location = new Point(310, 500);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 40);
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;

            // FormClient04

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(800, 600);

            Controls.Add(lblTitle);

            Controls.Add(lblIP);
            Controls.Add(txtIP);
            Controls.Add(btnConnect);

            Controls.Add(lblName);
            Controls.Add(txtName);

            Controls.Add(lblMovie);
            Controls.Add(cboMovie);

            Controls.Add(flpSeat);

            Controls.Add(lstSelectedSeat);

            Controls.Add(btnDatVe);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);

            Name = "FormClient04";
            Text = "Client";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}