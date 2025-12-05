namespace PawLodge
{
    partial class UC_Settings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblNamaToko = new System.Windows.Forms.Label();
            this.txtNamaToko = new System.Windows.Forms.TextBox();
            this.lblTema = new System.Windows.Forms.Label();
            this.comboTema = new System.Windows.Forms.ComboBox();
            this.btnTerapkanTema = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnPilihLogo = new System.Windows.Forms.Button();
            this.lblKeamanan = new System.Windows.Forms.Label();
            this.lblPassLama = new System.Windows.Forms.Label();
            this.txtPassLama = new System.Windows.Forms.TextBox();
            this.lblPassBaru = new System.Windows.Forms.Label();
            this.txtPassBaru = new System.Windows.Forms.TextBox();
            this.lblKonfirmasi = new System.Windows.Forms.Label();
            this.txtKonfirmasi = new System.Windows.Forms.TextBox();
            this.btnUbahPassword = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // lblJudul
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblJudul.ForeColor = System.Drawing.Color.HotPink;
            this.lblJudul.Location = new System.Drawing.Point(50, 40);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(447, 54);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "Pengaturan PawLodge";

            // lblNamaToko
            this.lblNamaToko.Location = new System.Drawing.Point(50, 130);
            this.lblNamaToko.Name = "lblNamaToko";
            this.lblNamaToko.Size = new System.Drawing.Size(120, 23);
            this.lblNamaToko.TabIndex = 1;
            this.lblNamaToko.Text = "Nama Toko:";

            // txtNamaToko
            this.txtNamaToko.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNamaToko.Location = new System.Drawing.Point(50, 160);
            this.txtNamaToko.Name = "txtNamaToko";
            this.txtNamaToko.Size = new System.Drawing.Size(420, 32);
            this.txtNamaToko.TabIndex = 2;

            // lblTema
            this.lblTema.Location = new System.Drawing.Point(50, 220);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(150, 23);
            this.lblTema.TabIndex = 3;
            this.lblTema.Text = "Tema Warna:";

            // comboTema
            this.comboTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTema.Location = new System.Drawing.Point(50, 250);
            this.comboTema.Name = "comboTema";
            this.comboTema.Size = new System.Drawing.Size(300, 24);
            this.comboTema.TabIndex = 4;

            // btnTerapkanTema
            this.btnTerapkanTema.BackColor = System.Drawing.Color.HotPink;
            this.btnTerapkanTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerapkanTema.ForeColor = System.Drawing.Color.White;
            this.btnTerapkanTema.Location = new System.Drawing.Point(370, 245);
            this.btnTerapkanTema.Name = "btnTerapkanTema";
            this.btnTerapkanTema.Size = new System.Drawing.Size(180, 35);
            this.btnTerapkanTema.TabIndex = 5;
            this.btnTerapkanTema.Text = "Terapkan Tema";
            this.btnTerapkanTema.UseVisualStyleBackColor = false;
            this.btnTerapkanTema.Click += new System.EventHandler(this.btnTerapkanTema_Click);

            // lblLogo
            this.lblLogo.Location = new System.Drawing.Point(50, 330);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(120, 23);
            this.lblLogo.TabIndex = 6;
            this.lblLogo.Text = "Logo Toko:";

            // picLogo
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(50, 360);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;

            // btnPilihLogo
            this.btnPilihLogo.BackColor = System.Drawing.Color.LightPink;
            this.btnPilihLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPilihLogo.Location = new System.Drawing.Point(50, 580);
            this.btnPilihLogo.Name = "btnPilihLogo";
            this.btnPilihLogo.Size = new System.Drawing.Size(200, 45);
            this.btnPilihLogo.TabIndex = 8;
            this.btnPilihLogo.Text = "Ganti Logo...";
            this.btnPilihLogo.UseVisualStyleBackColor = false;
            this.btnPilihLogo.Click += new System.EventHandler(this.btnPilihLogo_Click);

            // lblKeamanan
            this.lblKeamanan.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKeamanan.ForeColor = System.Drawing.Color.Crimson;
            this.lblKeamanan.Location = new System.Drawing.Point(600, 130);
            this.lblKeamanan.Name = "lblKeamanan";
            this.lblKeamanan.Size = new System.Drawing.Size(200, 34);
            this.lblKeamanan.TabIndex = 9;
            this.lblKeamanan.Text = "Keamanan Akun";

            // lblPassLama
            this.lblPassLama.Location = new System.Drawing.Point(600, 190);
            this.lblPassLama.Name = "lblPassLama";
            this.lblPassLama.Size = new System.Drawing.Size(150, 23);
            this.lblPassLama.TabIndex = 10;
            this.lblPassLama.Text = "Password Lama:";

            // txtPassLama
            this.txtPassLama.Location = new System.Drawing.Point(600, 220);
            this.txtPassLama.Name = "txtPassLama";
            this.txtPassLama.UseSystemPasswordChar = true;
            this.txtPassLama.Size = new System.Drawing.Size(320, 22);
            this.txtPassLama.TabIndex = 11;

            // lblPassBaru
            this.lblPassBaru.Location = new System.Drawing.Point(600, 270);
            this.lblPassBaru.Name = "lblPassBaru";
            this.lblPassBaru.Size = new System.Drawing.Size(150, 23);
            this.lblPassBaru.TabIndex = 12;
            this.lblPassBaru.Text = "Password Baru:";

            // txtPassBaru
            this.txtPassBaru.Location = new System.Drawing.Point(600, 300);
            this.txtPassBaru.Name = "txtPassBaru";
            this.txtPassBaru.UseSystemPasswordChar = true;
            this.txtPassBaru.Size = new System.Drawing.Size(320, 22);
            this.txtPassBaru.TabIndex = 13;

            // lblKonfirmasi
            this.lblKonfirmasi.Location = new System.Drawing.Point(600, 350);
            this.lblKonfirmasi.Name = "lblKonfirmasi";
            this.lblKonfirmasi.Size = new System.Drawing.Size(150, 23);
            this.lblKonfirmasi.TabIndex = 14;
            this.lblKonfirmasi.Text = "Konfirmasi:";

            // txtKonfirmasi
            this.txtKonfirmasi.Location = new System.Drawing.Point(600, 380);
            this.txtKonfirmasi.Name = "txtKonfirmasi";
            this.txtKonfirmasi.UseSystemPasswordChar = true;
            this.txtKonfirmasi.Size = new System.Drawing.Size(320, 22);
            this.txtKonfirmasi.TabIndex = 15;

            // btnUbahPassword
            this.btnUbahPassword.BackColor = System.Drawing.Color.Crimson;
            this.btnUbahPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbahPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUbahPassword.ForeColor = System.Drawing.Color.White;
            this.btnUbahPassword.Location = new System.Drawing.Point(600, 440);
            this.btnUbahPassword.Name = "btnUbahPassword";
            this.btnUbahPassword.Size = new System.Drawing.Size(320, 55);
            this.btnUbahPassword.TabIndex = 16;
            this.btnUbahPassword.Text = "Ubah Password";
            this.btnUbahPassword.UseVisualStyleBackColor = false;
            this.btnUbahPassword.Click += new System.EventHandler(this.btnUbahPassword_Click);

            // lblInfo
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(50, 650);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(240, 16);
            this.lblInfo.TabIndex = 17;
            this.lblInfo.Text = "Semua perubahan otomatis tersimpan";

            // UC_Settings
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 245, 255);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnUbahPassword);
            this.Controls.Add(this.txtKonfirmasi);
            this.Controls.Add(this.lblKonfirmasi);
            this.Controls.Add(this.txtPassBaru);
            this.Controls.Add(this.lblPassBaru);
            this.Controls.Add(this.txtPassLama);
            this.Controls.Add(this.lblPassLama);
            this.Controls.Add(this.lblKeamanan);
            this.Controls.Add(this.btnPilihLogo);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.btnTerapkanTema);
            this.Controls.Add(this.comboTema);
            this.Controls.Add(this.lblTema);
            this.Controls.Add(this.txtNamaToko);
            this.Controls.Add(this.lblNamaToko);
            this.Controls.Add(this.lblJudul);
            this.Name = "UC_Settings";
            this.Size = new System.Drawing.Size(1400, 700);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblNamaToko;
        private System.Windows.Forms.TextBox txtNamaToko;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.ComboBox comboTema;
        private System.Windows.Forms.Button btnTerapkanTema;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnPilihLogo;
        private System.Windows.Forms.Label lblKeamanan;
        private System.Windows.Forms.Label lblPassLama;
        private System.Windows.Forms.TextBox txtPassLama;
        private System.Windows.Forms.Label lblPassBaru;
        private System.Windows.Forms.TextBox txtPassBaru;
        private System.Windows.Forms.Label lblKonfirmasi;
        private System.Windows.Forms.TextBox txtKonfirmasi;
        private System.Windows.Forms.Button btnUbahPassword;
        private System.Windows.Forms.Label lblInfo;
    }
}
