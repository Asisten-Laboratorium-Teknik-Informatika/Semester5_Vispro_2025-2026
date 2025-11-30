namespace PengaduanMasyarakat.Forms
{
    partial class FormDashboardAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnPengaduanMasuk;
        private System.Windows.Forms.Button btnRiwayatSelesai;
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
            this.btnRiwayatSelesai = new System.Windows.Forms.Button();
            this.btnPengaduanMasuk = new System.Windows.Forms.Button();
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
            this.panelSidebar.Controls.Add(this.btnRiwayatSelesai);
            this.panelSidebar.Controls.Add(this.btnPengaduanMasuk);
            this.panelSidebar.Controls.Add(this.lblUsername);
            this.panelSidebar.Controls.Add(this.lblWelcome);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(270, 650);
            this.panelSidebar.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(157, 21);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Dashboard Admin";
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
            // btnPengaduanMasuk
            // 
            this.btnPengaduanMasuk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnPengaduanMasuk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPengaduanMasuk.FlatAppearance.BorderSize = 0;
            this.btnPengaduanMasuk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPengaduanMasuk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPengaduanMasuk.ForeColor = System.Drawing.Color.White;
            this.btnPengaduanMasuk.Location = new System.Drawing.Point(20, 120);
            this.btnPengaduanMasuk.Name = "btnPengaduanMasuk";
            this.btnPengaduanMasuk.Size = new System.Drawing.Size(230, 45);
            this.btnPengaduanMasuk.TabIndex = 2;
            this.btnPengaduanMasuk.Text = "📥 Pengaduan Masuk";
            this.btnPengaduanMasuk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPengaduanMasuk.UseVisualStyleBackColor = false;
            this.btnPengaduanMasuk.Click += new System.EventHandler(this.btnPengaduanMasuk_Click);
            // 
            // btnRiwayatSelesai
            // 
            this.btnRiwayatSelesai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnRiwayatSelesai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRiwayatSelesai.FlatAppearance.BorderSize = 0;
            this.btnRiwayatSelesai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRiwayatSelesai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRiwayatSelesai.ForeColor = System.Drawing.Color.White;
            this.btnRiwayatSelesai.Location = new System.Drawing.Point(20, 175);
            this.btnRiwayatSelesai.Name = "btnRiwayatSelesai";
            this.btnRiwayatSelesai.Size = new System.Drawing.Size(230, 45);
            this.btnRiwayatSelesai.TabIndex = 3;
            this.btnRiwayatSelesai.Text = "✅ Riwayat Selesai";
            this.btnRiwayatSelesai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRiwayatSelesai.UseVisualStyleBackColor = false;
            this.btnRiwayatSelesai.Click += new System.EventHandler(this.btnRiwayatSelesai_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(20, 580);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(230, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = " Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(270, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(930, 70);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pengaduan Masuk";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(270, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(930, 580);
            this.panelContent.TabIndex = 2;
            // 
            // FormDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDashboardAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Admin - Pengaduan Masyarakat";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}