namespace CinemaTix
{
    partial class FormPilihJadwal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPilihJadwal));
            label1 = new Label();
            label2 = new Label();
            cbJumlah = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            txtFilm = new TextBox();
            txtStudio = new TextBox();
            btnKonfirmasi = new Button();
            cbJadwal = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            btnKembali = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(366, 66);
            label1.Name = "label1";
            label1.Size = new Size(143, 29);
            label1.TabIndex = 0;
            label1.Text = "CinemaTix";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 55);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 2;
            label2.Text = "Film :";
            label2.Click += label2_Click;
            // 
            // cbJumlah
            // 
            cbJumlah.FormattingEnabled = true;
            cbJumlah.Location = new Point(72, 160);
            cbJumlah.Name = "cbJumlah";
            cbJumlah.Size = new Size(151, 25);
            cbJumlah.TabIndex = 3;
            cbJumlah.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 136);
            label3.Name = "label3";
            label3.Size = new Size(61, 17);
            label3.TabIndex = 4;
            label3.Text = "Jumlah :";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(382, 136);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 6;
            label4.Text = "Studio :";
            label4.Click += label4_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(btnKembali);
            panel1.Controls.Add(txtFilm);
            panel1.Controls.Add(txtStudio);
            panel1.Controls.Add(btnKonfirmasi);
            panel1.Controls.Add(cbJadwal);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbJumlah);
            panel1.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel1.Location = new Point(140, 164);
            panel1.Name = "panel1";
            panel1.Size = new Size(588, 283);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // txtFilm
            // 
            txtFilm.Location = new Point(72, 86);
            txtFilm.Name = "txtFilm";
            txtFilm.Size = new Size(151, 23);
            txtFilm.TabIndex = 12;
            // 
            // txtStudio
            // 
            txtStudio.Location = new Point(379, 160);
            txtStudio.Name = "txtStudio";
            txtStudio.Size = new Size(151, 23);
            txtStudio.TabIndex = 11;
            txtStudio.TextChanged += textBox1_TextChanged;
            // 
            // btnKonfirmasi
            // 
            btnKonfirmasi.BackColor = Color.LimeGreen;
            btnKonfirmasi.Font = new Font("Times New Roman", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKonfirmasi.ForeColor = SystemColors.ButtonHighlight;
            btnKonfirmasi.Location = new Point(426, 225);
            btnKonfirmasi.Name = "btnKonfirmasi";
            btnKonfirmasi.Size = new Size(104, 31);
            btnKonfirmasi.TabIndex = 10;
            btnKonfirmasi.Text = "KONFIRMASI";
            btnKonfirmasi.UseVisualStyleBackColor = false;
            btnKonfirmasi.Click += btnKonfirmasi_Click;
            // 
            // cbJadwal
            // 
            cbJadwal.FormattingEnabled = true;
            cbJadwal.Location = new Point(379, 86);
            cbJadwal.Name = "cbJadwal";
            cbJadwal.Size = new Size(151, 25);
            cbJadwal.TabIndex = 9;
            cbJadwal.SelectedIndexChanged += cbJadwal_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(379, 55);
            label6.Name = "label6";
            label6.Size = new Size(59, 17);
            label6.TabIndex = 8;
            label6.Text = "Jadwal :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(234, 9);
            label5.Name = "label5";
            label5.Size = new Size(135, 24);
            label5.TabIndex = 7;
            label5.Text = "Pesan Tiket";
            label5.Click += label5_Click;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Red;
            btnKembali.Font = new Font("Times New Roman", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(72, 226);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(104, 29);
            btnKembali.TabIndex = 13;
            btnKembali.Text = "KEMBALI";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormPilihJadwal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(843, 581);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "FormPilihJadwal";
            Text = "FormPilihJadwal";
            Load += FormPilihJadwal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbJumlah;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private ComboBox cbJadwal;
        private Label label6;
        private Button btnKonfirmasi;
        private TextBox txtStudio;
        private TextBox txtFilm;
        private Button btnKembali;
    }
}