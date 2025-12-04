namespace budgetplanner
{
    partial class Form3
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
            pnlPengeluaranTerakhir = new Panel();
            customRoundedPanel6 = new CustomRoundedPanel();
            JumlahLainnya = new TextBox();
            textBox9 = new TextBox();
            customRoundedPanel5 = new CustomRoundedPanel();
            JumlahTransportasi = new TextBox();
            textBox8 = new TextBox();
            customRoundedPanel4 = new CustomRoundedPanel();
            JumlahBelanja = new TextBox();
            textBox7 = new TextBox();
            customRoundedPanel3 = new CustomRoundedPanel();
            TotalHiburan = new TextBox();
            textBox6 = new TextBox();
            customRoundedPanel2 = new CustomRoundedPanel();
            TotalMakanan = new TextBox();
            textBox3 = new TextBox();
            customRoundedPanel1 = new CustomRoundedPanel();
            RataRataPengeluaran = new TextBox();
            KategoriTerbanyak = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            TotalPengeluaran = new Label();
            textBox1 = new TextBox();
            panelNavbar.SuspendLayout();
            pnlPengeluaranTerakhir.SuspendLayout();
            customRoundedPanel6.SuspendLayout();
            customRoundedPanel5.SuspendLayout();
            customRoundedPanel4.SuspendLayout();
            customRoundedPanel3.SuspendLayout();
            customRoundedPanel2.SuspendLayout();
            customRoundedPanel1.SuspendLayout();
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
            btnGrafik.Location = new Point(256, 20);
            btnGrafik.Name = "btnGrafik";
            btnGrafik.Size = new Size(65, 65);
            btnGrafik.TabIndex = 4;
            btnGrafik.Text = "📊";
            btnGrafik.UseVisualStyleBackColor = true;
            // 
            // btnRiwayat
            // 
            btnRiwayat.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(484, 20);
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
            btnHome.Click += btnHome_Click;
            // 
            // pnlPengeluaranTerakhir
            // 
            pnlPengeluaranTerakhir.Controls.Add(customRoundedPanel6);
            pnlPengeluaranTerakhir.Controls.Add(customRoundedPanel5);
            pnlPengeluaranTerakhir.Controls.Add(customRoundedPanel4);
            pnlPengeluaranTerakhir.Controls.Add(customRoundedPanel3);
            pnlPengeluaranTerakhir.Controls.Add(customRoundedPanel2);
            pnlPengeluaranTerakhir.Controls.Add(customRoundedPanel1);
            pnlPengeluaranTerakhir.Dock = DockStyle.Fill;
            pnlPengeluaranTerakhir.Location = new Point(0, 0);
            pnlPengeluaranTerakhir.Name = "pnlPengeluaranTerakhir";
            pnlPengeluaranTerakhir.Size = new Size(797, 986);
            pnlPengeluaranTerakhir.TabIndex = 12;
            // 
            // customRoundedPanel6
            // 
            customRoundedPanel6.BorderColor = Color.Gray;
            customRoundedPanel6.BorderRadius = 20;
            customRoundedPanel6.BorderThickness = 2;
            customRoundedPanel6.Controls.Add(JumlahLainnya);
            customRoundedPanel6.Controls.Add(textBox9);
            customRoundedPanel6.FillColor = Color.White;
            customRoundedPanel6.Location = new Point(120, 813);
            customRoundedPanel6.Name = "customRoundedPanel6";
            customRoundedPanel6.Size = new Size(515, 125);
            customRoundedPanel6.TabIndex = 18;
            // 
            // JumlahLainnya
            // 
            JumlahLainnya.BorderStyle = BorderStyle.None;
            JumlahLainnya.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JumlahLainnya.Location = new Point(301, 47);
            JumlahLainnya.Name = "JumlahLainnya";
            JumlahLainnya.PlaceholderText = "Jumlah";
            JumlahLainnya.Size = new Size(200, 32);
            JumlahLainnya.TabIndex = 2;
            JumlahLainnya.TextChanged += JumlahLainnya_TextChanged;
            // 
            // textBox9
            // 
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox9.Location = new Point(14, 19);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(200, 32);
            textBox9.TabIndex = 0;
            textBox9.Text = "Lainnya";
            // 
            // customRoundedPanel5
            // 
            customRoundedPanel5.BorderColor = Color.Gray;
            customRoundedPanel5.BorderRadius = 20;
            customRoundedPanel5.BorderThickness = 2;
            customRoundedPanel5.Controls.Add(JumlahTransportasi);
            customRoundedPanel5.Controls.Add(textBox8);
            customRoundedPanel5.FillColor = Color.White;
            customRoundedPanel5.Location = new Point(120, 682);
            customRoundedPanel5.Name = "customRoundedPanel5";
            customRoundedPanel5.Size = new Size(515, 125);
            customRoundedPanel5.TabIndex = 17;
            // 
            // JumlahTransportasi
            // 
            JumlahTransportasi.BorderStyle = BorderStyle.None;
            JumlahTransportasi.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JumlahTransportasi.Location = new Point(301, 47);
            JumlahTransportasi.Name = "JumlahTransportasi";
            JumlahTransportasi.PlaceholderText = "Jumlah";
            JumlahTransportasi.Size = new Size(200, 32);
            JumlahTransportasi.TabIndex = 2;
            JumlahTransportasi.TextChanged += JumlahTransportasi_TextChanged;
            // 
            // textBox8
            // 
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox8.Location = new Point(14, 19);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(200, 32);
            textBox8.TabIndex = 0;
            textBox8.Text = "Transportasi";
            // 
            // customRoundedPanel4
            // 
            customRoundedPanel4.BorderColor = Color.Gray;
            customRoundedPanel4.BorderRadius = 20;
            customRoundedPanel4.BorderThickness = 2;
            customRoundedPanel4.Controls.Add(JumlahBelanja);
            customRoundedPanel4.Controls.Add(textBox7);
            customRoundedPanel4.FillColor = Color.White;
            customRoundedPanel4.Location = new Point(120, 551);
            customRoundedPanel4.Name = "customRoundedPanel4";
            customRoundedPanel4.Size = new Size(515, 125);
            customRoundedPanel4.TabIndex = 16;
            // 
            // JumlahBelanja
            // 
            JumlahBelanja.BorderStyle = BorderStyle.None;
            JumlahBelanja.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JumlahBelanja.Location = new Point(301, 47);
            JumlahBelanja.Name = "JumlahBelanja";
            JumlahBelanja.PlaceholderText = "Jumlah";
            JumlahBelanja.Size = new Size(200, 32);
            JumlahBelanja.TabIndex = 2;
            JumlahBelanja.TextChanged += JumlahBelanja_TextChanged;
            // 
            // textBox7
            // 
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox7.Location = new Point(14, 19);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(200, 32);
            textBox7.TabIndex = 0;
            textBox7.Text = "Belanja";
            // 
            // customRoundedPanel3
            // 
            customRoundedPanel3.BorderColor = Color.Gray;
            customRoundedPanel3.BorderRadius = 20;
            customRoundedPanel3.BorderThickness = 2;
            customRoundedPanel3.Controls.Add(TotalHiburan);
            customRoundedPanel3.Controls.Add(textBox6);
            customRoundedPanel3.FillColor = Color.White;
            customRoundedPanel3.Location = new Point(120, 420);
            customRoundedPanel3.Name = "customRoundedPanel3";
            customRoundedPanel3.Size = new Size(515, 125);
            customRoundedPanel3.TabIndex = 15;
            // 
            // TotalHiburan
            // 
            TotalHiburan.BorderStyle = BorderStyle.None;
            TotalHiburan.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalHiburan.Location = new Point(301, 47);
            TotalHiburan.Name = "TotalHiburan";
            TotalHiburan.PlaceholderText = "Jumlah";
            TotalHiburan.Size = new Size(200, 32);
            TotalHiburan.TabIndex = 2;
            TotalHiburan.TextChanged += TotalHiburan_TextChanged;
            // 
            // textBox6
            // 
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(14, 19);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(200, 32);
            textBox6.TabIndex = 0;
            textBox6.Text = "Hiburan";
            // 
            // customRoundedPanel2
            // 
            customRoundedPanel2.BorderColor = Color.Gray;
            customRoundedPanel2.BorderRadius = 20;
            customRoundedPanel2.BorderThickness = 2;
            customRoundedPanel2.Controls.Add(TotalMakanan);
            customRoundedPanel2.Controls.Add(textBox3);
            customRoundedPanel2.FillColor = Color.White;
            customRoundedPanel2.Location = new Point(120, 289);
            customRoundedPanel2.Name = "customRoundedPanel2";
            customRoundedPanel2.Size = new Size(515, 125);
            customRoundedPanel2.TabIndex = 14;
            // 
            // TotalMakanan
            // 
            TotalMakanan.BorderStyle = BorderStyle.None;
            TotalMakanan.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalMakanan.Location = new Point(301, 47);
            TotalMakanan.Name = "TotalMakanan";
            TotalMakanan.PlaceholderText = "Jumlah";
            TotalMakanan.Size = new Size(200, 32);
            TotalMakanan.TabIndex = 2;
            TotalMakanan.TextChanged += TotalMakanan_TextChanged;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(14, 19);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 32);
            textBox3.TabIndex = 0;
            textBox3.Text = "Makan dan Minum";
            // 
            // customRoundedPanel1
            // 
            customRoundedPanel1.BackColor = Color.Cyan;
            customRoundedPanel1.BorderColor = Color.Gray;
            customRoundedPanel1.BorderRadius = 20;
            customRoundedPanel1.BorderThickness = 0;
            customRoundedPanel1.Controls.Add(RataRataPengeluaran);
            customRoundedPanel1.Controls.Add(KategoriTerbanyak);
            customRoundedPanel1.Controls.Add(textBox5);
            customRoundedPanel1.Controls.Add(textBox4);
            customRoundedPanel1.Controls.Add(TotalPengeluaran);
            customRoundedPanel1.Controls.Add(textBox1);
            customRoundedPanel1.FillColor = Color.LightSkyBlue;
            customRoundedPanel1.Location = new Point(42, 43);
            customRoundedPanel1.Name = "customRoundedPanel1";
            customRoundedPanel1.Size = new Size(715, 240);
            customRoundedPanel1.TabIndex = 13;
            // 
            // RataRataPengeluaran
            // 
            RataRataPengeluaran.BackColor = Color.LightSkyBlue;
            RataRataPengeluaran.BorderStyle = BorderStyle.None;
            RataRataPengeluaran.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RataRataPengeluaran.Location = new Point(249, 188);
            RataRataPengeluaran.Name = "RataRataPengeluaran";
            RataRataPengeluaran.Size = new Size(391, 28);
            RataRataPengeluaran.TabIndex = 7;
            RataRataPengeluaran.TextChanged += RataRataPengeluaran_TextChanged;
            // 
            // KategoriTerbanyak
            // 
            KategoriTerbanyak.BackColor = Color.LightSkyBlue;
            KategoriTerbanyak.BorderStyle = BorderStyle.None;
            KategoriTerbanyak.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            KategoriTerbanyak.Location = new Point(249, 154);
            KategoriTerbanyak.Name = "KategoriTerbanyak";
            KategoriTerbanyak.Size = new Size(391, 28);
            KategoriTerbanyak.TabIndex = 6;
            KategoriTerbanyak.TextChanged += KategoriTerbanyak_TextChanged;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.LightSkyBlue;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(25, 188);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(218, 28);
            textBox5.TabIndex = 5;
            textBox5.Text = "Rata-Rata Pengeluaran:";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.LightSkyBlue;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(25, 154);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(218, 28);
            textBox4.TabIndex = 4;
            textBox4.Text = "Kategori Terbanyak:";
            // 
            // TotalPengeluaran
            // 
            TotalPengeluaran.BackColor = Color.LightSkyBlue;
            TotalPengeluaran.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalPengeluaran.Location = new Point(53, 83);
            TotalPengeluaran.Name = "TotalPengeluaran";
            TotalPengeluaran.Size = new Size(595, 57);
            TotalPengeluaran.TabIndex = 1;
            TotalPengeluaran.TextChanged += TotalPengeluaran_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightSkyBlue;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(270, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 32);
            textBox1.TabIndex = 0;
            textBox1.Text = "Total Pengeluaran";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(797, 1084);
            Controls.Add(pnlPengeluaranTerakhir);
            Controls.Add(panelNavbar);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            panelNavbar.ResumeLayout(false);
            pnlPengeluaranTerakhir.ResumeLayout(false);
            customRoundedPanel6.ResumeLayout(false);
            customRoundedPanel6.PerformLayout();
            customRoundedPanel5.ResumeLayout(false);
            customRoundedPanel5.PerformLayout();
            customRoundedPanel4.ResumeLayout(false);
            customRoundedPanel4.PerformLayout();
            customRoundedPanel3.ResumeLayout(false);
            customRoundedPanel3.PerformLayout();
            customRoundedPanel2.ResumeLayout(false);
            customRoundedPanel2.PerformLayout();
            customRoundedPanel1.ResumeLayout(false);
            customRoundedPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelNavbar;
        private Button btnGrafik;
        private Button btnRiwayat;
        private Button btnProfile;
        private Button btnHome;
        private Panel pnlPengeluaranTerakhir;
        private CustomRoundedPanel customRoundedPanel1;
        private Label TotalPengeluaran;
        private TextBox textBox1;
        private CustomRoundedPanel customRoundedPanel2;
        private TextBox textBox3;
        private TextBox TotalMakanan;
        private CustomRoundedPanel customRoundedPanel3;
        private TextBox TotalHiburan;
        private TextBox textBox6;
        private CustomRoundedPanel customRoundedPanel4;
        private TextBox JumlahBelanja;
        private TextBox textBox7;
        private CustomRoundedPanel customRoundedPanel6;
        private TextBox JumlahLainnya;
        private TextBox textBox9;
        private CustomRoundedPanel customRoundedPanel5;
        private TextBox JumlahTransportasi;
        private TextBox textBox8;
        private TextBox RataRataPengeluaran;
        private TextBox KategoriTerbanyak;
        private TextBox textBox5;
        private TextBox textBox4;
    }
}