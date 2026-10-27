namespace LAB03
{
    partial class Bai1_Client
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
            txtIPRemoteHost = new TextBox();
            txtPort = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            rtbMessages = new RichTextBox();
            SuspendLayout();
            // 
            // txtIPRemoteHost
            // 
            txtIPRemoteHost.Location = new Point(169, 24);
            txtIPRemoteHost.Name = "txtIPRemoteHost";
            txtIPRemoteHost.Size = new Size(207, 31);
            txtIPRemoteHost.TabIndex = 0;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(499, 24);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(227, 31);
            txtPort.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 27);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 2;
            label1.Text = "IP Remote Host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(449, 27);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 115);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 2;
            label3.Text = "Message";
            // 
            // button1
            // 
            button1.Location = new Point(327, 361);
            button1.Name = "button1";
            button1.Size = new Size(166, 55);
            button1.TabIndex = 3;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // rtbMessages
            // 
            rtbMessages.Location = new Point(27, 143);
            rtbMessages.Name = "rtbMessages";
            rtbMessages.Size = new Size(761, 212);
            rtbMessages.TabIndex = 5;
            rtbMessages.Text = "";
            // 
            // Bai1_Client
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbMessages);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPort);
            Controls.Add(txtIPRemoteHost);
            Name = "Bai1_Client";
            Text = "Bai1_Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIPRemoteHost;
        private TextBox txtPort;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private RichTextBox rtbMessages;
    }
}