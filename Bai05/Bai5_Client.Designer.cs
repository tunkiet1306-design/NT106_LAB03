namespace LAB03
{
    partial class Bai5_Client
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
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.gbAddFood = new System.Windows.Forms.GroupBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.lblImageUrl = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.lblFoodName = new System.Windows.Forms.Label();
            this.gbRandom = new System.Windows.Forms.GroupBox();
            this.btnRandomUser = new System.Windows.Forms.Button();
            this.btnRandomAll = new System.Windows.Forms.Button();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.lvMonAn = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colTenMon = new System.Windows.Forms.ColumnHeader();
            this.colNguoiDongGop = new System.Windows.Forms.ColumnHeader();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.picFood = new System.Windows.Forms.PictureBox();
            this.lblResultContributor = new System.Windows.Forms.Label();
            this.lblResultFood = new System.Windows.Forms.Label();
            this.gbConnect.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.gbAddFood.SuspendLayout();
            this.gbRandom.SuspendLayout();
            this.gbList.SuspendLayout();
            this.gbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFood)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConnect
            // 
            this.gbConnect.Controls.Add(this.btnConnect);
            this.gbConnect.Controls.Add(this.txtPort);
            this.gbConnect.Controls.Add(this.lblPort);
            this.gbConnect.Controls.Add(this.txtServerIP);
            this.gbConnect.Controls.Add(this.lblServerIP);
            this.gbConnect.Location = new System.Drawing.Point(12, 12);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Size = new System.Drawing.Size(350, 85);
            this.gbConnect.TabIndex = 0;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "Kết nối Server";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(235, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 53);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(75, 50);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(145, 23);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8080";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 53);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 15);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(75, 22);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(145, 23);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(12, 25);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(55, 15);
            this.lblServerIP.TabIndex = 0;
            this.lblServerIP.Text = "Server IP:";
            // 
            // gbUser
            // 
            this.gbUser.Controls.Add(this.txtUsername);
            this.gbUser.Controls.Add(this.lblUsername);
            this.gbUser.Location = new System.Drawing.Point(12, 103);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(350, 60);
            this.gbUser.TabIndex = 1;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "Thông tin cá nhân";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(75, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(47, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Họ Tên:";
            // 
            // gbAddFood
            // 
            this.gbAddFood.Controls.Add(this.btnAddFood);
            this.gbAddFood.Controls.Add(this.txtImageUrl);
            this.gbAddFood.Controls.Add(this.lblImageUrl);
            this.gbAddFood.Controls.Add(this.txtFoodName);
            this.gbAddFood.Controls.Add(this.lblFoodName);
            this.gbAddFood.Location = new System.Drawing.Point(12, 169);
            this.gbAddFood.Name = "gbAddFood";
            this.gbAddFood.Size = new System.Drawing.Size(350, 125);
            this.gbAddFood.TabIndex = 2;
            this.gbAddFood.TabStop = false;
            this.gbAddFood.Text = "Thêm món ăn mới";
            // 
            // btnAddFood
            // 
            this.btnAddFood.Enabled = false;
            this.btnAddFood.Location = new System.Drawing.Point(75, 83);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(260, 30);
            this.btnAddFood.TabIndex = 4;
            this.btnAddFood.Text = "Thêm món ăn";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(75, 52);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.Size = new System.Drawing.Size(260, 23);
            this.txtImageUrl.TabIndex = 3;
            // 
            // lblImageUrl
            // 
            this.lblImageUrl.AutoSize = true;
            this.lblImageUrl.Location = new System.Drawing.Point(12, 55);
            this.lblImageUrl.Name = "lblImageUrl";
            this.lblImageUrl.Size = new System.Drawing.Size(59, 15);
            this.lblImageUrl.TabIndex = 2;
            this.lblImageUrl.Text = "Link hình:";
            // 
            // txtFoodName
            // 
            this.txtFoodName.Location = new System.Drawing.Point(75, 22);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(260, 23);
            this.txtFoodName.TabIndex = 1;
            // 
            // lblFoodName
            // 
            this.lblFoodName.AutoSize = true;
            this.lblFoodName.Location = new System.Drawing.Point(12, 25);
            this.lblFoodName.Name = "lblFoodName";
            this.lblFoodName.Size = new System.Drawing.Size(56, 15);
            this.lblFoodName.TabIndex = 0;
            this.lblFoodName.Text = "Tên món:";
            // 
            // gbRandom
            // 
            this.gbRandom.Controls.Add(this.btnRandomUser);
            this.gbRandom.Controls.Add(this.btnRandomAll);
            this.gbRandom.Location = new System.Drawing.Point(12, 300);
            this.gbRandom.Name = "gbRandom";
            this.gbRandom.Size = new System.Drawing.Size(350, 75);
            this.gbRandom.TabIndex = 3;
            this.gbRandom.TabStop = false;
            this.gbRandom.Text = "Rút ngẫu nhiên món ăn";
            // 
            // btnRandomUser
            // 
            this.btnRandomUser.Enabled = false;
            this.btnRandomUser.Location = new System.Drawing.Point(180, 25);
            this.btnRandomUser.Name = "btnRandomUser";
            this.btnRandomUser.Size = new System.Drawing.Size(155, 35);
            this.btnRandomUser.TabIndex = 1;
            this.btnRandomUser.Text = "Tìm món của tôi";
            this.btnRandomUser.UseVisualStyleBackColor = true;
            this.btnRandomUser.Click += new System.EventHandler(this.btnRandomUser_Click);
            // 
            // btnRandomAll
            // 
            this.btnRandomAll.Enabled = false;
            this.btnRandomAll.Location = new System.Drawing.Point(15, 25);
            this.btnRandomAll.Name = "btnRandomAll";
            this.btnRandomAll.Size = new System.Drawing.Size(155, 35);
            this.btnRandomAll.TabIndex = 0;
            this.btnRandomAll.Text = "Món của cộng đồng";
            this.btnRandomAll.UseVisualStyleBackColor = true;
            this.btnRandomAll.Click += new System.EventHandler(this.btnRandomAll_Click);
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.btnRefreshList);
            this.gbList.Controls.Add(this.lvMonAn);
            this.gbList.Location = new System.Drawing.Point(375, 12);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(390, 485);
            this.gbList.TabIndex = 4;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách món ăn trên hệ thống (SQLite/SQL Server)";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Enabled = false;
            this.btnRefreshList.Location = new System.Drawing.Point(15, 445);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(360, 30);
            this.btnRefreshList.TabIndex = 1;
            this.btnRefreshList.Text = "Làm mới danh sách món ăn";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // lvMonAn
            // 
            this.lvMonAn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTenMon,
            this.colNguoiDongGop});
            this.lvMonAn.FullRowSelect = true;
            this.lvMonAn.GridLines = true;
            this.lvMonAn.Location = new System.Drawing.Point(15, 22);
            this.lvMonAn.Name = "lvMonAn";
            this.lvMonAn.Size = new System.Drawing.Size(360, 415);
            this.lvMonAn.TabIndex = 0;
            this.lvMonAn.UseCompatibleStateImageBehavior = false;
            this.lvMonAn.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 45;
            // 
            // colTenMon
            // 
            this.colTenMon.Text = "Tên món ăn";
            this.colTenMon.Width = 180;
            // 
            // colNguoiDongGop
            // 
            this.colNguoiDongGop.Text = "Người đóng góp";
            this.colNguoiDongGop.Width = 130;
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.picFood);
            this.gbResult.Controls.Add(this.lblResultContributor);
            this.gbResult.Controls.Add(this.lblResultFood);
            this.gbResult.Location = new System.Drawing.Point(775, 12);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(340, 485);
            this.gbResult.TabIndex = 5;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Món ăn được chọn";
            // 
            // picFood
            // 
            this.picFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFood.Location = new System.Drawing.Point(15, 110);
            this.picFood.Name = "picFood";
            this.picFood.Size = new System.Drawing.Size(310, 360);
            this.picFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFood.TabIndex = 2;
            this.picFood.TabStop = false;
            // 
            // lblResultContributor
            // 
            this.lblResultContributor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultContributor.Location = new System.Drawing.Point(15, 70);
            this.lblResultContributor.Name = "lblResultContributor";
            this.lblResultContributor.Size = new System.Drawing.Size(310, 25);
            this.lblResultContributor.TabIndex = 1;
            this.lblResultContributor.Text = "Người đóng góp: --";
            // 
            // lblResultFood
            // 
            this.lblResultFood.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResultFood.ForeColor = System.Drawing.Color.DarkRed;
            this.lblResultFood.Location = new System.Drawing.Point(15, 25);
            this.lblResultFood.Name = "lblResultFood";
            this.lblResultFood.Size = new System.Drawing.Size(310, 35);
            this.lblResultFood.TabIndex = 0;
            this.lblResultFood.Text = "--";
            this.lblResultFood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bai5_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 510);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbRandom);
            this.Controls.Add(this.gbAddFood);
            this.Controls.Add(this.gbUser);
            this.Controls.Add(this.gbConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai5_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 05 - Client Hôm nay ăn gì";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bai5_Client_FormClosing);
            this.gbConnect.ResumeLayout(false);
            this.gbConnect.PerformLayout();
            this.gbUser.ResumeLayout(false);
            this.gbUser.PerformLayout();
            this.gbAddFood.ResumeLayout(false);
            this.gbAddFood.PerformLayout();
            this.gbRandom.ResumeLayout(false);
            this.gbList.ResumeLayout(false);
            this.gbResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFood)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox gbConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox gbAddFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Label lblImageUrl;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.Label lblFoodName;
        private System.Windows.Forms.GroupBox gbRandom;
        private System.Windows.Forms.Button btnRandomUser;
        private System.Windows.Forms.Button btnRandomAll;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.ListView lvMonAn;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colTenMon;
        private System.Windows.Forms.ColumnHeader colNguoiDongGop;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.PictureBox picFood;
        private System.Windows.Forms.Label lblResultContributor;
        private System.Windows.Forms.Label lblResultFood;
    }
}