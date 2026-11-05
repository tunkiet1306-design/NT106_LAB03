namespace LAB03
{
    partial class Bai4
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
            btnServer = new Button();
            btnClient = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnServer
            // 
            btnServer.Location = new Point(202, 74);
            btnServer.Name = "btnServer";
            btnServer.Size = new Size(388, 132);
            btnServer.TabIndex = 0;
            btnServer.Text = "SERVER";
            btnServer.UseVisualStyleBackColor = true;
            btnServer.Click += btnServer_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(202, 237);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(388, 132);
            btnClient.TabIndex = 1;
            btnClient.Text = "CLIENT";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(299, 29);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 2;
            label1.Text = "QUAN LY PHONG VE TCP/IP";
            // 
            // Bai4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnClient);
            Controls.Add(btnServer);
            Name = "Bai4";
            Text = "Bai4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnServer;
        private Button btnClient;
        private Label label1;
    }
}