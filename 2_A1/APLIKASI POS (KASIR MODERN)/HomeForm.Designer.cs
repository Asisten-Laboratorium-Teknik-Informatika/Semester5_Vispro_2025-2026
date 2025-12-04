namespace APLIKASI_POS_KASIR_MODERN
{
    partial class HomeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelPendapatan = new System.Windows.Forms.Panel();
            this.lblPendapatanLabel = new System.Windows.Forms.Label();
            this.lblPendapatan = new System.Windows.Forms.Label();
            this.panelProduk = new System.Windows.Forms.Panel();
            this.lblProdukLabel = new System.Windows.Forms.Label();
            this.lblTotalProduk = new System.Windows.Forms.Label();
            this.panelTransaksi = new System.Windows.Forms.Panel();
            this.lblTransaksiLabel = new System.Windows.Forms.Label();
            this.lblTotalTransaksi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelPendapatan.SuspendLayout();
            this.panelProduk.SuspendLayout();
            this.panelTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Wheat;
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(3, 41);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(209, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "DASHBOARD C-PAY";
            // 
            // panelPendapatan
            // 
            this.panelPendapatan.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panelPendapatan.Controls.Add(this.lblPendapatanLabel);
            this.panelPendapatan.Controls.Add(this.lblPendapatan);
            this.panelPendapatan.Location = new System.Drawing.Point(47, 180);
            this.panelPendapatan.Name = "panelPendapatan";
            this.panelPendapatan.Size = new System.Drawing.Size(300, 150);
            this.panelPendapatan.TabIndex = 1;
            // 
            // lblPendapatanLabel
            // 
            this.lblPendapatanLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPendapatanLabel.ForeColor = System.Drawing.Color.White;
            this.lblPendapatanLabel.Location = new System.Drawing.Point(10, 10);
            this.lblPendapatanLabel.Name = "lblPendapatanLabel";
            this.lblPendapatanLabel.Size = new System.Drawing.Size(202, 37);
            this.lblPendapatanLabel.TabIndex = 0;
            this.lblPendapatanLabel.Text = "Total Pendapatan";
            // 
            // lblPendapatan
            // 
            this.lblPendapatan.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPendapatan.ForeColor = System.Drawing.Color.White;
            this.lblPendapatan.Location = new System.Drawing.Point(10, 60);
            this.lblPendapatan.Name = "lblPendapatan";
            this.lblPendapatan.Size = new System.Drawing.Size(100, 70);
            this.lblPendapatan.TabIndex = 1;
            this.lblPendapatan.Text = "Rp 0";
            // 
            // panelProduk
            // 
            this.panelProduk.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panelProduk.Controls.Add(this.lblProdukLabel);
            this.panelProduk.Controls.Add(this.lblTotalProduk);
            this.panelProduk.Location = new System.Drawing.Point(407, 180);
            this.panelProduk.Name = "panelProduk";
            this.panelProduk.Size = new System.Drawing.Size(300, 150);
            this.panelProduk.TabIndex = 2;
            this.panelProduk.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProduk_Paint);
            // 
            // lblProdukLabel
            // 
            this.lblProdukLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProdukLabel.ForeColor = System.Drawing.Color.White;
            this.lblProdukLabel.Location = new System.Drawing.Point(10, 10);
            this.lblProdukLabel.Name = "lblProdukLabel";
            this.lblProdukLabel.Size = new System.Drawing.Size(255, 37);
            this.lblProdukLabel.TabIndex = 0;
            this.lblProdukLabel.Text = "Total Produk Terjual";
            // 
            // lblTotalProduk
            // 
            this.lblTotalProduk.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalProduk.ForeColor = System.Drawing.Color.White;
            this.lblTotalProduk.Location = new System.Drawing.Point(10, 60);
            this.lblTotalProduk.Name = "lblTotalProduk";
            this.lblTotalProduk.Size = new System.Drawing.Size(100, 70);
            this.lblTotalProduk.TabIndex = 1;
            this.lblTotalProduk.Text = "0";
            // 
            // panelTransaksi
            // 
            this.panelTransaksi.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panelTransaksi.Controls.Add(this.lblTransaksiLabel);
            this.panelTransaksi.Controls.Add(this.lblTotalTransaksi);
            this.panelTransaksi.Location = new System.Drawing.Point(767, 180);
            this.panelTransaksi.Name = "panelTransaksi";
            this.panelTransaksi.Size = new System.Drawing.Size(300, 150);
            this.panelTransaksi.TabIndex = 3;
            // 
            // lblTransaksiLabel
            // 
            this.lblTransaksiLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTransaksiLabel.ForeColor = System.Drawing.Color.White;
            this.lblTransaksiLabel.Location = new System.Drawing.Point(10, 10);
            this.lblTransaksiLabel.Name = "lblTransaksiLabel";
            this.lblTransaksiLabel.Size = new System.Drawing.Size(228, 37);
            this.lblTransaksiLabel.TabIndex = 0;
            this.lblTransaksiLabel.Text = "Total Transaksi";
            // 
            // lblTotalTransaksi
            // 
            this.lblTotalTransaksi.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalTransaksi.ForeColor = System.Drawing.Color.White;
            this.lblTotalTransaksi.Location = new System.Drawing.Point(10, 60);
            this.lblTotalTransaksi.Name = "lblTotalTransaksi";
            this.lblTotalTransaksi.Size = new System.Drawing.Size(100, 70);
            this.lblTotalTransaksi.TabIndex = 1;
            this.lblTotalTransaksi.Text = "0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(40, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Penjualan Terbaru";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(47, 404);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 300);
            this.dataGridView1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(388, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 47);
            this.label2.TabIndex = 6;
            this.label2.Text = "WELCOME TO C-PAY";
            // 
            // HomeForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelPendapatan);
            this.Controls.Add(this.panelProduk);
            this.Controls.Add(this.panelTransaksi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelHeader.ResumeLayout(false);
            this.panelPendapatan.ResumeLayout(false);
            this.panelProduk.ResumeLayout(false);
            this.panelTransaksi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcome;

        private System.Windows.Forms.Panel panelPendapatan;
        private System.Windows.Forms.Label lblPendapatanLabel;
        private System.Windows.Forms.Label lblPendapatan;

        private System.Windows.Forms.Panel panelProduk;
        private System.Windows.Forms.Label lblProdukLabel;
        private System.Windows.Forms.Label lblTotalProduk;

        private System.Windows.Forms.Panel panelTransaksi;
        private System.Windows.Forms.Label lblTransaksiLabel;
        private System.Windows.Forms.Label lblTotalTransaksi;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
    }
}
