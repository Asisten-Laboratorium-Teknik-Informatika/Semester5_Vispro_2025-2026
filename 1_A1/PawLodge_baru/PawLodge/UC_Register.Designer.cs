using System;
using System.Drawing;
using System.Windows.Forms;

namespace PawLodge
{
    partial class UC_Register
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblBackLogin = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ========================================
            // labelTitle - "Daftar Akun"
            // ========================================
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.HotPink;
            this.labelTitle.Location = new Point(60, 40);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(300, 46);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Daftar Akun";
            this.labelTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ========================================
            // labelUser + txtUsername
            // ========================================
            this.labelUser.Font = new Font("Segoe UI", 11F);
            this.labelUser.Location = new Point(60, 120);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new Size(120, 23);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "Nama Pengguna";

            this.txtUsername.Font = new Font("Segoe UI", 11F);
            this.txtUsername.Location = new Point(60, 145);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(300, 32);
            this.txtUsername.TabIndex = 2;

            // ========================================
            // labelPass + txtPassword
            // ========================================
            this.labelPass.Font = new Font("Segoe UI", 11F);
            this.labelPass.Location = new Point(60, 200);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new Size(120, 23);
            this.labelPass.TabIndex = 3;
            this.labelPass.Text = "Kata Sandi";

            this.txtPassword.Font = new Font("Segoe UI", 11F);
            this.txtPassword.Location = new Point(60, 225);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new Size(300, 32);
            this.txtPassword.TabIndex = 4;

            // ========================================
            // labelConfirm + txtConfirm
            // ========================================
            this.labelConfirm.Font = new Font("Segoe UI", 11F);
            this.labelConfirm.Location = new Point(60, 280);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new Size(180, 23);
            this.labelConfirm.TabIndex = 5;
            this.labelConfirm.Text = "Konfirmasi Kata Sandi";

            this.txtConfirm.Font = new Font("Segoe UI", 11F);
            this.txtConfirm.Location = new Point(60, 305);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '•';
            this.txtConfirm.Size = new Size(300, 32);
            this.txtConfirm.TabIndex = 6;

            // ========================================
            // btnRegister
            // ========================================
            this.btnRegister.BackColor = Color.HotPink;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.Location = new Point(60, 370);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new Size(300, 50);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Daftar";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // ========================================
            // lblBackLogin - Kembali ke Login
            // ========================================
            this.lblBackLogin.AutoSize = true;
            this.lblBackLogin.Cursor = Cursors.Hand;
            this.lblBackLogin.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
            this.lblBackLogin.ForeColor = Color.MediumPurple;
            this.lblBackLogin.Location = new Point(100, 440);
            this.lblBackLogin.Name = "lblBackLogin";
            this.lblBackLogin.Size = new Size(220, 23);
            this.lblBackLogin.TabIndex = 8;
            this.lblBackLogin.Text = "Sudah punya akun? Masuk di sini";
            this.lblBackLogin.TextAlign = ContentAlignment.MiddleCenter;
            this.lblBackLogin.Click += new EventHandler(this.lblBackLogin_Click);


            // ========================================
            // UC_Register (this)
            // ========================================
            this.BackColor = Color.FromArgb(255, 240, 250); // pink muda
            this.Controls.Add(this.lblBackLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelTitle);

            this.Name = "UC_Register";
            this.Size = new Size(420, 550);
          

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Deklarasi kontrol-kontrol
        private Label labelTitle;
        private Label labelUser;
        private Label labelPass;
        private Label labelConfirm;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirm;
        private Button btnRegister;
        private Label lblBackLogin;
    }
}