namespace budgetplanner
{
    partial class Form5
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
            panelNavbar = new Panel();
            btnGrafik = new Button();
            btnRiwayat = new Button();
            btnProfile = new Button();
            btnHome = new Button();
            TextBoxNama = new RoundedTextBox();
            label1 = new Label();
            label2 = new Label();
            TextBoxEmail = new RoundedTextBox();
            label3 = new Label();
            TextBoxUsername = new RoundedTextBox();
            TombolEdit = new CustomRoundedButton();
            TombolLogout = new CustomRoundedButton();
            label4 = new Label();
            label5 = new Label();
            panelNavbar.SuspendLayout();
            SuspendLayout();
            // 
            // panelNavbar
            // 
            panelNavbar.BackColor = SystemColors.ControlLightLight;
            panelNavbar.Controls.Add(btnGrafik);
            panelNavbar.Controls.Add(btnRiwayat);
            panelNavbar.Controls.Add(btnProfile);
            panelNavbar.Controls.Add(btnHome);
            panelNavbar.Dock = DockStyle.Bottom;
            panelNavbar.Location = new Point(0, 986);
            panelNavbar.Name = "panelNavbar";
            panelNavbar.Size = new Size(797, 98);
            panelNavbar.TabIndex = 11;
            // 
            // btnGrafik
            // 
            btnGrafik.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnGrafik.FlatAppearance.BorderSize = 0;
            btnGrafik.FlatStyle = FlatStyle.Flat;
            btnGrafik.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGrafik.Location = new Point(251, 20);
            btnGrafik.Name = "btnGrafik";
            btnGrafik.Size = new Size(65, 65);
            btnGrafik.TabIndex = 4;
            btnGrafik.Text = "📊";
            btnGrafik.UseVisualStyleBackColor = true;
            btnGrafik.Click += btnGrafik_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(471, 20);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(65, 65);
            btnRiwayat.TabIndex = 3;
            btnRiwayat.Text = "💰";
            btnRiwayat.UseVisualStyleBackColor = true;
            btnRiwayat.Click += btnRiwayat_Click;
            // 
            // btnProfile
            // 
            btnProfile.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProfile.Location = new Point(692, 20);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(65, 65);
            btnProfile.TabIndex = 1;
            btnProfile.Text = "👤";
            btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(42, 20);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(65, 65);
            btnHome.TabIndex = 0;
            btnHome.Text = "🏠";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // TextBoxNama
            // 
            TextBoxNama.BackColor = Color.White;
            TextBoxNama.BorderColor = Color.Gray;
            TextBoxNama.BorderRadius = 10;
            TextBoxNama.BorderSize = 2;
            TextBoxNama.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBoxNama.Location = new Point(115, 278);
            TextBoxNama.Multiline = false;
            TextBoxNama.Name = "TextBoxNama";
            TextBoxNama.Padding = new Padding(10, 7, 10, 7);
            TextBoxNama.PasswordChar = false;
            TextBoxNama.PlaceholderText = "";
            TextBoxNama.Size = new Size(547, 72);
            TextBoxNama.TabIndex = 12;
            TextBoxNama.TextColor = SystemColors.WindowText;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(115, 231);
            label1.Name = "label1";
            label1.Size = new Size(77, 32);
            label1.TabIndex = 13;
            label1.Text = "Nama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 406);
            label2.Name = "label2";
            label2.Size = new Size(71, 32);
            label2.TabIndex = 15;
            label2.Text = "Email";
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.BackColor = Color.White;
            TextBoxEmail.BorderColor = Color.Gray;
            TextBoxEmail.BorderRadius = 10;
            TextBoxEmail.BorderSize = 2;
            TextBoxEmail.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBoxEmail.Location = new Point(115, 453);
            TextBoxEmail.Multiline = false;
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Padding = new Padding(10, 7, 10, 7);
            TextBoxEmail.PasswordChar = false;
            TextBoxEmail.PlaceholderText = "";
            TextBoxEmail.Size = new Size(547, 72);
            TextBoxEmail.TabIndex = 14;
            TextBoxEmail.TextColor = SystemColors.WindowText;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 586);
            label3.Name = "label3";
            label3.Size = new Size(121, 32);
            label3.TabIndex = 17;
            label3.Text = "Username";
            // 
            // TextBoxUsername
            // 
            TextBoxUsername.BackColor = Color.White;
            TextBoxUsername.BorderColor = Color.Gray;
            TextBoxUsername.BorderRadius = 10;
            TextBoxUsername.BorderSize = 2;
            TextBoxUsername.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBoxUsername.Location = new Point(115, 633);
            TextBoxUsername.Multiline = false;
            TextBoxUsername.Name = "TextBoxUsername";
            TextBoxUsername.Padding = new Padding(10, 7, 10, 7);
            TextBoxUsername.PasswordChar = false;
            TextBoxUsername.PlaceholderText = "";
            TextBoxUsername.Size = new Size(547, 72);
            TextBoxUsername.TabIndex = 16;
            TextBoxUsername.TextColor = SystemColors.WindowText;
            // 
            // TombolEdit
            // 
            TombolEdit.BackColor = Color.DimGray;
            TombolEdit.BorderColor = Color.White;
            TombolEdit.BorderRadius = 20;
            TombolEdit.BorderSize = 1;
            TombolEdit.FillColor = Color.Wheat;
            TombolEdit.FlatAppearance.BorderSize = 0;
            TombolEdit.FlatStyle = FlatStyle.Flat;
            TombolEdit.Font = new Font("Nirmala UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TombolEdit.HoverColor = Color.Empty;
            TombolEdit.Location = new Point(267, 748);
            TombolEdit.Name = "TombolEdit";
            TombolEdit.PressedColor = Color.Empty;
            TombolEdit.Size = new Size(227, 83);
            TombolEdit.TabIndex = 18;
            TombolEdit.Text = "Edit Data";
            TombolEdit.UseVisualStyleBackColor = false;
            TombolEdit.Click += TombolEdit_Click;
            // 
            // TombolLogout
            // 
            TombolLogout.BackColor = Color.DimGray;
            TombolLogout.BorderColor = Color.Gray;
            TombolLogout.BorderRadius = 20;
            TombolLogout.BorderSize = 1;
            TombolLogout.FillColor = Color.Crimson;
            TombolLogout.FlatAppearance.BorderSize = 0;
            TombolLogout.FlatStyle = FlatStyle.Flat;
            TombolLogout.Font = new Font("Nirmala UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TombolLogout.ForeColor = SystemColors.ButtonHighlight;
            TombolLogout.HoverColor = Color.Empty;
            TombolLogout.Location = new Point(267, 888);
            TombolLogout.Name = "TombolLogout";
            TombolLogout.PressedColor = Color.Empty;
            TombolLogout.Size = new Size(227, 83);
            TombolLogout.TabIndex = 19;
            TombolLogout.Text = "Logout";
            TombolLogout.UseVisualStyleBackColor = false;
            TombolLogout.Click += TombolLogout_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(192, 61);
            label4.Name = "label4";
            label4.Size = new Size(392, 128);
            label4.TabIndex = 20;
            label4.Text = "PROFIL";
            // 
            // label5
            // 
            label5.Image = Properties.Resources.Screenshot_2025_11_19_193641;
            label5.Location = new Point(14, 29);
            label5.Name = "label5";
            label5.Size = new Size(178, 139);
            label5.TabIndex = 21;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 1084);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TombolLogout);
            Controls.Add(TombolEdit);
            Controls.Add(label3);
            Controls.Add(TextBoxUsername);
            Controls.Add(label2);
            Controls.Add(TextBoxEmail);
            Controls.Add(label1);
            Controls.Add(TextBoxNama);
            Controls.Add(panelNavbar);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form5";
            panelNavbar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelNavbar;
        private Button btnGrafik;
        private Button btnRiwayat;
        private Button btnProfile;
        private Button btnHome;
        private RoundedTextBox TextBoxNama;
        private Label label1;
        private Label label2;
        private RoundedTextBox TextBoxEmail;
        private Label label3;
        private RoundedTextBox TextBoxUsername;
        private CustomRoundedButton TombolEdit;
        private CustomRoundedButton TombolLogout;
        private Label label4;
        private Label label5;
    }
}