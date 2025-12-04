using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace budgetplanner
{
    public partial class Form2 : Form
    {
        private Form1 mainForm;

        private Form4 form4;

        public Form2(Form1 form1, Form4 form4)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.form4 = form4;
        }

        private void Form2_Load(object sender, PaintEventArgs e)
        {
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHome.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHome.BackColor = Color.Transparent; // jika ingin menyatu dengan background
            btnHome.Text = ""; // kalau mau hanya icon
            btnHome.ImageAlign = ContentAlignment.MiddleCenter;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.BackColor = Color.Transparent;
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            mainForm.Show();   // kembali ke Form1 asli
            this.Hide();
        }


        private void btnPengeluaran_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            panelPemasukan = new Panel();
            btnTambahPemasukan = new Button();
            labelPemasukan = new Label();
            DeskripsiPemasukan = new TextBox();
            labeltanggal = new Label();
            TanggalPemasukan = new DateTimePicker();
            label1 = new Label();
            inputPemasukan = new TextBox();
            btnBack1 = new Button();
            btnPengeluaran = new Button();
            panelNavbar = new Panel();
            btnGrafik = new Button();
            btnRiwayat = new Button();
            btnProfile = new Button();
            btnHome = new Button();
            panelPengeluaran = new Panel();
            btnTambahPengeluaran = new Button();
            label4 = new Label();
            KategoriPengeluaran = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            DeskripsiPengeluaran = new TextBox();
            TanggalPengeluaran = new DateTimePicker();
            inputPengeluaran = new TextBox();
            btnBack2 = new Button();
            btnPemasukan = new Button();
            panelPemasukan.SuspendLayout();
            panelNavbar.SuspendLayout();
            panelPengeluaran.SuspendLayout();
            SuspendLayout();
            // 
            // panelPemasukan
            // 
            panelPemasukan.Controls.Add(btnTambahPemasukan);
            panelPemasukan.Controls.Add(labelPemasukan);
            panelPemasukan.Controls.Add(DeskripsiPemasukan);
            panelPemasukan.Controls.Add(labeltanggal);
            panelPemasukan.Controls.Add(TanggalPemasukan);
            panelPemasukan.Controls.Add(label1);
            panelPemasukan.Controls.Add(inputPemasukan);
            panelPemasukan.Controls.Add(btnBack1);
            panelPemasukan.Controls.Add(btnPengeluaran);
            panelPemasukan.Dock = DockStyle.Fill;
            panelPemasukan.Location = new Point(0, 0);
            panelPemasukan.Name = "panelPemasukan";
            panelPemasukan.Size = new Size(797, 1084);
            panelPemasukan.TabIndex = 0;
            panelPemasukan.Paint += panelPemasukan_Paint;
            // 
            // btnTambahPemasukan
            // 
            btnTambahPemasukan.BackColor = SystemColors.MenuHighlight;
            btnTambahPemasukan.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTambahPemasukan.ForeColor = SystemColors.ButtonHighlight;
            btnTambahPemasukan.Location = new Point(268, 847);
            btnTambahPemasukan.Name = "btnTambahPemasukan";
            btnTambahPemasukan.Size = new Size(268, 85);
            btnTambahPemasukan.TabIndex = 18;
            btnTambahPemasukan.Text = "Tambah";
            btnTambahPemasukan.UseVisualStyleBackColor = false;
            btnTambahPemasukan.Click += btnTambahPemasukan_Click;
            // 
            // labelPemasukan
            // 
            labelPemasukan.AutoSize = true;
            labelPemasukan.Location = new Point(119, 672);
            labelPemasukan.Name = "labelPemasukan";
            labelPemasukan.Size = new Size(110, 32);
            labelPemasukan.TabIndex = 7;
            labelPemasukan.Text = "Deskripsi";
            // 
            // DeskripsiPemasukan
            // 
            DeskripsiPemasukan.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DeskripsiPemasukan.Location = new Point(119, 722);
            DeskripsiPemasukan.Name = "DeskripsiPemasukan";
            DeskripsiPemasukan.Size = new Size(575, 57);
            DeskripsiPemasukan.TabIndex = 6;
            DeskripsiPemasukan.TextChanged += DeskripsiPemasukan_TextChanged;
            // 
            // labeltanggal
            // 
            labeltanggal.AutoSize = true;
            labeltanggal.Location = new Point(119, 512);
            labeltanggal.Name = "labeltanggal";
            labeltanggal.Size = new Size(223, 32);
            labeltanggal.TabIndex = 5;
            labeltanggal.Text = "Tanggal Pemasukan";
            // 
            // TanggalPemasukan
            // 
            TanggalPemasukan.CalendarFont = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TanggalPemasukan.Location = new Point(119, 560);
            TanggalPemasukan.Name = "TanggalPemasukan";
            TanggalPemasukan.Size = new Size(569, 39);
            TanggalPemasukan.TabIndex = 4;
            TanggalPemasukan.ValueChanged += TanggalPemasukan_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 336);
            label1.Name = "label1";
            label1.Size = new Size(197, 32);
            label1.TabIndex = 3;
            label1.Text = "Input Pemasukan";
            // 
            // inputPemasukan
            // 
            inputPemasukan.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPemasukan.Location = new Point(119, 386);
            inputPemasukan.Name = "inputPemasukan";
            inputPemasukan.Size = new Size(575, 57);
            inputPemasukan.TabIndex = 2;
            inputPemasukan.TextChanged += inputPemasukan_TextChanged;
            // 
            // btnBack1
            // 
            btnBack1.FlatAppearance.BorderColor = SystemColors.Control;
            btnBack1.FlatAppearance.BorderSize = 0;
            btnBack1.FlatStyle = FlatStyle.Flat;
            btnBack1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack1.Location = new Point(29, -28);
            btnBack1.Name = "btnBack1";
            btnBack1.Size = new Size(161, 102);
            btnBack1.TabIndex = 1;
            btnBack1.Text = "←";
            btnBack1.UseVisualStyleBackColor = true;
            btnBack1.Click += btnBack1_Click;
            // 
            // btnPengeluaran
            // 
            btnPengeluaran.BackColor = Color.DeepSkyBlue;
            btnPengeluaran.Font = new Font("Segoe UI Historic", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPengeluaran.ForeColor = SystemColors.ControlLightLight;
            btnPengeluaran.Location = new Point(255, 163);
            btnPengeluaran.Name = "btnPengeluaran";
            btnPengeluaran.Size = new Size(294, 105);
            btnPengeluaran.TabIndex = 0;
            btnPengeluaran.Text = "Pengeluaran";
            btnPengeluaran.UseVisualStyleBackColor = false;
            btnPengeluaran.Click += btnPengeluaran_Click_1;
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
            panelNavbar.TabIndex = 10;
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
            // panelPengeluaran
            // 
            panelPengeluaran.Controls.Add(btnTambahPengeluaran);
            panelPengeluaran.Controls.Add(label4);
            panelPengeluaran.Controls.Add(KategoriPengeluaran);
            panelPengeluaran.Controls.Add(comboBox1);
            panelPengeluaran.Controls.Add(label3);
            panelPengeluaran.Controls.Add(label2);
            panelPengeluaran.Controls.Add(DeskripsiPengeluaran);
            panelPengeluaran.Controls.Add(TanggalPengeluaran);
            panelPengeluaran.Controls.Add(inputPengeluaran);
            panelPengeluaran.Controls.Add(btnBack2);
            panelPengeluaran.Controls.Add(btnPemasukan);
            panelPengeluaran.Dock = DockStyle.Fill;
            panelPengeluaran.Location = new Point(0, 0);
            panelPengeluaran.Name = "panelPengeluaran";
            panelPengeluaran.Size = new Size(797, 1084);
            panelPengeluaran.TabIndex = 8;
            panelPengeluaran.Paint += panelPengeluaran_Paint;
            // 
            // btnTambahPengeluaran
            // 
            btnTambahPengeluaran.BackColor = SystemColors.MenuHighlight;
            btnTambahPengeluaran.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTambahPengeluaran.ForeColor = SystemColors.ButtonHighlight;
            btnTambahPengeluaran.Location = new Point(268, 847);
            btnTambahPengeluaran.Name = "btnTambahPengeluaran";
            btnTambahPengeluaran.Size = new Size(268, 85);
            btnTambahPengeluaran.TabIndex = 17;
            btnTambahPengeluaran.Text = "Tambah";
            btnTambahPengeluaran.UseVisualStyleBackColor = false;
            btnTambahPengeluaran.Click += btnTambahPengeluaran_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(133, 701);
            label4.Name = "label4";
            label4.Size = new Size(110, 32);
            label4.TabIndex = 16;
            label4.Text = "Deskripsi";
            // 
            // KategoriPengeluaran
            // 
            KategoriPengeluaran.AutoSize = true;
            KategoriPengeluaran.Location = new Point(133, 591);
            KategoriPengeluaran.Name = "KategoriPengeluaran";
            KategoriPengeluaran.Size = new Size(103, 32);
            KategoriPengeluaran.TabIndex = 15;
            KategoriPengeluaran.Text = "Kategori";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Makan dan Minum", "Hiburan", "Belanja", "Transportasi", "Lainnya" });
            comboBox1.Location = new Point(132, 626);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 14;
            comboBox1.Text = "Pilih Kategori";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 474);
            label3.Name = "label3";
            label3.Size = new Size(96, 32);
            label3.TabIndex = 13;
            label3.Text = "Tanggal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 336);
            label2.Name = "label2";
            label2.Size = new Size(209, 32);
            label2.TabIndex = 12;
            label2.Text = "Input Pengeluaran";
            // 
            // DeskripsiPengeluaran
            // 
            DeskripsiPengeluaran.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DeskripsiPengeluaran.Location = new Point(132, 737);
            DeskripsiPengeluaran.Name = "DeskripsiPengeluaran";
            DeskripsiPengeluaran.Size = new Size(575, 57);
            DeskripsiPengeluaran.TabIndex = 11;
            DeskripsiPengeluaran.TextChanged += DeskripsiPengeluaran_TextChanged;
            // 
            // TanggalPengeluaran
            // 
            TanggalPengeluaran.CalendarFont = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TanggalPengeluaran.Location = new Point(132, 522);
            TanggalPengeluaran.Name = "TanggalPengeluaran";
            TanggalPengeluaran.Size = new Size(569, 39);
            TanggalPengeluaran.TabIndex = 10;
            TanggalPengeluaran.ValueChanged += TanggalPengeluaran_ValueChanged;
            // 
            // inputPengeluaran
            // 
            inputPengeluaran.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPengeluaran.Location = new Point(132, 386);
            inputPengeluaran.Name = "inputPengeluaran";
            inputPengeluaran.Size = new Size(575, 57);
            inputPengeluaran.TabIndex = 9;
            inputPengeluaran.TextChanged += inputPengeluaran_TextChanged;
            // 
            // btnBack2
            // 
            btnBack2.FlatAppearance.BorderColor = SystemColors.Control;
            btnBack2.FlatAppearance.BorderSize = 0;
            btnBack2.FlatStyle = FlatStyle.Flat;
            btnBack2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack2.Location = new Point(42, -28);
            btnBack2.Name = "btnBack2";
            btnBack2.Size = new Size(161, 102);
            btnBack2.TabIndex = 8;
            btnBack2.Text = "←";
            btnBack2.UseVisualStyleBackColor = true;
            btnBack2.Click += btnBack2_Click;
            // 
            // btnPemasukan
            // 
            btnPemasukan.BackColor = Color.DeepSkyBlue;
            btnPemasukan.Font = new Font("Segoe UI Historic", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPemasukan.ForeColor = SystemColors.ControlLightLight;
            btnPemasukan.Location = new Point(268, 163);
            btnPemasukan.Name = "btnPemasukan";
            btnPemasukan.Size = new Size(294, 105);
            btnPemasukan.TabIndex = 7;
            btnPemasukan.Text = "Pemasukan";
            btnPemasukan.UseVisualStyleBackColor = false;
            btnPemasukan.Click += btnPemasukan_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(797, 1084);
            Controls.Add(panelNavbar);
            Controls.Add(panelPengeluaran);
            Controls.Add(panelPemasukan);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            panelPemasukan.ResumeLayout(false);
            panelPemasukan.PerformLayout();
            panelNavbar.ResumeLayout(false);
            panelPengeluaran.ResumeLayout(false);
            panelPengeluaran.PerformLayout();
            ResumeLayout(false);

        }
        private Panel panelPemasukan;
        private Panel panelNavbar;
        private Button btnGrafik;
        private Button btnRiwayat;
        private Button btnProfile;
        private Button btnHome;
        private Button btnBack1;
        private Button btnPengeluaran;
        private TextBox inputPemasukan;
        private Label labelPemasukan;
        private TextBox DeskripsiPemasukan;
        private Label labeltanggal;
        private DateTimePicker TanggalPemasukan;
        private Label label1;
        private Panel panelPengeluaran;
        private TextBox DeskripsiPengeluaran;
        private DateTimePicker TanggalPengeluaran;
        private TextBox inputPengeluaran;
        private Button btnBack2;
        private Button btnPemasukan;
        private ComboBox comboBox1;
        private Label label3;
        private Label label2;
        private Button btnTambahPemasukan;
        private Button btnTambahPengeluaran;
        private Label label4;
        private Label KategoriPengeluaran;

        private void btnBack2_Click(object sender, EventArgs e)
        {
            mainForm.Show(); // Pakai yang udah ada
            this.Close();
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            mainForm.Show(); // Pakai yang udah ada
            this.Close();
        }

        private void panelPemasukan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPengeluaran_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPengeluaran_Click_1(object sender, EventArgs e)
        {
            panelPengeluaran.Visible = true;
            panelPemasukan.Visible = false;
        }

        private void btnPemasukan_Click(object sender, EventArgs e)
        {
            panelPemasukan.Visible = true;
            panelPengeluaran.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            mainForm.Show(); // Pakai Form1 yang asli
            this.Close();    // Close Form2, jangan cuma Hide
        }

        private void inputPemasukan_TextChanged(object sender, EventArgs e)
        {

        }

        private void TanggalPemasukan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DeskripsiPemasukan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambahPemasukan_Click(object sender, EventArgs e)
        {
            string jumlah = inputPemasukan.Text;

            if (string.IsNullOrWhiteSpace(jumlah))
            {
                MessageBox.Show("Masukkan jumlah pemasukan!");
                return;
            }

            // ⭐ Tambahan → kirim ke Form1 untuk total
            mainForm.AddPemasukan(jumlah, mainForm.currentUserId);


            // ⭐ Tambahan → buat Transaksi untuk Form4
            Transaksi t = new Transaksi
            {
                Jenis = "Pemasukan",
                Jumlah = jumlah,
                Tanggal = TanggalPemasukan.Value,
                Deskripsi = DeskripsiPemasukan.Text,
                Kategori = ""
            };

            // ⭐ Kirim ke Form4
            form4.AddCardToUI(t);

            this.Hide();
            mainForm.Show(); // langsung ke riwayat
        }



        private void inputPengeluaran_TextChanged(object sender, EventArgs e)
        {

        }

        private void TanggalPengeluaran_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeskripsiPengeluaran_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambahPengeluaran_Click(object sender, EventArgs e)
        {
            string jumlah = inputPengeluaran.Text;

            if (string.IsNullOrWhiteSpace(jumlah))
            {
                MessageBox.Show("Masukkan jumlah pengeluaran!");
                return;
            }

            // ⭐ Tambahan → kirim ke Form1 untuk total
            mainForm.AddPengeluaran(
            jumlah,
            comboBox1.Text,
            DeskripsiPengeluaran.Text,
            mainForm.currentUserId
            );



            // ⭐ Tambahan → buat Transaksi untuk Form4
            Transaksi t = new Transaksi
            {
                Jenis = "Pengeluaran",
                Jumlah = jumlah,
                Tanggal = TanggalPengeluaran.Value,
                Kategori = comboBox1.Text,
                Deskripsi = DeskripsiPengeluaran.Text
            };



            // ⭐ Kirim ke Form4
            mainForm.form3.UpdateDisplay();

            this.Hide();
            mainForm.Show();
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {

        }
    }


}
