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
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(22, 80);
            listView1.Name = "listView1";
            listView1.Size = new Size(749, 359);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button4
            // 
            button4.Location = new Point(634, 30);
            button4.Name = "button4";
            button4.Size = new Size(137, 44);
            button4.TabIndex = 4;
            button4.Text = "Listen";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnListen_Click;
            // 
            // Bai3_Server
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 462);
            Controls.Add(listView1);
            Controls.Add(button4);
            Name = "Bai3_Server";
            Text = "Bai3_Server";
            ResumeLayout(false);
        }

        #endregion
        private ListView listView1;
        private Button button4;
    }
}