namespace LAB03
{
    partial class Bai6
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnServer;
        private Button btnClient;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnServer = new Button();
            btnClient = new Button();
            lblTitle = new Label();

            SuspendLayout();

            // lblTitle

            lblTitle.AutoSize = true;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    16F,
                    FontStyle.Bold);

            lblTitle.Location =
                new Point(250, 50);

            lblTitle.Name =
                "lblTitle";

            lblTitle.Size =
                new Size(300, 37);

            lblTitle.Text =
                "BÀI 6 - CHAT ROOM TCP";

            // btnServer

            btnServer.Location =
                new Point(280, 150);

            btnServer.Name =
                "btnServer";

            btnServer.Size =
                new Size(220, 60);

            btnServer.Text =
                "MỞ SERVER";

            btnServer.UseVisualStyleBackColor =
                true;

            btnServer.Click +=
                btnServer_Click;

            // btnClient

            btnClient.Location =
                new Point(280, 250);

            btnClient.Name =
                "btnClient";

            btnClient.Size =
                new Size(220, 60);

            btnClient.Text =
                "MỞ CLIENT";

            btnClient.UseVisualStyleBackColor =
                true;

            btnClient.Click +=
                btnClient_Click;

            // Bai6

            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(800, 450);

            Controls.Add(lblTitle);
            Controls.Add(btnServer);
            Controls.Add(btnClient);

            Name =
                "Bai6";

            Text =
                "Bài 6 - Dashboard";

            Load +=
                Bai6_Load;

            ResumeLayout(false);

            PerformLayout();
        }
    }
}