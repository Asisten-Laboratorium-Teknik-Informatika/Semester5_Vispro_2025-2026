using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace budgetplanner
{
    public partial class Form3 : Form
    {
        private Form1 mainForm;

        public Form3(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            // CEK 1: Apakah mainForm null?
            if (mainForm == null)
            {
                MessageBox.Show("mainForm NULL!");
                return;
            }

            // CEK 2: Apakah pengeluaranList null?
            if (mainForm.pengeluaranList == null)
            {
                MessageBox.Show("pengeluaranList NULL!");
                return;
            }

            // ================== PER KATEGORI ==================

            // Makanan
            int totalMakanan = mainForm.pengeluaranList
                .Where(x => x.Kategori == "Makan dan Minum")
                .Sum(x => int.Parse(x.Jumlah));
            TotalMakanan.Text = $"Rp {totalMakanan:N0}";

            // Hiburan
            int totalHiburan = mainForm.pengeluaranList
                .Where(x => x.Kategori == "Hiburan")
                .Sum(x => int.Parse(x.Jumlah));
            TotalHiburan.Text = $"Rp {totalHiburan:N0}";

            // Belanja
            int totalBelanja = mainForm.pengeluaranList
                .Where(x => x.Kategori == "Belanja")
                .Sum(x => int.Parse(x.Jumlah));
            JumlahBelanja.Text = $"Rp {totalBelanja:N0}";

            // Transportasi
            int totalTransportasi = mainForm.pengeluaranList
                .Where(x => x.Kategori == "Transportasi")
                .Sum(x => int.Parse(x.Jumlah));
            JumlahTransportasi.Text = $"Rp {totalTransportasi:N0}";

            // Lainnya
            int totalLainnya = mainForm.pengeluaranList
                .Where(x => x.Kategori == "Lainnya")
                .Sum(x => int.Parse(x.Jumlah));
            JumlahLainnya.Text = $"Rp {totalLainnya:N0}";

            // ================= KATEGORI TERBANYAK =================

            var kategoriTotals = mainForm.pengeluaranList
                .GroupBy(x => x.Kategori)
                .Select(g => new
                {
                    Kategori = g.Key,
                    Total = g.Sum(i => int.Parse(i.Jumlah))
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            if (kategoriTotals.Count > 0)
            {
                KategoriTerbanyak.Text = kategoriTotals[0].Kategori +
                                         $" (Rp {kategoriTotals[0].Total:N0})";
            }
            else
            {
                KategoriTerbanyak.Text = "-";
            }


            // ================== RATA-RATA PENGELUARAN ==================

            if (mainForm.pengeluaranList.Count > 0)
            {
                double avg = mainForm.pengeluaranList
                    .Average(x => int.Parse(x.Jumlah));

                RataRataPengeluaran.Text = $"Rp {avg:N0}";
            }
            else
            {
                RataRataPengeluaran.Text = "-";
            }



            // Hitung total
            int totalPengeluaran = mainForm.pengeluaranList.Sum(i => int.Parse(i.Jumlah));
            TotalPengeluaran.Text = $"Rp {totalPengeluaran:N0}";

            TotalPengeluaran.Refresh();
            this.Refresh();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            mainForm.Show(); // Pakai Form1 yang asli
            this.Hide();            // Close Form3
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalPengeluaran_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeskripsiMakanan_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalMakanan_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeskripsiHiburan_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalHiburan_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeskripsiBelanja_TextChanged(object sender, EventArgs e)
        {

        }

        private void JumlahBelanja_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeskripsiTransportasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void JumlahTransportasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeskripsiLainnya_TextChanged(object sender, EventArgs e)
        {

        }

        private void JumlahLainnya_TextChanged(object sender, EventArgs e)
        {

        }

        private void KategoriTerbanyak_TextChanged(object sender, EventArgs e)
        {

        }

        private void RataRataPengeluaran_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            mainForm.form4.Show();
            this.Hide();
        }


        private void btnProfile_Click(object sender, EventArgs e)
        {
            mainForm.form5.Show();
            this.Hide();
        }

    }

    public class RoundedTextBox : UserControl
    {
        private TextBox textBox;
        private int borderRadius = 10;
        private Color borderColor = Color.Gray;
        private int borderSize = 2;

        public RoundedTextBox()
        {
            // Setup TextBox
            textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Segoe UI", 10F);

            // Setup UserControl
            this.Controls.Add(textBox);
            this.Padding = new Padding(10, 7, 10, 7);
            this.Size = new Size(250, 35);
            this.BackColor = Color.White;
        }

        // Properties yang bisa dicustom
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                this.Invalidate(); // Redraw
            }
        }

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        // Properti TextBox yang umum dipakai
        public override string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public string PlaceholderText
        {
            get => textBox.PlaceholderText;
            set => textBox.PlaceholderText = value;
        }

        public bool PasswordChar
        {
            get => textBox.UseSystemPasswordChar;
            set => textBox.UseSystemPasswordChar = value;
        }

        public bool Multiline
        {
            get => textBox.Multiline;
            set => textBox.Multiline = value;
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                textBox.BackColor = value;
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                textBox.Font = value;
            }
        }

        public Color TextColor
        {
            get => textBox.ForeColor;
            set => textBox.ForeColor = value;
        }

        // Event TextChanged
        public new event EventHandler TextChanged
        {
            add => textBox.TextChanged += value;
            remove => textBox.TextChanged -= value;
        }

        // Override Paint untuk bikin rounded border
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Bikin rounded rectangle path
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize : 1;

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - borderSize))
            using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                // Background
                this.Region = new Region(pathSurface);

                // Border
                if (borderSize >= 1)
                {
                    g.DrawPath(penBorder, pathBorder);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        // Helper method untuk bikin rounded path
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void UpdateControlHeight()
        {
            if (!textBox.Multiline)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox.MinimumSize = new Size(0, txtHeight);
                this.Height = textBox.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
    }
}
