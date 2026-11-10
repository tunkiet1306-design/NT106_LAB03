namespace LAB03
{
    partial class Bai3_Server
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
            listView1 = new ListView();
            button4 = new Button();
            label1 = new Label();
            txtPort = new TextBox();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(22, 80);
            listView1.Name = "listView1";
            listView1.Size = new Size(749, 359);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button4
            // 
            button4.Location = new Point(634, 25);
            button4.Name = "button4";
            button4.Size = new Size(137, 44);
            button4.TabIndex = 2;
            button4.Text = "Listen";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnListen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 35);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 0;
            label1.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(76, 32);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(150, 31);
            txtPort.TabIndex = 1;
            txtPort.Text = "8080";
            // 
            // Bai3_Server
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 462);
            Controls.Add(txtPort);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(button4);
            Name = "Bai3_Server";
            Text = "Bai3_Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView listView1;
        private Button button4;
        private Label label1;
        private TextBox txtPort;
    }
}
