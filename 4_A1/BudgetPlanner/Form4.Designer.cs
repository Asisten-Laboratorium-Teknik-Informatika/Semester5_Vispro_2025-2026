namespace budgetplanner
{
    partial class Form4
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
            panel1 = new Panel();
            label1 = new Label();
            panelNavbar = new Panel();
            btnGrafik = new Button();
            btnRiwayat = new Button();
            btnProfile = new Button();
            btnHome = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            CardPemasukan = new CustomRoundedPanel();
            DeskripsiPemasukan = new Label();
            TanggalPemasukan = new Label();
            lblPemasukan = new Label();
            CardPengeluaran = new CustomRoundedPanel();
            KategoriPengeluaran = new Label();
            DeskripsiPengeluaran = new Label();
            TanggalPengeluaran = new Label();
            lblPengeluaran = new Label();
            panel1.SuspendLayout();
            panelNavbar.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            CardPemasukan.SuspendLayout();
            CardPengeluaran.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panelNavbar);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 1084);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(199, 53);
            label1.Name = "label1";
            label1.Size = new Size(374, 59);
            label1.TabIndex = 13;
            label1.Text = "Riwayat Transaksi";
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
            panelNavbar.TabIndex = 12;
            // 
            // btnGrafik
            // 
            btnGrafik.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnGrafik.FlatAppearance.BorderSize = 0;
            btnGrafik.FlatStyle = FlatStyle.Flat;
            btnGrafik.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGrafik.Location = new Point(262, 20);
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
            btnRiwayat.Location = new Point(486, 20);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(65, 65);
            btnRiwayat.TabIndex = 3;
            btnRiwayat.Text = "💰";
            btnRiwayat.UseVisualStyleBackColor = true;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(CardPemasukan);
            flowLayoutPanel1.Controls.Add(CardPengeluaran);
            flowLayoutPanel1.Location = new Point(12, 151);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(773, 920);
            flowLayoutPanel1.TabIndex = 16;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // CardPemasukan
            // 
            CardPemasukan.BorderColor = Color.Gray;
            CardPemasukan.BorderRadius = 20;
            CardPemasukan.BorderThickness = 2;
            CardPemasukan.Controls.Add(DeskripsiPemasukan);
            CardPemasukan.Controls.Add(TanggalPemasukan);
            CardPemasukan.Controls.Add(lblPemasukan);
            CardPemasukan.FillColor = Color.White;
            CardPemasukan.Location = new Point(3, 3);
            CardPemasukan.Name = "CardPemasukan";
            CardPemasukan.Size = new Size(376, 125);
            CardPemasukan.TabIndex = 14;
            CardPemasukan.Visible = false;
            CardPemasukan.Paint += CardPemasukan_Paint;
            // 
            // DeskripsiPemasukan
            // 
            DeskripsiPemasukan.BackColor = Color.White;
            DeskripsiPemasukan.Font = new Font("Segoe UI", 7F);
            DeskripsiPemasukan.Location = new Point(24, 53);
            DeskripsiPemasukan.Name = "DeskripsiPemasukan";
            DeskripsiPemasukan.Size = new Size(167, 64);
            DeskripsiPemasukan.TabIndex = 2;
            DeskripsiPemasukan.Text = "Deskripsi";
            DeskripsiPemasukan.Click += DeskripsiPemasukan_Click;
            // 
            // TanggalPemasukan
            // 
            TanggalPemasukan.BackColor = Color.White;
            TanggalPemasukan.Font = new Font("Segoe UI", 7F);
            TanggalPemasukan.Location = new Point(247, 11);
            TanggalPemasukan.Name = "TanggalPemasukan";
            TanggalPemasukan.Size = new Size(126, 25);
            TanggalPemasukan.TabIndex = 1;
            TanggalPemasukan.Text = "Tanggal";
            TanggalPemasukan.TextAlign = ContentAlignment.TopRight;
            TanggalPemasukan.Click += TanggalPemasukan_Click;
            // 
            // lblPemasukan
            // 
            lblPemasukan.BackColor = Color.White;
            lblPemasukan.FlatStyle = FlatStyle.Flat;
            lblPemasukan.Font = new Font("Segoe UI", 7.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPemasukan.Location = new Point(24, 11);
            lblPemasukan.Name = "lblPemasukan";
            lblPemasukan.Size = new Size(188, 25);
            lblPemasukan.TabIndex = 0;
            lblPemasukan.Text = "Pemasukan";
            lblPemasukan.Click += lblPemasukan_Click;
            // 
            // CardPengeluaran
            // 
            CardPengeluaran.BorderColor = Color.Gray;
            CardPengeluaran.BorderRadius = 20;
            CardPengeluaran.BorderThickness = 2;
            CardPengeluaran.Controls.Add(KategoriPengeluaran);
            CardPengeluaran.Controls.Add(DeskripsiPengeluaran);
            CardPengeluaran.Controls.Add(TanggalPengeluaran);
            CardPengeluaran.Controls.Add(lblPengeluaran);
            CardPengeluaran.FillColor = Color.White;
            CardPengeluaran.Location = new Point(385, 3);
            CardPengeluaran.Name = "CardPengeluaran";
            CardPengeluaran.Size = new Size(376, 125);
            CardPengeluaran.TabIndex = 15;
            CardPengeluaran.Visible = false;
            CardPengeluaran.Paint += CardPengeluaran_Paint;
            // 
            // KategoriPengeluaran
            // 
            KategoriPengeluaran.BackColor = Color.White;
            KategoriPengeluaran.Font = new Font("Segoe UI", 7F);
            KategoriPengeluaran.Location = new Point(214, 73);
            KategoriPengeluaran.Name = "KategoriPengeluaran";
            KategoriPengeluaran.Size = new Size(159, 44);
            KategoriPengeluaran.TabIndex = 3;
            KategoriPengeluaran.Text = "Kategori";
            KategoriPengeluaran.Click += KategoriPengeluaran_Click;
            // 
            // DeskripsiPengeluaran
            // 
            DeskripsiPengeluaran.BackColor = Color.White;
            DeskripsiPengeluaran.Font = new Font("Segoe UI", 7F);
            DeskripsiPengeluaran.Location = new Point(24, 53);
            DeskripsiPengeluaran.Name = "DeskripsiPengeluaran";
            DeskripsiPengeluaran.Size = new Size(167, 64);
            DeskripsiPengeluaran.TabIndex = 2;
            DeskripsiPengeluaran.Text = "Deskripsi";
            DeskripsiPengeluaran.Click += DeskripsiPengeluaran_Click;
            // 
            // TanggalPengeluaran
            // 
            TanggalPengeluaran.BackColor = Color.White;
            TanggalPengeluaran.Font = new Font("Segoe UI", 7F);
            TanggalPengeluaran.Location = new Point(247, 11);
            TanggalPengeluaran.Name = "TanggalPengeluaran";
            TanggalPengeluaran.Size = new Size(126, 25);
            TanggalPengeluaran.TabIndex = 1;
            TanggalPengeluaran.Text = "Tanggal";
            TanggalPengeluaran.TextAlign = ContentAlignment.TopRight;
            TanggalPengeluaran.Click += TanggalPengeluaran_Click;
            // 
            // lblPengeluaran
            // 
            lblPengeluaran.BackColor = Color.White;
            lblPengeluaran.FlatStyle = FlatStyle.Flat;
            lblPengeluaran.Font = new Font("Segoe UI", 7.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPengeluaran.Location = new Point(24, 11);
            lblPengeluaran.Name = "lblPengeluaran";
            lblPengeluaran.Size = new Size(193, 25);
            lblPengeluaran.TabIndex = 0;
            lblPengeluaran.Text = "Pengeluaran";
            lblPengeluaran.Click += lblPengeluaran_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 1084);
            Controls.Add(panel1);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            Load += Form4_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelNavbar.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            CardPemasukan.ResumeLayout(false);
            CardPengeluaran.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelNavbar;
        private Button btnGrafik;
        private Button btnRiwayat;
        private Button btnProfile;
        private Button btnHome;
        private Label label1;
        private CustomRoundedPanel CardPemasukan;
        private Label lblPemasukan;
        private Label TanggalPemasukan;
        private Label DeskripsiPemasukan;
        private FlowLayoutPanel flowLayoutPanel1;
        private CustomRoundedPanel CardPengeluaran;
        private Label KategoriPengeluaran;
        private Label DeskripsiPengeluaran;
        private Label TanggalPengeluaran;
        private Label lblPengeluaran;
    }
}