namespace PengaduanMasyarakat.Forms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkRegister;
        private System.Windows.Forms.Label lblSubtitle;

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
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelLogin = new Panel();
            linkRegister = new LinkLabel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            panelHeader.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(46, 125, 50);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(5, 6, 5, 6);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(750, 192);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(250, 105);
            lblSubtitle.Margin = new Padding(5, 0, 5, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(262, 28);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Layanan Aduan untuk Warga";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(176, 43);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(411, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Pengaduan Masyarakat";
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.White;
            panelLogin.Controls.Add(linkRegister);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(lblPassword);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(lblUsername);
            panelLogin.Location = new Point(83, 250);
            panelLogin.Margin = new Padding(5, 6, 5, 6);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(583, 538);
            panelLogin.TabIndex = 1;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Font = new Font("Segoe UI", 9F);
            linkRegister.LinkColor = Color.FromArgb(46, 125, 50);
            linkRegister.Location = new Point(158, 452);
            linkRegister.Margin = new Padding(5, 0, 5, 0);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(271, 25);
            linkRegister.TabIndex = 5;
            linkRegister.TabStop = true;
            linkRegister.Text = "Belum punya akun? Daftar di sini";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 125, 50);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 337);
            btnLogin.Margin = new Padding(5, 6, 5, 6);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(483, 77);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(50, 240);
            txtPassword.Margin = new Padding(5, 6, 5, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(481, 37);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(50, 192);
            lblPassword.Margin = new Padding(5, 0, 5, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(93, 28);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(50, 106);
            txtUsername.Margin = new Padding(5, 6, 5, 6);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(481, 37);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(50, 58);
            lblUsername.Margin = new Padding(5, 0, 5, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 28);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 245, 233);
            ClientSize = new Size(750, 865);
            Controls.Add(panelLogin);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Pengaduan Masyarakat";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }
    }
}