namespace KamarKos
{
    partial class FormPembayaran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPembayaran));
            lblID = new Label();
            txtIDPembayaran = new TextBox();
            lblNama = new Label();
            cmbPenghuni = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            dgvPembayaran = new DataGridView();
            btnTambah = new Button();
            BtnEdit = new Button();
            btnHapus = new Button();
            btnBersih = new Button();
            label1 = new Label();
            cmbKamar = new ComboBox();
            btnBack = new Button();
            label2 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            dtpTanggalPembayaran = new DateTimePicker();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPembayaran).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.ForeColor = Color.FromArgb(44, 62, 80);
            lblID.Location = new Point(8, 7);
            lblID.Name = "lblID";
            lblID.Size = new Size(132, 25);
            lblID.TabIndex = 1;
            lblID.Text = "ID Pembayaran";
            lblID.Click += lblID_Click;
            // 
            // txtIDPembayaran
            // 
            txtIDPembayaran.Location = new Point(13, 36);
            txtIDPembayaran.Multiline = true;
            txtIDPembayaran.Name = "txtIDPembayaran";
            txtIDPembayaran.Size = new Size(632, 42);
            txtIDPembayaran.TabIndex = 2;
            txtIDPembayaran.TextChanged += txtIDPembayaran_TextChanged;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.ForeColor = Color.FromArgb(44, 62, 80);
            lblNama.Location = new Point(8, 93);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(137, 25);
            lblNama.TabIndex = 3;
            lblNama.Text = "Nama Penghuni";
            // 
            // cmbPenghuni
            // 
            cmbPenghuni.FormattingEnabled = true;
            cmbPenghuni.Location = new Point(13, 119);
            cmbPenghuni.Name = "cmbPenghuni";
            cmbPenghuni.Size = new Size(632, 33);
            cmbPenghuni.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(44, 62, 80);
            lblStatus.Location = new Point(8, 310);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(162, 25);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status Pembayaran";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "LUNAS", "BELUM LUNAS" });
            cmbStatus.Location = new Point(13, 338);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(632, 33);
            cmbStatus.TabIndex = 6;
            // 
            // dgvPembayaran
            // 
            dgvPembayaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPembayaran.Location = new Point(63, 592);
            dgvPembayaran.Name = "dgvPembayaran";
            dgvPembayaran.RowHeadersWidth = 62;
            dgvPembayaran.Size = new Size(669, 127);
            dgvPembayaran.TabIndex = 7;
            dgvPembayaran.CellContentClick += dgvPembayaran_CellContentClick;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.FromArgb(44, 62, 80);
            btnTambah.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(28, 393);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(112, 45);
            btnTambah.TabIndex = 8;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.BackColor = Color.FromArgb(44, 62, 80);
            BtnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEdit.ForeColor = Color.White;
            BtnEdit.Location = new Point(195, 393);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(112, 45);
            BtnEdit.TabIndex = 9;
            BtnEdit.Text = "Edit";
            BtnEdit.UseVisualStyleBackColor = false;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.FromArgb(44, 62, 80);
            btnHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(361, 393);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(112, 45);
            btnHapus.TabIndex = 10;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnBersih
            // 
            btnBersih.BackColor = Color.FromArgb(44, 62, 80);
            btnBersih.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBersih.ForeColor = Color.White;
            btnBersih.Location = new Point(523, 393);
            btnBersih.Name = "btnBersih";
            btnBersih.Size = new Size(112, 45);
            btnBersih.TabIndex = 11;
            btnBersih.Text = "Bersih";
            btnBersih.UseVisualStyleBackColor = false;
            btnBersih.Click += btnBersih_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(8, 167);
            label1.Name = "label1";
            label1.Size = new Size(114, 25);
            label1.TabIndex = 12;
            label1.Text = "Nama Kamar";
            // 
            // cmbKamar
            // 
            cmbKamar.FormattingEnabled = true;
            cmbKamar.Location = new Point(13, 194);
            cmbKamar.Name = "cmbKamar";
            cmbKamar.Size = new Size(632, 33);
            cmbKamar.TabIndex = 13;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(25, 27);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(21, 34);
            btnBack.TabIndex = 17;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(97, 23);
            label2.Name = "label2";
            label2.Size = new Size(217, 38);
            label2.TabIndex = 19;
            label2.Text = "Room Payment";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(107, 114, 128);
            label4.Location = new Point(100, 61);
            label4.Name = "label4";
            label4.Size = new Size(311, 25);
            label4.TabIndex = 21;
            label4.Text = "Informasi tentang pembayaran kamar";
            label4.Click += label4_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpTanggalPembayaran);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblID);
            panel1.Controls.Add(txtIDPembayaran);
            panel1.Controls.Add(lblNama);
            panel1.Controls.Add(btnHapus);
            panel1.Controls.Add(btnBersih);
            panel1.Controls.Add(BtnEdit);
            panel1.Controls.Add(cmbKamar);
            panel1.Controls.Add(cmbPenghuni);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnTambah);
            panel1.Controls.Add(cmbStatus);
            panel1.Controls.Add(lblStatus);
            panel1.Location = new Point(63, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(669, 460);
            panel1.TabIndex = 22;
            // 
            // dtpTanggalPembayaran
            // 
            dtpTanggalPembayaran.CalendarFont = new Font("Times New Roman", 9F);
            dtpTanggalPembayaran.CustomFormat = "dd-MM-yyyy";
            dtpTanggalPembayaran.Format = DateTimePickerFormat.Custom;
            dtpTanggalPembayaran.Location = new Point(13, 272);
            dtpTanggalPembayaran.Name = "dtpTanggalPembayaran";
            dtpTanggalPembayaran.ShowUpDown = true;
            dtpTanggalPembayaran.Size = new Size(632, 31);
            dtpTanggalPembayaran.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(44, 62, 80);
            label3.Location = new Point(8, 242);
            label3.Name = "label3";
            label3.Size = new Size(175, 25);
            label3.TabIndex = 14;
            label3.Text = "Tanggal Pembayaran";
            // 
            // FormPembayaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 738);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(dgvPembayaran);
            Controls.Add(panel1);
            Name = "FormPembayaran";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPembayaran";
            Load += FormPembayaran_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPembayaran).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblID;
        private TextBox txtIDPembayaran;
        private Label lblNama;
        private ComboBox cmbPenghuni;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private DataGridView dgvPembayaran;
        private Button btnTambah;
        private Button BtnEdit;
        private Button btnHapus;
        private Button btnBersih;
        private Label label1;
        private ComboBox cmbKamar;
        private Button btnBack;
        private Label label2;
        private Label label4;
        private Panel panel1;
        private DateTimePicker dtpTanggalPembayaran;
        private Label label3;
    }
}