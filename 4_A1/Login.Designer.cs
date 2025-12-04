namespace budgetplanner
{
    partial class Login
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
            label4 = new Label();
            inputPassword = new RoundedTextBox();
            label3 = new Label();
            inputEmail = new RoundedTextBox();
            btnLogin = new CustomRoundedButton();
            RegisterLink = new LinkLabel();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(151, 410);
            label4.Name = "label4";
            label4.Size = new Size(111, 32);
            label4.TabIndex = 11;
            label4.Text = "Password";
            // 
            // inputPassword
            // 
            inputPassword.BackColor = Color.White;
            inputPassword.BorderColor = Color.Gray;
            inputPassword.BorderRadius = 10;
            inputPassword.BorderSize = 2;
            inputPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPassword.Location = new Point(151, 454);
            inputPassword.Multiline = false;
            inputPassword.Name = "inputPassword";
            inputPassword.Padding = new Padding(10, 7, 10, 7);
            inputPassword.PasswordChar = true;
            inputPassword.PlaceholderText = "";
            inputPassword.Size = new Size(500, 57);
            inputPassword.TabIndex = 10;
            inputPassword.TextColor = SystemColors.WindowText;
            inputPassword.Load += inputPassword_Load;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(151, 255);
            label3.Name = "label3";
            label3.Size = new Size(214, 32);
            label3.TabIndex = 9;
            label3.Text = "Email or Username";
            // 
            // inputEmail
            // 
            inputEmail.BackColor = Color.White;
            inputEmail.BorderColor = Color.Gray;
            inputEmail.BorderRadius = 10;
            inputEmail.BorderSize = 2;
            inputEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputEmail.Location = new Point(151, 290);
            inputEmail.Multiline = false;
            inputEmail.Name = "inputEmail";
            inputEmail.Padding = new Padding(10, 7, 10, 7);
            inputEmail.PasswordChar = false;
            inputEmail.PlaceholderText = "";
            inputEmail.Size = new Size(500, 57);
            inputEmail.TabIndex = 8;
            inputEmail.TextColor = SystemColors.WindowText;
            inputEmail.Load += inputEmail_Load;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.CornflowerBlue;
            btnLogin.BorderColor = Color.Gray;
            btnLogin.BorderRadius = 20;
            btnLogin.BorderSize = 1;
            btnLogin.FillColor = Color.CornflowerBlue;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Tahoma", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Snow;
            btnLogin.HoverColor = Color.Empty;
            btnLogin.Location = new Point(266, 675);
            btnLogin.Name = "btnLogin";
            btnLogin.PressedColor = Color.Empty;
            btnLogin.Size = new Size(260, 116);
            btnLogin.TabIndex = 12;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // RegisterLink
            // 
            RegisterLink.AutoSize = true;
            RegisterLink.LinkColor = Color.FromArgb(128, 128, 255);
            RegisterLink.Location = new Point(291, 830);
            RegisterLink.Name = "RegisterLink";
            RegisterLink.Size = new Size(211, 32);
            RegisterLink.TabIndex = 13;
            RegisterLink.TabStop = true;
            RegisterLink.Text = "Hasn't Registered?";
            RegisterLink.LinkClicked += RegisterLink_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 1084);
            Controls.Add(RegisterLink);
            Controls.Add(btnLogin);
            Controls.Add(label4);
            Controls.Add(inputPassword);
            Controls.Add(label3);
            Controls.Add(inputEmail);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private RoundedTextBox inputPassword;
        private Label label3;
        private RoundedTextBox inputEmail;
        private CustomRoundedButton btnLogin;
        private LinkLabel RegisterLink;
    }
}