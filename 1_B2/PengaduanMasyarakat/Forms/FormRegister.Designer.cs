namespace PengaduanMasyarakat.Forms
{
    partial class FormRegister
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblNamaLengkap;
        private System.Windows.Forms.TextBox txtNamaLengkap;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnKembali;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.btnKembali = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNamaLengkap = new System.Windows.Forms.TextBox();
            this.lblNamaLengkap = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(450, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(120, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Daftar Akun Baru";
            // 
            // panelRegister
            // 
            this.panelRegister.BackColor = System.Drawing.Color.White;
            this.panelRegister.Controls.Add(this.btnKembali);
            this.panelRegister.Controls.Add(this.btnRegister);
            this.panelRegister.Controls.Add(this.txtEmail);
            this.panelRegister.Controls.Add(this.lblEmail);
            this.panelRegister.Controls.Add(this.txtNamaLengkap);
            this.panelRegister.Controls.Add(this.lblNamaLengkap);
            this.panelRegister.Controls.Add(this.txtPassword);
            this.panelRegister.Controls.Add(this.lblPassword);
            this.panelRegister.Controls.Add(this.txtUsername);
            this.panelRegister.Controls.Add(this.lblUsername);
            this.panelRegister.Location = new System.Drawing.Point(50, 110);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(350, 420);
            this.panelRegister.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.Location = new System.Drawing.Point(30, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(71, 19);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(30, 48);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(290, 25);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(30, 85);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 19);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(30, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(290, 25);
            this.txtPassword.TabIndex = 3;
            // 
            // lblNamaLengkap
            // 
            this.lblNamaLengkap.AutoSize = true;
            this.lblNamaLengkap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNamaLengkap.Location = new System.Drawing.Point(30, 145);
            this.lblNamaLengkap.Name = "lblNamaLengkap";
            this.lblNamaLengkap.Size = new System.Drawing.Size(104, 19);
            this.lblNamaLengkap.TabIndex = 4;
            this.lblNamaLengkap.Text = "Nama Lengkap";
            // 
            // txtNamaLengkap
            // 
            this.txtNamaLengkap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNamaLengkap.Location = new System.Drawing.Point(30, 168);
            this.txtNamaLengkap.Name = "txtNamaLengkap";
            this.txtNamaLengkap.Size = new System.Drawing.Size(290, 25);
            this.txtNamaLengkap.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(30, 205);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 19);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(30, 228);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 25);
            this.txtEmail.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(30, 280);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(290, 40);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "DAFTAR";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnKembali
            // 
            this.btnKembali.BackColor = System.Drawing.Color.White;
            this.btnKembali.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKembali.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKembali.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnKembali.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnKembali.Location = new System.Drawing.Point(30, 335);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(290, 35);
            this.btnKembali.TabIndex = 9;
            this.btnKembali.Text = "Kembali ke Login";
            this.btnKembali.UseVisualStyleBackColor = false;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(450, 560);
            this.Controls.Add(this.panelRegister);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register - Pengaduan Masyarakat";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelRegister.ResumeLayout(false);
            this.panelRegister.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}