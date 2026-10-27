namespace LAB03
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnBai1 = new System.Windows.Forms.Button();
            this.btnBai2 = new System.Windows.Forms.Button();
            this.btnBai3 = new System.Windows.Forms.Button();
            this.btnBai4 = new System.Windows.Forms.Button();
            this.btnBai5 = new System.Windows.Forms.Button();
            this.btnBai6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBai1
            // 
            this.btnBai1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBai1.Location = new System.Drawing.Point(40, 25);
            this.btnBai1.Name = "btnBai1";
            this.btnBai1.Size = new System.Drawing.Size(280, 40);
            this.btnBai1.TabIndex = 0;
            this.btnBai1.Text = "Bài 01: UDP Server - Client";
            this.btnBai1.UseVisualStyleBackColor = true;
            this.btnBai1.Click += new System.EventHandler(this.btnBai1_Click);
            // 
            // btnBai2
            // 
            this.btnBai2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBai2.Location = new System.Drawing.Point(40, 75);
            this.btnBai2.Name = "btnBai2";
            this.btnBai2.Size = new System.Drawing.Size(280, 40);
            this.btnBai2.TabIndex = 1;
            this.btnBai2.Text = "Bài 02: Telnet TCP Server";
            this.btnBai2.UseVisualStyleBackColor = true;
            this.btnBai2.Click += new System.EventHandler(this.btnBai2_Click);
            // 
            // btnBai3
            // 
            this.btnBai3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBai3.Location = new System.Drawing.Point(40, 125);
            this.btnBai3.Name = "btnBai3";
            this.btnBai3.Size = new System.Drawing.Size(280, 40);
            this.btnBai3.TabIndex = 2;
            this.btnBai3.Text = "Bài 03: TCP Server - Client";
            this.btnBai3.UseVisualStyleBackColor = true;
            this.btnBai3.Click += new System.EventHandler(this.btnBai3_Click);
            // 
            // btnBai4
            // 
            this.btnBai4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBai4.Location = new System.Drawing.Point(40, 175);
            this.btnBai4.Name = "btnBai4";
            this.btnBai4.Size = new System.Drawing.Size(280, 40);
            this.btnBai4.TabIndex = 3;
            this.btnBai4.Text = "Bài 04: Quản lý phòng vé";
            this.btnBai4.UseVisualStyleBackColor = true;
            this.btnBai4.Click += new System.EventHandler(this.btnBai4_Click);
            // 
            // btnBai5
            // 
            this.btnBai5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBai5.Location = new System.Drawing.Point(40, 225);
            this.btnBai5.Name = "btnBai5";
            this.btnBai5.Size = new System.Drawing.Size(280, 40);
            this.btnBai5.TabIndex = 4;
            this.btnBai5.Text = "Bài 05: Hôm nay ăn gì?";
            this.btnBai5.UseVisualStyleBackColor = true;
            this.btnBai5.Click += new System.EventHandler(this.btnBai5_Click);
            // 
            // btnBai6
            // 
            this.btnBai6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBai6.Location = new System.Drawing.Point(40, 275);
            this.btnBai6.Name = "btnBai6";
            this.btnBai6.Size = new System.Drawing.Size(280, 40);
            this.btnBai6.TabIndex = 5;
            this.btnBai6.Text = "Bài 06: Chat Room Multi-Client";
            this.btnBai6.UseVisualStyleBackColor = true;
            this.btnBai6.Click += new System.EventHandler(this.btnBai6_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 345);
            this.Controls.Add(this.btnBai6);
            this.Controls.Add(this.btnBai5);
            this.Controls.Add(this.btnBai4);
            this.Controls.Add(this.btnBai3);
            this.Controls.Add(this.btnBai2);
            this.Controls.Add(this.btnBai1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Lab 03";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnBai1;
        private System.Windows.Forms.Button btnBai2;
        private System.Windows.Forms.Button btnBai3;
        private System.Windows.Forms.Button btnBai4;
        private System.Windows.Forms.Button btnBai5;
        private System.Windows.Forms.Button btnBai6;
    }
}