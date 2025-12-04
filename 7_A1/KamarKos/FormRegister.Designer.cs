namespace KamarKos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            label4 = new Label();
            btnRegister = new Button();
            btnBack = new Button();
            panel1 = new Panel();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(234, 243, 250);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(321, 107);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 5;
            label2.Text = "Username :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(611, 82);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(234, 243, 250);
            label3.ForeColor = Color.FromArgb(44, 62, 80);
            label3.Location = new Point(321, 192);
            label3.Name = "label3";
            label3.Size = new Size(96, 25);
            label3.TabIndex = 7;
            label3.Text = "Password :";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.Cursor = Cursors.Hand;
            txtUsername.ForeColor = Color.DarkBlue;
            txtUsername.Location = new Point(321, 135);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(390, 42);
            txtUsername.TabIndex = 8;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Cursor = Cursors.Hand;
            txtPassword.ForeColor = Color.DarkBlue;
            txtPassword.Location = new Point(321, 220);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(390, 42);
            txtPassword.TabIndex = 9;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.White;
            txtConfirmPassword.Cursor = Cursors.Hand;
            txtConfirmPassword.ForeColor = Color.DarkBlue;
            txtConfirmPassword.Location = new Point(321, 302);
            txtConfirmPassword.Multiline = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(390, 42);
            txtConfirmPassword.TabIndex = 11;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(234, 243, 250);
            label4.ForeColor = Color.FromArgb(44, 62, 80);
            label4.Location = new Point(321, 274);
            label4.Name = "label4";
            label4.Size = new Size(165, 25);
            label4.TabIndex = 10;
            label4.Text = "Confirm Password :";
            label4.Click += label4_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(44, 62, 80);
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.FromArgb(234, 243, 250);
            btnRegister.Location = new Point(202, 371);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(387, 60);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(30, 34);
            btnBack.TabIndex = 18;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(234, 243, 250);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(1, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 469);
            panel1.TabIndex = 19;
            panel1.Paint += panel1_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(234, 243, 250);
            label6.ForeColor = Color.FromArgb(107, 114, 128);
            label6.Location = new Point(426, 76);
            label6.Name = "label6";
            label6.Size = new Size(219, 25);
            label6.TabIndex = 21;
            label6.Text = "Create Your Account Here!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._20251203_170735_00001;
            pictureBox1.Location = new Point(36, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(275, 278);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(234, 243, 250);
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(44, 62, 80);
            label5.Location = new Point(317, 28);
            label5.Name = "label5";
            label5.Size = new Size(439, 48);
            label5.TabIndex = 13;
            label5.Text = "Register to Your Account";
            label5.Click += label5_Click;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegister";
            Load += FormRegister_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Label label4;
        private Button btnRegister;
        private Button btnBack;
        private Panel panel1;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
    }
}