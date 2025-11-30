namespace CinemaTix
{
    partial class FormRegister
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnDaftar = new Button();
            labe = new Label();
            txtConfirmPassword = new TextBox();
            lblLogin = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(345, 50);
            label1.Name = "label1";
            label1.Size = new Size(106, 29);
            label1.TabIndex = 0;
            label1.Text = "SIGN UP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(198, 153);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 1;
            label2.Text = "Username :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(198, 209);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 2;
            label3.Text = "Password :";
            label3.Click += label3_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(345, 150);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(249, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(345, 206);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(249, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnDaftar
            // 
            btnDaftar.BackColor = Color.Lime;
            btnDaftar.FlatAppearance.BorderColor = Color.Gray;
            btnDaftar.FlatAppearance.BorderSize = 5;
            btnDaftar.FlatStyle = FlatStyle.Flat;
            btnDaftar.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDaftar.ForeColor = SystemColors.ActiveCaptionText;
            btnDaftar.Location = new Point(484, 320);
            btnDaftar.Name = "btnDaftar";
            btnDaftar.Size = new Size(110, 37);
            btnDaftar.TabIndex = 5;
            btnDaftar.Text = "Daftar";
            btnDaftar.UseVisualStyleBackColor = false;
            btnDaftar.Click += btnDaftar_Click;
            // 
            // labe
            // 
            labe.AutoSize = true;
            labe.BackColor = Color.Transparent;
            labe.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labe.ForeColor = SystemColors.ButtonHighlight;
            labe.Location = new Point(113, 263);
            labe.Name = "labe";
            labe.Size = new Size(173, 20);
            labe.TabIndex = 6;
            labe.Text = "Konfirmasi Password :";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(345, 260);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(249, 27);
            txtConfirmPassword.TabIndex = 7;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(420, 375);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(174, 20);
            lblLogin.TabIndex = 8;
            lblLogin.TabStop = true;
            lblLogin.Text = "Sudah punya akun? login";
            lblLogin.LinkClicked += lblLogin_LinkClicked;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(lblLogin);
            Controls.Add(txtConfirmPassword);
            Controls.Add(labe);
            Controls.Add(btnDaftar);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormRegister";
            Text = "FormRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnDaftar;
        private Label labe;
        private TextBox txtConfirmPassword;
        private LinkLabel lblLogin;
    }
}