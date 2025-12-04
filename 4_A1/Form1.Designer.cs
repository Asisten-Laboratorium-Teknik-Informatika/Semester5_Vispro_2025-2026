namespace budgetplanner
{
    partial class Form1
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
            panelcontrol = new Panel();
            customRoundedButton1 = new CustomRoundedButton();
            customRoundedPanel1 = new CustomRoundedPanel();
            textBox3 = new TextBox();
            txtPengeluaran = new TextBox();
            txtPemasukan = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            Judul = new TextBox();
            customRoundedPanel3 = new CustomRoundedPanel();
            txtBoxSaran = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            panelNavbar = new Panel();
            btnGrafik = new Button();
            btnRiwayat = new Button();
            btnProfile = new Button();
            btnHome = new Button();
            panelcontrol.SuspendLayout();
            customRoundedPanel1.SuspendLayout();
            customRoundedPanel3.SuspendLayout();
            panelNavbar.SuspendLayout();
            SuspendLayout();
            // 
            // panelcontrol
            // 
            panelcontrol.AutoScroll = true;
            panelcontrol.Controls.Add(customRoundedButton1);
            panelcontrol.Controls.Add(customRoundedPanel1);
            panelcontrol.Controls.Add(Judul);
            panelcontrol.Controls.Add(customRoundedPanel3);
            panelcontrol.Dock = DockStyle.Fill;
            panelcontrol.Location = new Point(0, 0);
            panelcontrol.Name = "panelcontrol";
            panelcontrol.Size = new Size(797, 1084);
            panelcontrol.TabIndex = 8;
            panelcontrol.Paint += panelcontrol_Paint;
            // 
            // customRoundedButton1
            // 
            customRoundedButton1.BackColor = Color.Transparent;
            customRoundedButton1.BorderColor = Color.Gray;
            customRoundedButton1.BorderRadius = 55;
            customRoundedButton1.BorderSize = 0;
            customRoundedButton1.FillColor = Color.MediumSlateBlue;
            customRoundedButton1.FlatAppearance.BorderSize = 0;
            customRoundedButton1.FlatStyle = FlatStyle.Flat;
            customRoundedButton1.Font = new Font("Segoe UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customRoundedButton1.ForeColor = SystemColors.ControlLightLight;
            customRoundedButton1.HoverColor = Color.Empty;
            customRoundedButton1.Location = new Point(665, 846);
            customRoundedButton1.Name = "customRoundedButton1";
            customRoundedButton1.PressedColor = Color.Empty;
            customRoundedButton1.Size = new Size(120, 120);
            customRoundedButton1.TabIndex = 9;
            customRoundedButton1.Text = "+";
            customRoundedButton1.UseVisualStyleBackColor = false;
            customRoundedButton1.Click += customRoundedButton1_Click;
            // 
            // customRoundedPanel1
            // 
            customRoundedPanel1.BorderColor = SystemColors.ControlLightLight;
            customRoundedPanel1.BorderRadius = 20;
            customRoundedPanel1.BorderThickness = 2;
            customRoundedPanel1.Controls.Add(textBox3);
            customRoundedPanel1.Controls.Add(txtPengeluaran);
            customRoundedPanel1.Controls.Add(txtPemasukan);
            customRoundedPanel1.Controls.Add(textBox2);
            customRoundedPanel1.Controls.Add(textBox1);
            customRoundedPanel1.FillColor = Color.White;
            customRoundedPanel1.Location = new Point(50, 142);
            customRoundedPanel1.Name = "customRoundedPanel1";
            customRoundedPanel1.Size = new Size(612, 519);
            customRoundedPanel1.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(37, 19);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(523, 39);
            textBox3.TabIndex = 4;
            textBox3.Text = "Pemasukan dan Pengeluaran Saat ini";
            // 
            // txtPengeluaran
            // 
            txtPengeluaran.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPengeluaran.Location = new Point(54, 360);
            txtPengeluaran.Name = "txtPengeluaran";
            txtPengeluaran.ReadOnly = true;
            txtPengeluaran.Size = new Size(493, 71);
            txtPengeluaran.TabIndex = 3;
            // 
            // txtPemasukan
            // 
            txtPemasukan.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPemasukan.Location = new Point(54, 168);
            txtPemasukan.Name = "txtPemasukan";
            txtPemasukan.ReadOnly = true;
            txtPemasukan.Size = new Size(493, 71);
            txtPemasukan.TabIndex = 2;
            txtPemasukan.TextChanged += txtPemasukan_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(54, 290);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 32);
            textBox2.TabIndex = 1;
            textBox2.Text = "Pengeluaran";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(54, 115);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 32);
            textBox1.TabIndex = 0;
            textBox1.Text = "Pemasukan";
            // 
            // Judul
            // 
            Judul.BackColor = SystemColors.Control;
            Judul.BorderStyle = BorderStyle.None;
            Judul.Font = new Font("Verdana", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Judul.Location = new Point(50, 20);
            Judul.Name = "Judul";
            Judul.ReadOnly = true;
            Judul.Size = new Size(491, 45);
            Judul.TabIndex = 5;
            Judul.Text = "Smart Budget Planner";
            // 
            // customRoundedPanel3
            // 
            customRoundedPanel3.BorderColor = SystemColors.ControlLightLight;
            customRoundedPanel3.BorderRadius = 20;
            customRoundedPanel3.BorderThickness = 2;
            customRoundedPanel3.Controls.Add(txtBoxSaran);
            customRoundedPanel3.Controls.Add(textBox6);
            customRoundedPanel3.Controls.Add(textBox5);
            customRoundedPanel3.FillColor = Color.BurlyWood;
            customRoundedPanel3.Location = new Point(50, 689);
            customRoundedPanel3.Name = "customRoundedPanel3";
            customRoundedPanel3.Size = new Size(618, 302);
            customRoundedPanel3.TabIndex = 8;
            // 
            // txtBoxSaran
            // 
            txtBoxSaran.BackColor = Color.BurlyWood;
            txtBoxSaran.BorderStyle = BorderStyle.None;
            txtBoxSaran.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxSaran.Location = new Point(125, 84);
            txtBoxSaran.Multiline = true;
            txtBoxSaran.Name = "txtBoxSaran";
            txtBoxSaran.ReadOnly = true;
            txtBoxSaran.Size = new Size(455, 193);
            txtBoxSaran.TabIndex = 2;
            txtBoxSaran.TextChanged += txtBoxSaran_TextChanged;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.BurlyWood;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(125, 26);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(200, 32);
            textBox6.TabIndex = 1;
            textBox6.Text = "Saran Otomatis";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.BurlyWood;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(37, 26);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(68, 58);
            textBox5.TabIndex = 0;
            textBox5.Text = "💡";
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
            panelNavbar.TabIndex = 9;
            // 
            // btnGrafik
            // 
            btnGrafik.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnGrafik.FlatAppearance.BorderSize = 0;
            btnGrafik.FlatStyle = FlatStyle.Flat;
            btnGrafik.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGrafik.Location = new Point(257, 21);
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
            btnRiwayat.Location = new Point(476, 21);
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
            btnProfile.Click += btnProfile_Click;
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
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(797, 1084);
            Controls.Add(panelNavbar);
            Controls.Add(panelcontrol);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panelcontrol.ResumeLayout(false);
            panelcontrol.PerformLayout();
            customRoundedPanel1.ResumeLayout(false);
            customRoundedPanel1.PerformLayout();
            customRoundedPanel3.ResumeLayout(false);
            customRoundedPanel3.PerformLayout();
            panelNavbar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelcontrol;
        private CustomRoundedPanel customRoundedPanel1;
        private TextBox textBox3;
        private TextBox txtPengeluaran;
        private TextBox txtPemasukan;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox Judul;
        private CustomRoundedPanel customRoundedPanel3;
        private TextBox txtBoxSaran;
        private TextBox textBox6;
        private TextBox textBox5;
        private Panel panelNavbar;
        private Button btnGrafik;
        private Button btnRiwayat;
        private Button btnProfile;
        private Button btnHome;
        private CustomRoundedButton customRoundedButton1;
    }
}
