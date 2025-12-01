using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CookLab
{
    public partial class ResepCard : UserControl
    {
        public int IdResep { get; set; }

        private int borderRadius = 10;
        private int borderSize = 2; // Ketebalan garis pinggir
        private Color borderColor = Color.MediumPurple;
        public ResepCard()
        {
            InitializeComponent();

            this.Click += (s, e) => { /* Kosongin aja, nanti dihandle di Recipe.cs */ };

            lblJudul.Click += (s, e) => this.OnClick(e);
            lblTanggal.Click += (s, e) => this.OnClick(e);
        }
        public void SetData(int id, string judul, DateTime tanggal)
        {
            IdResep = id;
            lblJudul.Text = judul;
            lblTanggal.Text = tanggal.ToString("dd MMMM yyyy");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            // Biar garisnya halus (anti-aliasing)
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(pathSurface); // Potong form jadi lengkung

                    // Gambar Border
                    graph.DrawPath(penSurface, pathSurface);
                    graph.DrawPath(penBorder, pathBorder);
                }
            }
            else // Kalau kotak biasa
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        // Fungsi bantuan buat ngitung lengkungan (Matematika ribet, abaikan aja isinya wkwk)
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
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
    }
}
