namespace LAB03
{
    partial class Bai3_Client
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(650, 294);
            button3.Name = "button3";
            button3.Size = new Size(130, 57);
            button3.TabIndex = 7;
            button3.Text = "Disconnect";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnDisconnect_Click;
            // 
            // button2
            // 
            button2.Location = new Point(650, 203);
            button2.Name = "button2";
            button2.Size = new Size(130, 57);
            button2.TabIndex = 6;
            button2.Text = "Send";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSend_Click;
            // 
            // button1
            // 
            button1.Location = new Point(650, 109);
            button1.Name = "button1";
            button1.Size = new Size(130, 57);
            button1.TabIndex = 5;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnConnect_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(32, 109);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(601, 242);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(65, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(289, 31);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(483, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(297, 31);
            textBox2.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 34);
            label1.Name = "label1";
            label1.Size = new Size(27, 25);
            label1.TabIndex = 10;
            label1.Text = "IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 34);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 11;
            label2.Text = "Massage";
            // 
            // Bai3_Client
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 384);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Name = "Bai3_Client";
            Text = "Bai3_Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
    }
}