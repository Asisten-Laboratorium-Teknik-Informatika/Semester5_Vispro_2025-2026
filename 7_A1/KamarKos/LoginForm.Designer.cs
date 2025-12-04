namespace KamarKos
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            label5 = new Label();
            panelLogin = new Panel();
            lblRegister = new Label();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(234, 243, 250);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(349, 39);
            label1.Name = "label1";
            label1.Size = new Size(396, 48);
            label1.TabIndex = 0;
            label1.Text = "Login to Your Account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(234, 243, 250);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(354, 140);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 1;
            label2.Text = "Username :";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.Cursor = Cursors.Hand;
            txtUsername.ForeColor = Color.DarkBlue;
            txtUsername.Location = new Point(355, 168);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(390, 42);
            txtUsername.TabIndex = 3;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.ForeColor = Color.FromArgb(44, 62, 80);
            txtPassword.Location = new Point(358, 251);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(387, 45);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += textBox1_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(44, 62, 80);
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(234, 243, 250);
            btnLogin.Location = new Point(358, 335);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(387, 60);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.ForeColor = Color.FromArgb(234, 243, 250);
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.Location = new Point(747, 7);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(37, 38);
            btnExit.TabIndex = 6;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(234, 243, 250);
            label4.ForeColor = Color.FromArgb(107, 114, 128);
            label4.Location = new Point(354, 87);
            label4.Name = "label4";
            label4.Size = new Size(358, 25);
            label4.TabIndex = 7;
            label4.Text = "Look what happened to the boarding room";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(234, 243, 250);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(40, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(276, 311);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.FromArgb(234, 243, 250);
            checkBox1.ForeColor = Color.FromArgb(234, 243, 250);
            checkBox1.Location = new Point(360, 304);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(22, 21);
            checkBox1.TabIndex = 9;
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(234, 243, 250);
            label5.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(107, 114, 128);
            label5.Location = new Point(388, 307);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 10;
            label5.Text = "Remember Me";
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.FromArgb(234, 243, 250);
            panelLogin.Controls.Add(lblRegister);
            panelLogin.Controls.Add(label7);
            panelLogin.Controls.Add(label6);
            panelLogin.Controls.Add(btnExit);
            panelLogin.ForeColor = Color.FromArgb(234, 243, 250);
            panelLogin.Location = new Point(1, 1);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(799, 453);
            panelLogin.TabIndex = 11;
            panelLogin.Paint += panelLogin_Paint;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.BackColor = Color.FromArgb(234, 243, 250);
            lblRegister.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegister.ForeColor = Color.FromArgb(107, 114, 128);
            lblRegister.Location = new Point(634, 306);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(110, 15);
            lblRegister.TabIndex = 12;
            lblRegister.Text = "Already Registered?";
            lblRegister.Click += lblRegister_Click;
            lblRegister.MouseEnter += lblRegister_MouseEnter;
            lblRegister.MouseLeave += lblRegister_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(611, 134);
            label7.Name = "label7";
            label7.Size = new Size(0, 25);
            label7.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(212, 408);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 7;
            label6.Text = "label6";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(234, 243, 250);
            label3.ForeColor = Color.FromArgb(44, 62, 80);
            label3.Location = new Point(358, 223);
            label3.Name = "label3";
            label3.Size = new Size(96, 25);
            label3.TabIndex = 2;
            label3.Text = "Password :";
            label3.Click += label3_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label label4;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private Label label5;
        private Panel panelLogin;
        private Label label3;
        private Label label6;
        private Label lblRegister;
        private Label label7;
    }
}
