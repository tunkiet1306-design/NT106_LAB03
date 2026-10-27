namespace LAB03
{
    partial class Bai1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUDPClient = new Button();
            btnUDPServer = new Button();
            SuspendLayout();
            // 
            // btnUDPClient
            // 
            btnUDPClient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUDPClient.Location = new Point(91, 129);
            btnUDPClient.Name = "btnUDPClient";
            btnUDPClient.Size = new Size(277, 56);
            btnUDPClient.TabIndex = 0;
            btnUDPClient.Text = "UDP CLIENT";
            btnUDPClient.UseVisualStyleBackColor = true;
            // 
            // btnUDPServer
            // 
            btnUDPServer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUDPServer.Location = new Point(432, 129);
            btnUDPServer.Name = "btnUDPServer";
            btnUDPServer.Size = new Size(277, 56);
            btnUDPServer.TabIndex = 0;
            btnUDPServer.Text = "UDP SERVER";
            btnUDPServer.UseVisualStyleBackColor = true;
            // 
            // Bai1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUDPServer);
            Controls.Add(btnUDPClient);
            Name = "Bai1";
            Text = "Bai1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnUDPClient;
        private Button btnUDPServer;
    }
}