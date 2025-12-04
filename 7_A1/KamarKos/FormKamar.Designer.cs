namespace KamarKos
{
    partial class FormKamar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKamar));
            label1 = new Label();
            lblKode = new Label();
            txtKodeKamar = new TextBox();
            lblNama = new Label();
            txtNamaKamar = new TextBox();
            lblHarga = new Label();
            txtHarga = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            dgvKamar = new DataGridView();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            btnBersih = new Button();
            btnBack = new Button();
            label2 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKamar).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 24);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            // 
            // lblKode
            // 
            lblKode.AutoSize = true;
            lblKode.ForeColor = Color.FromArgb(44, 62, 80);
            lblKode.Location = new Point(64, 109);
            lblKode.Name = "lblKode";
            lblKode.Size = new Size(193, 25);
            lblKode.TabIndex = 1;
            lblKode.Text = "Masukkan Kode Kamar";
            // 
            // txtKodeKamar
            // 
            txtKodeKamar.Location = new Point(11, 34);
            txtKodeKamar.Multiline = true;
            txtKodeKamar.Name = "txtKodeKamar";
            txtKodeKamar.Size = new Size(646, 45);
            txtKodeKamar.TabIndex = 2;
            txtKodeKamar.TextChanged += txtKodeKamar_TextChanged;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.ForeColor = Color.FromArgb(44, 62, 80);
            lblNama.Location = new Point(11, 84);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(199, 25);
            lblNama.TabIndex = 3;
            lblNama.Text = "Masukkan Nama Kamar";
            // 
            // txtNamaKamar
            // 
            txtNamaKamar.Location = new Point(11, 111);
            txtNamaKamar.Multiline = true;
            txtNamaKamar.Name = "txtNamaKamar";
            txtNamaKamar.Size = new Size(646, 42);
            txtNamaKamar.TabIndex = 4;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.ForeColor = Color.FromArgb(44, 62, 80);
            lblHarga.Location = new Point(11, 159);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(102, 25);
            lblHarga.TabIndex = 5;
            lblHarga.Text = "Total Harga";
            // 
            // txtHarga
            // 
            txtHarga.Location = new Point(11, 185);
            txtHarga.Multiline = true;
            txtHarga.Name = "txtHarga";
            txtHarga.Size = new Size(646, 42);
            txtHarga.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(44, 62, 80);
            lblStatus.Location = new Point(11, 253);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 25);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Kosong", "Terisi" });
            cmbStatus.Location = new Point(77, 252);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(580, 33);
            cmbStatus.TabIndex = 8;
            // 
            // dgvKamar
            // 
            dgvKamar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKamar.Location = new Point(54, 491);
            dgvKamar.Name = "dgvKamar";
            dgvKamar.RowHeadersWidth = 62;
            dgvKamar.Size = new Size(684, 128);
            dgvKamar.TabIndex = 9;
            dgvKamar.CellContentClick += dgvKamar_CellContentClick;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.FromArgb(44, 62, 80);
            btnTambah.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(11, 322);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(126, 45);
            btnTambah.TabIndex = 10;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(44, 62, 80);
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(186, 322);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(119, 45);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.FromArgb(44, 62, 80);
            btnHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(358, 322);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(125, 45);
            btnHapus.TabIndex = 12;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnBersih
            // 
            btnBersih.BackColor = Color.FromArgb(44, 62, 80);
            btnBersih.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBersih.ForeColor = Color.White;
            btnBersih.Location = new Point(537, 322);
            btnBersih.Name = "btnBersih";
            btnBersih.Size = new Size(118, 45);
            btnBersih.TabIndex = 13;
            btnBersih.Text = "Bersih";
            btnBersih.UseVisualStyleBackColor = false;
            btnBersih.Click += btnBersih_Click;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(15, 17);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(30, 34);
            btnBack.TabIndex = 17;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(54, 9);
            label2.Name = "label2";
            label2.Size = new Size(171, 38);
            label2.TabIndex = 18;
            label2.Text = "Room Form";
            label2.Click += label2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtKodeKamar);
            panel1.Controls.Add(txtNamaKamar);
            panel1.Controls.Add(btnTambah);
            panel1.Controls.Add(btnBersih);
            panel1.Controls.Add(lblNama);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(btnHapus);
            panel1.Controls.Add(lblHarga);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(txtHarga);
            panel1.Controls.Add(cmbStatus);
            panel1.Location = new Point(54, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 380);
            panel1.TabIndex = 19;
            panel1.Paint += panel1_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(107, 114, 128);
            label4.Location = new Point(58, 47);
            label4.Name = "label4";
            label4.Size = new Size(207, 25);
            label4.TabIndex = 20;
            label4.Text = "Informasi tentang kamar";
            // 
            // FormKamar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 637);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(dgvKamar);
            Controls.Add(lblKode);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "FormKamar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormKamar";
            Load += FormKamar_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvKamar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblKode;
        private TextBox txtKodeKamar;
        private Label lblNama;
        private TextBox txtNamaKamar;
        private Label lblHarga;
        private TextBox txtHarga;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private DataGridView dgvKamar;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapus;
        private Button btnBersih;
        private Button btnBack;
        private Label label2;
        private Panel panel1;
        private Label label4;
    }
}