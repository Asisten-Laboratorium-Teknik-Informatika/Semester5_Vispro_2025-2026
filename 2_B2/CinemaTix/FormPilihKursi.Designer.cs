namespace CinemaTix
{
    partial class FormPilihKursi
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
            label1 = new Label();
            flpKursi = new FlowLayoutPanel();
            label2 = new Label();
            btnPesan = new Button();
            txtKursiTerpilih = new TextBox();
            btnKembali = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(353, 61);
            label1.Name = "label1";
            label1.Size = new Size(148, 29);
            label1.TabIndex = 0;
            label1.Text = "Pilih Kursi";
            // 
            // flpKursi
            // 
            flpKursi.BackColor = SystemColors.ControlDarkDark;
            flpKursi.ForeColor = SystemColors.ButtonFace;
            flpKursi.Location = new Point(197, 209);
            flpKursi.Name = "flpKursi";
            flpKursi.Size = new Size(462, 215);
            flpKursi.TabIndex = 1;
            flpKursi.Paint += flpKursi_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(375, 480);
            label2.Name = "label2";
            label2.Size = new Size(126, 22);
            label2.TabIndex = 2;
            label2.Text = "Layar Bioskop";
            // 
            // btnPesan
            // 
            btnPesan.BackColor = Color.LimeGreen;
            btnPesan.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPesan.ForeColor = SystemColors.ButtonHighlight;
            btnPesan.Location = new Point(606, 494);
            btnPesan.Name = "btnPesan";
            btnPesan.Size = new Size(94, 29);
            btnPesan.TabIndex = 4;
            btnPesan.Text = "PESAN";
            btnPesan.UseVisualStyleBackColor = false;
            btnPesan.Click += btnPesan_Click;
            // 
            // txtKursiTerpilih
            // 
            txtKursiTerpilih.Location = new Point(363, 158);
            txtKursiTerpilih.Name = "txtKursiTerpilih";
            txtKursiTerpilih.Size = new Size(125, 27);
            txtKursiTerpilih.TabIndex = 5;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Red;
            btnKembali.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKembali.ForeColor = SystemColors.ButtonHighlight;
            btnKembali.Location = new Point(165, 494);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(94, 29);
            btnKembali.TabIndex = 6;
            btnKembali.Text = "KEMBALI";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormPilihKursi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.cinema_hall_screenshot_hires1;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(843, 581);
            Controls.Add(btnKembali);
            Controls.Add(txtKursiTerpilih);
            Controls.Add(btnPesan);
            Controls.Add(label2);
            Controls.Add(flpKursi);
            Controls.Add(label1);
            Name = "FormPilihKursi";
            Text = "FormPilihKursi";
            Load += FormPilihKursi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flpKursi;
        private Label label2;
        private Button btnPesan;
        private TextBox txtKursiTerpilih;
        private Button btnKembali;
    }
}