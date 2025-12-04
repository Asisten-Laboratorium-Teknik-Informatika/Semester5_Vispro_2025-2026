namespace KamarKos
{
    partial class FormPenghuni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPenghuni));
            lblID = new Label();
            txtIDPenghuni = new TextBox();
            lblNama = new Label();
            txtNamaPenghuni = new TextBox();
            lblNoHP = new Label();
            txtNoHP = new TextBox();
            txtAlamat = new TextBox();
            lblAlamat = new Label();
            lblKamar = new Label();
            cmbKamar = new ComboBox();
            dgvPenghuni = new DataGridView();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            btnBersih = new Button();
            btnBack = new Button();
            label2 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            dtpTanggalMasuk = new DateTimePicker();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPenghuni).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.ForeColor = Color.FromArgb(44, 62, 80);
            lblID.Location = new Point(5, 1);
            lblID.Name = "lblID";
            lblID.Size = new Size(108, 25);
            lblID.TabIndex = 1;
            lblID.Text = "ID Penghuni";
            // 
            // txtIDPenghuni
            // 
            txtIDPenghuni.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIDPenghuni.Location = new Point(12, 29);
            txtIDPenghuni.Multiline = true;
            txtIDPenghuni.Name = "txtIDPenghuni";
            txtIDPenghuni.Size = new Size(627, 43);
            txtIDPenghuni.TabIndex = 2;
            txtIDPenghuni.TextChanged += txtIDPenghuni_TextChanged;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.ForeColor = Color.FromArgb(44, 62, 80);
            lblNama.Location = new Point(5, 84);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(137, 25);
            lblNama.TabIndex = 3;
            lblNama.Text = "Nama Penghuni";
            lblNama.Click += lblNama_Click;
            // 
            // txtNamaPenghuni
            // 
            txtNamaPenghuni.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNamaPenghuni.Location = new Point(12, 112);
            txtNamaPenghuni.Multiline = true;
            txtNamaPenghuni.Name = "txtNamaPenghuni";
            txtNamaPenghuni.Size = new Size(627, 44);
            txtNamaPenghuni.TabIndex = 4;
            // 
            // lblNoHP
            // 
            lblNoHP.AutoSize = true;
            lblNoHP.ForeColor = Color.FromArgb(44, 62, 80);
            lblNoHP.Location = new Point(5, 170);
            lblNoHP.Name = "lblNoHP";
            lblNoHP.Size = new Size(97, 25);
            lblNoHP.TabIndex = 5;
            lblNoHP.Text = "Nomor HP";
            // 
            // txtNoHP
            // 
            txtNoHP.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNoHP.Location = new Point(12, 198);
            txtNoHP.Multiline = true;
            txtNoHP.Name = "txtNoHP";
            txtNoHP.Size = new Size(627, 43);
            txtNoHP.TabIndex = 6;
            // 
            // txtAlamat
            // 
            txtAlamat.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAlamat.Location = new Point(12, 283);
            txtAlamat.Multiline = true;
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(627, 40);
            txtAlamat.TabIndex = 8;
            txtAlamat.TextChanged += txtAlamat_TextChanged;
            // 
            // lblAlamat
            // 
            lblAlamat.AutoSize = true;
            lblAlamat.ForeColor = Color.FromArgb(44, 62, 80);
            lblAlamat.Location = new Point(5, 255);
            lblAlamat.Name = "lblAlamat";
            lblAlamat.Size = new Size(68, 25);
            lblAlamat.TabIndex = 7;
            lblAlamat.Text = "Alamat";
            // 
            // lblKamar
            // 
            lblKamar.AutoSize = true;
            lblKamar.ForeColor = Color.FromArgb(44, 62, 80);
            lblKamar.Location = new Point(5, 411);
            lblKamar.Name = "lblKamar";
            lblKamar.Size = new Size(108, 25);
            lblKamar.TabIndex = 9;
            lblKamar.Text = "Kode Kamar";
            lblKamar.Click += lblKamar_Click;
            // 
            // cmbKamar
            // 
            cmbKamar.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbKamar.FormattingEnabled = true;
            cmbKamar.Location = new Point(12, 439);
            cmbKamar.Name = "cmbKamar";
            cmbKamar.Size = new Size(627, 28);
            cmbKamar.TabIndex = 10;
            // 
            // dgvPenghuni
            // 
            dgvPenghuni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPenghuni.Location = new Point(72, 664);
            dgvPenghuni.Name = "dgvPenghuni";
            dgvPenghuni.RowHeadersWidth = 62;
            dgvPenghuni.Size = new Size(661, 131);
            dgvPenghuni.TabIndex = 11;
            dgvPenghuni.CellContentClick += dgvPenghuni_CellContentClick;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.FromArgb(44, 62, 80);
            btnTambah.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(12, 487);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(112, 43);
            btnTambah.TabIndex = 12;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(44, 62, 80);
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(179, 487);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 43);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.FromArgb(44, 62, 80);
            btnHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(354, 487);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(112, 43);
            btnHapus.TabIndex = 14;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnBersih
            // 
            btnBersih.BackColor = Color.FromArgb(44, 62, 80);
            btnBersih.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBersih.ForeColor = Color.White;
            btnBersih.Location = new Point(527, 487);
            btnBersih.Name = "btnBersih";
            btnBersih.Size = new Size(112, 43);
            btnBersih.TabIndex = 15;
            btnBersih.Text = "Bersih";
            btnBersih.UseVisualStyleBackColor = false;
            btnBersih.Click += btnBersih_Click;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(26, 22);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(20, 34);
            btnBack.TabIndex = 16;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(69, 16);
            label2.Name = "label2";
            label2.Size = new Size(226, 38);
            label2.TabIndex = 20;
            label2.Text = "Room Occupant";
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpTanggalMasuk);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblID);
            panel1.Controls.Add(txtIDPenghuni);
            panel1.Controls.Add(lblNama);
            panel1.Controls.Add(btnHapus);
            panel1.Controls.Add(btnBersih);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(txtNamaPenghuni);
            panel1.Controls.Add(lblNoHP);
            panel1.Controls.Add(txtNoHP);
            panel1.Controls.Add(btnTambah);
            panel1.Controls.Add(lblAlamat);
            panel1.Controls.Add(txtAlamat);
            panel1.Controls.Add(cmbKamar);
            panel1.Controls.Add(lblKamar);
            panel1.Location = new Point(72, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(661, 546);
            panel1.TabIndex = 21;
            panel1.Paint += panel1_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(107, 114, 128);
            label4.Location = new Point(72, 55);
            label4.Name = "label4";
            label4.Size = new Size(287, 25);
            label4.TabIndex = 22;
            label4.Text = "Informasi tentang penghuni kamar";
            label4.Click += label4_Click;
            // 
            // dtpTanggalMasuk
            // 
            dtpTanggalMasuk.CustomFormat = "yyyy-MM-dd";
            dtpTanggalMasuk.Font = new Font("Times New Roman", 9F);
            dtpTanggalMasuk.Location = new Point(12, 369);
            dtpTanggalMasuk.Name = "dtpTanggalMasuk";
            dtpTanggalMasuk.Size = new Size(627, 28);
            dtpTanggalMasuk.TabIndex = 23;
            dtpTanggalMasuk.ValueChanged += dtpTanggalMasuk_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(5, 339);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 16;
            label1.Text = "Tanggal Masuk";
            // 
            // FormPenghuni
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 812);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(dgvPenghuni);
            Controls.Add(panel1);
            Name = "FormPenghuni";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPenghuni";
            Load += FormPenghuni_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvPenghuni).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblID;
        private TextBox txtIDPenghuni;
        private Label lblNama;
        private TextBox txtNamaPenghuni;
        private Label lblNoHP;
        private TextBox txtNoHP;
        private TextBox txtAlamat;
        private Label lblAlamat;
        private Label lblKamar;
        private ComboBox cmbKamar;
        private DataGridView dgvPenghuni;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapus;
        private Button btnBersih;
        private Button btnBack;
        private Label label2;
        private Panel panel1;
        private Label label4;
        private DateTimePicker dtpTanggalMasuk;
        private Label label1;
    }
}