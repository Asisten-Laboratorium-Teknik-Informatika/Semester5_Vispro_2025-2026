namespace budgetplanner
{
    partial class Register
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
            inputNama = new RoundedTextBox();
            label1 = new Label();
            label2 = new Label();
            inputUsername = new RoundedTextBox();
            label3 = new Label();
            inputEmail = new RoundedTextBox();
            label4 = new Label();
            inputPassword = new RoundedTextBox();
            btnRegister = new CustomRoundedButton();
            LoginLink = new LinkLabel();
            SuspendLayout();
            // 
            // inputNama
            // 
            inputNama.BackColor = Color.White;
            inputNama.BorderColor = Color.Gray;
            inputNama.BorderRadius = 10;
            inputNama.BorderSize = 2;
            inputNama.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputNama.Location = new Point(134, 187);
            inputNama.Multiline = false;
            inputNama.Name = "inputNama";
            inputNama.Padding = new Padding(10, 7, 10, 7);
            inputNama.PasswordChar = false;
            inputNama.PlaceholderText = "";
            inputNama.Size = new Size(500, 57);
            inputNama.TabIndex = 0;
            inputNama.TextColor = SystemColors.WindowText;
            inputNama.Load += inputNama_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 143);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 300);
            label2.Name = "label2";
            label2.Size = new Size(121, 32);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // inputUsername
            // 
            inputUsername.BackColor = Color.White;
            inputUsername.BorderColor = Color.Gray;
            inputUsername.BorderRadius = 10;
            inputUsername.BorderSize = 2;
            inputUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputUsername.Location = new Point(134, 344);
            inputUsername.Multiline = false;
            inputUsername.Name = "inputUsername";
            inputUsername.Padding = new Padding(10, 7, 10, 7);
            inputUsername.PasswordChar = false;
            inputUsername.PlaceholderText = "";
            inputUsername.Size = new Size(500, 57);
            inputUsername.TabIndex = 2;
            inputUsername.TextColor = SystemColors.WindowText;
            inputUsername.Load += inputUsername_Load;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(134, 448);
            label3.Name = "label3";
            label3.Size = new Size(71, 32);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // inputEmail
            // 
            inputEmail.BackColor = Color.White;
            inputEmail.BorderColor = Color.Gray;
            inputEmail.BorderRadius = 10;
            inputEmail.BorderSize = 2;
            inputEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputEmail.Location = new Point(134, 492);
            inputEmail.Multiline = false;
            inputEmail.Name = "inputEmail";
            inputEmail.Padding = new Padding(10, 7, 10, 7);
            inputEmail.PasswordChar = false;
            inputEmail.PlaceholderText = "";
            inputEmail.Size = new Size(500, 57);
            inputEmail.TabIndex = 4;
            inputEmail.TextColor = SystemColors.WindowText;
            inputEmail.Load += inputEmail_Load;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 603);
            label4.Name = "label4";
            label4.Size = new Size(111, 32);
            label4.TabIndex = 7;
            label4.Text = "Password";
            // 
            // inputPassword
            // 
            inputPassword.BackColor = Color.White;
            inputPassword.BorderColor = Color.Gray;
            inputPassword.BorderRadius = 10;
            inputPassword.BorderSize = 2;
            inputPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPassword.Location = new Point(134, 647);
            inputPassword.Multiline = false;
            inputPassword.Name = "inputPassword";
            inputPassword.Padding = new Padding(10, 7, 10, 7);
            inputPassword.PasswordChar = true;
            inputPassword.PlaceholderText = "";
            inputPassword.Size = new Size(500, 57);
            inputPassword.TabIndex = 6;
            inputPassword.TextColor = SystemColors.WindowText;
            inputPassword.Load += inputPassword_Load;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.CornflowerBlue;
            btnRegister.BorderColor = Color.Gray;
            btnRegister.BorderRadius = 20;
            btnRegister.BorderSize = 1;
            btnRegister.FillColor = Color.CornflowerBlue;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Tahoma", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.Snow;
            btnRegister.HoverColor = Color.Empty;
            btnRegister.Location = new Point(246, 770);
            btnRegister.Name = "btnRegister";
            btnRegister.PressedColor = Color.Empty;
            btnRegister.Size = new Size(260, 116);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginLink
            // 
            LoginLink.AutoSize = true;
            LoginLink.LinkColor = Color.FromArgb(128, 128, 255);
            LoginLink.Location = new Point(267, 901);
            LoginLink.Name = "LoginLink";
            LoginLink.Size = new Size(224, 32);
            LoginLink.TabIndex = 9;
            LoginLink.TabStop = true;
            LoginLink.Text = "Already Registered?";
            LoginLink.LinkClicked += LoginLink_LinkClicked;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 1084);
            Controls.Add(LoginLink);
            Controls.Add(btnRegister);
            Controls.Add(label4);
            Controls.Add(inputPassword);
            Controls.Add(label3);
            Controls.Add(inputEmail);
            Controls.Add(label2);
            Controls.Add(inputUsername);
            Controls.Add(label1);
            Controls.Add(inputNama);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedTextBox inputNama;
        private Label label1;
        private Label label2;
        private RoundedTextBox inputUsername;
        private Label label3;
        private RoundedTextBox inputEmail;
        private Label label4;
        private RoundedTextBox inputPassword;
        private CustomRoundedButton btnRegister;
        private LinkLabel LoginLink;
    }
}