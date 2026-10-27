namespace LAB03
{
    partial class Bai2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpServer;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListView listViewCommand;
        private System.Windows.Forms.ColumnHeader columnHeader1;

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnOpenNewWindow;
        private System.Windows.Forms.ListBox lstClientLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.listViewCommand = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();

            this.grpClient = new System.Windows.Forms.GroupBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnOpenNewWindow = new System.Windows.Forms.Button();
            this.lstClientLog = new System.Windows.Forms.ListBox();

            this.grpServer.SuspendLayout();
            this.grpClient.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpServer (BÊN TRÁI - ĐÓNG VAI TRÒ SERVER)
            // 
            this.grpServer.Controls.Add(this.btnListen);
            this.grpServer.Controls.Add(this.listViewCommand);
            this.grpServer.Location = new System.Drawing.Point(15, 15);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(380, 380);
            this.grpServer.TabIndex = 0;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "TCP SERVER (Lắng nghe Telnet / Client)";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(15, 25);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(120, 35);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Listen (Port 8080)";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // listViewCommand
            // 
            this.listViewCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1 });
            this.listViewCommand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewCommand.Location = new System.Drawing.Point(15, 70);
            this.listViewCommand.Name = "listViewCommand";
            this.listViewCommand.Size = new System.Drawing.Size(350, 295);
            this.listViewCommand.TabIndex = 1;
            this.listViewCommand.UseCompatibleStateImageBehavior = false;
            this.listViewCommand.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data";
            this.columnHeader1.Width = 330;

            // 
            // grpClient (BÊN PHẢI - ĐÓNG VAI TRÒ CLIENT THAY CHO CMD TELNET)
            // 
            this.grpClient.Controls.Add(this.lblIP);
            this.grpClient.Controls.Add(this.txtServerIP);
            this.grpClient.Controls.Add(this.lblPort);
            this.grpClient.Controls.Add(this.txtPort);
            this.grpClient.Controls.Add(this.btnConnect);
            this.grpClient.Controls.Add(this.txtMessage);
            this.grpClient.Controls.Add(this.btnSend);
            this.grpClient.Controls.Add(this.btnOpenNewWindow);
            this.grpClient.Controls.Add(this.lstClientLog);
            this.grpClient.Location = new System.Drawing.Point(410, 15);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(380, 380);
            this.grpClient.TabIndex = 1;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "TCP CLIENT (Gửi dữ liệu qua Localhost / LAN)";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(15, 32);
            this.lblIP.Text = "IP Server:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(75, 28);
            this.txtServerIP.Size = new System.Drawing.Size(115, 23);
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(198, 32);
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(232, 28);
            this.txtPort.Size = new System.Drawing.Size(50, 23);
            this.txtPort.Text = "8080";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(290, 26);
            this.btnConnect.Size = new System.Drawing.Size(75, 28);
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(15, 70);
            this.txtMessage.Size = new System.Drawing.Size(267, 23);
            this.txtMessage.Enabled = false;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(290, 68);
            this.btnSend.Size = new System.Drawing.Size(75, 28);
            this.btnSend.Text = "Send";
            this.btnSend.Enabled = false;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstClientLog
            // 
            this.lstClientLog.Location = new System.Drawing.Point(15, 105);
            this.lstClientLog.Size = new System.Drawing.Size(350, 215);
            // 
            // btnOpenNewWindow
            // 
            this.btnOpenNewWindow.Location = new System.Drawing.Point(15, 330);
            this.btnOpenNewWindow.Size = new System.Drawing.Size(350, 35);
            this.btnOpenNewWindow.Text = "Mở thêm 1 cửa sổ Bai2 mới (Để tách rời Client & Server)";
            this.btnOpenNewWindow.UseVisualStyleBackColor = true;
            this.btnOpenNewWindow.Click += new System.EventHandler(this.btnOpenNewWindow_Click);

            // 
            // Bai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 410);
            this.Controls.Add(this.grpClient);
            this.Controls.Add(this.grpServer);
            this.Name = "Bai2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 2 - TCP Server & Telnet Client (Hỗ trợ Localhost và LAN)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bai2_FormClosing);
            this.grpServer.ResumeLayout(false);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}