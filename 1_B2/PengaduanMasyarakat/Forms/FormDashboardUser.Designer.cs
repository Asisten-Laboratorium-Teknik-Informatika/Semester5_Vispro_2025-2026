namespace PengaduanMasyarakat.Forms
{
    partial class FormDashboardUser
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnBuatPengaduan;
        private System.Windows.Forms.Button btnRiwayat;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblTitle;

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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.btnBuatPengaduan = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnRiwayat);
            this.panelSidebar.Controls.Add(this.btnBuatPengaduan);
            this.panelSidebar.Controls.Add(this.lblUsername);
            this.panelSidebar.Controls.Add(this.lblWelcome);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 600);
            this.panelSidebar.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(135, 21);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Selamat Datang,";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(20, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 20);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // btnBuatPengaduan
            // 
            this.btnBuatPengaduan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnBuatPengaduan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuatPengaduan.FlatAppearance.BorderSize = 0;
            this.btnBuatPengaduan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuatPengaduan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuatPengaduan.ForeColor = System.Drawing.Color.White;
            this.btnBuatPengaduan.Location = new System.Drawing.Point(20, 120);
            this.btnBuatPengaduan.Name = "btnBuatPengaduan";
            this.btnBuatPengaduan.Size = new System.Drawing.Size(210, 45);
            this.btnBuatPengaduan.TabIndex = 2;
            this.btnBuatPengaduan.Text = "📝 Buat Pengaduan";
            this.btnBuatPengaduan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuatPengaduan.UseVisualStyleBackColor = false;
            this.btnBuatPengaduan.Click += new System.EventHandler(this.btnBuatPengaduan_Click);
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnRiwayat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRiwayat.FlatAppearance.BorderSize = 0;
            this.btnRiwayat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRiwayat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRiwayat.ForeColor = System.Drawing.Color.White;
            this.btnRiwayat.Location = new System.Drawing.Point(20, 175);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(210, 45);
            this.btnRiwayat.TabIndex = 3;
            this.btnRiwayat.Text = "📋 Riwayat Pengaduan";
            this.btnRiwayat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRiwayat.UseVisualStyleBackColor = false;
            this.btnRiwayat.Click += new System.EventHandler(this.btnRiwayat_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(20, 530);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(210, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(250, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(750, 70);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Buat Pengaduan";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(250, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(750, 530);
            this.panelContent.TabIndex = 2;
            // 
            // FormDashboardUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDashboardUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard User - Pengaduan Masyarakat";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}