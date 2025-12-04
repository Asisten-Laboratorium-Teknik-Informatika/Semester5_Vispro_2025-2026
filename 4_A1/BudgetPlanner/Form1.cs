using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace budgetplanner
{
    public partial class Form1 : Form
    {

        private Form1 mainForm;
        public int currentUserId;
        public Form3 form3;
        public Form5 form5;
        public Form4 form4;


        public Form1()
        {
            InitializeComponent();
            InitForms();
        }

        public Form1(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            InitForms();
        }

        private void InitForms()
        {
            form3 = new Form3(this);
            form4 = new Form4(this);
            form5 = new Form5(this);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            LoadTransaksi();



            UpdateDisplay();

            // tombol home
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

            form4 = new Form4(this);


        }

        public void UpdateDisplay()
        {
            // Hitung total dari semua pemasukan
            int totalpemasukan = pemasukanList.Sum(item => int.Parse(item.Jumlah));

            // Total pengeluaran
            int totalPengeluaran = pengeluaranList.Sum(item => int.Parse(item.Jumlah));

            // Tampilkan hanya total
            txtPemasukan.Text = $"Rp {totalpemasukan}";
            txtPengeluaran.Text = $"Rp {totalPengeluaran}";

            UpdateSaran();
        }

        public void AddPemasukan(string jumlah, int userId)
        {
            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            try
            {
                db.OpenConnection();

                string query = "INSERT INTO transaksi (jenis, jumlah, kategori, deskripsi, tanggal, user_id) " +
                                "VALUES ('Pemasukan', @jumlah, '', '', NOW(), @user_id)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);
                cmd.Parameters.AddWithValue("@user_id", userId);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                db.CloseConnection();
            }

            LoadTransaksi();
            UpdateDisplay();
        }


        public void AddPengeluaran(string jumlah, string kategori, string deskripsi, int userId)
        {
            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            try
            {
                db.OpenConnection();

                string query = "INSERT INTO transaksi (jenis, jumlah, kategori, deskripsi, tanggal, user_id) " +
                               "VALUES ('Pengeluaran', @jumlah, @kategori, @deskripsi, NOW(), @user_id)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);
                cmd.Parameters.AddWithValue("@kategori", kategori);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                cmd.Parameters.AddWithValue("@user_id", userId);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                db.CloseConnection();
            }

            LoadTransaksi();
            UpdateDisplay();
        }

        public void LoadTransaksi()
        {
            pengeluaranList.Clear();
            pemasukanList.Clear();

            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            db.OpenConnection();

            string query = "SELECT * FROM transaksi WHERE user_id = @userId";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", currentUserId);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Transaksi t = new Transaksi();
                t.Jenis = reader["jenis"].ToString();
                t.Jumlah = reader["jumlah"].ToString();
                t.Kategori = reader["kategori"].ToString();
                t.Deskripsi = reader["deskripsi"].ToString();
                t.Tanggal = Convert.ToDateTime(reader["tanggal"]);

                if (t.Jenis == "Pemasukan")
                    pemasukanList.Add(t);
                else
                    pengeluaranList.Add(t);
            }

            reader.Close();
            db.CloseConnection();
        }





        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        public List<Transaksi> pengeluaranList = new List<Transaksi>();


        public List<Transaksi> pemasukanList = new List<Transaksi>();


        private void customRoundedButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this, form4);
            form2.Show();
            this.Hide();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            ReloadData();
            UpdateDisplay();

            form3.UpdateDisplay();
            form3.Show();
            this.Hide();

        }


        private void txtPemasukan_TextChanged(object sender, EventArgs e)
        {

        }

        public void ReloadData()
        {
            LoadTransaksi();

            UpdateDisplay();
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ReloadData(); // Reload tiap kali Form1 muncul
            }
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            form4.Show();
            this.Hide();

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            form5.Show();
            this.Hide();
        }

        private void txtBoxSaran_TextChanged(object sender, EventArgs e)
        {

        }

        public void UpdateSaran()
        {
            int totalPemasukan = pemasukanList.Count > 0 ? pemasukanList.Sum(x => int.Parse(x.Jumlah)) : 0;
            int totalPengeluaran = pengeluaranList.Count > 0 ? pengeluaranList.Sum(x => int.Parse(x.Jumlah)) : 0;

            if (totalPemasukan == 0 && totalPengeluaran == 0)
            {
                txtBoxSaran.Text = "Mulailah mencatat pemasukan dan pengeluaran agar aplikasi bisa memberikan analisis untukmu!";
                return;
            }

            if (totalPemasukan == 0 && totalPengeluaran > 0)
            {
                txtBoxSaran.Text = "Kamu belum mencatat pemasukan. Tambahkan pemasukan agar aplikasi bisa menghitung kondisi keuangan dengan benar.";
                return;
            }

            if (totalPengeluaran == 0 && totalPemasukan > 0)
            {
                txtBoxSaran.Text = "Kamu belum mencatat pengeluaran. Catat semua pengeluaran agar analisis lebih akurat.";
                return;
            }

            int selisih = totalPemasukan - totalPengeluaran;
            double borosMeter = (double)totalPengeluaran / totalPemasukan * 100;

            // =============================
            //         SARAN UTAMA
            // =============================

            // 1. Jika defisit (pengeluaran > pemasukan)
            if (totalPengeluaran > totalPemasukan)
            {
                txtBoxSaran.Text =
                    "⚠️ Pengeluaran kamu lebih besar dari pemasukan!\r\n" +
                    "Ini tanda defisit. Kurangi pengeluaran tidak penting dan evaluasi belanja harian.";
                return;
            }

            // 2. Jika pengeluaran > 85% pemasukan
            if (borosMeter > 85)
            {
                txtBoxSaran.Text =
                    "⚠️ Pengeluaran kamu sudah lebih dari 85% dari pemasukan.\r\n" +
                    "Ini sangat riskan. Pertimbangkan mengurangi pengeluaran untuk beberapa hari ke depan.";
                return;
            }

            if (totalPemasukan == totalPengeluaran)
            {
                txtBoxSaran.Text =
                    "⚠️ Pengeluaran kamu sudah setara dengan pemasukan.\r\n" +
                    "Ini sangat riskan. Pertimbangkan mengurangi pengeluaran untuk beberapa hari ke depan.";
                return;
            }

            // 3. Margin tipis (selisih ≤ 15% pemasukan → hampir habis)
            if (selisih <= totalPemasukan * 0.15)
            {
                txtBoxSaran.Text =
                    "🔎 Pemasukan kamu hanya sedikit lebih tinggi daripada pengeluaran.\r\n" +
                    "Coba kurangi sedikit pengeluaran agar kondisi tetap aman.";
                return;
            }

            // 4. Jika margin besar → saran menabung
            if (selisih >= totalPemasukan * 0.30)
            {
                txtBoxSaran.Text =
                    "🎉 Keuangan kamu cukup sehat! Pemasukan jauh lebih tinggi dari pengeluaran.\r\n" +
                    $"Cobalah menyisihkan sekitar 10–20% dari pemasukan untuk ditabung.";
                return;
            }

            // 5. Kondisi normal
            txtBoxSaran.Text =
                "👍 Keuangan kamu cukup seimbang. Pertahankan pengeluaran yang terkontrol dan tetap catat pemasukan/pengeluaran dengan rutin.";
        }

        private void panelcontrol_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class CustomRoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 20;
        public int BorderThickness { get; set; } = 2;
        public Color BorderColor { get; set; } = Color.Gray;
        public Color FillColor { get; set; } = Color.White;

        public CustomRoundedPanel()
        {
            this.DoubleBuffered = true;
            this.Resize += (s, e) => this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Biar tidak keluar garis
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderThickness, -BorderThickness);

            int radius = BorderRadius * 2;

            using (GraphicsPath pathSurface = GetRoundPath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetRoundPath(rectBorder, BorderRadius - BorderThickness / 2))
            using (Pen penBorder = new Pen(BorderColor, BorderThickness))
            using (SolidBrush brush = new SolidBrush(FillColor))
            {
                // Gambar background panel
                e.Graphics.FillPath(brush, pathSurface);

                // Gambar border
                if (BorderThickness > 0)
                    e.Graphics.DrawPath(penBorder, pathBorder);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    public class CustomRoundedButton : Button
    {
        private int borderRadius = 20;
        private int borderSize = 1;
        private Color borderColor = Color.Gray;
        private Color fillColor = Color.White;
        private Color hoverColor = Color.Empty;
        private Color pressedColor = Color.Empty;
        private bool isMouseOver = false;
        private bool isMouseDown = false;

        [Category("Appearance")]
        [Description("Radius sudut (px)")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = Math.Max(0, value); InvalidateRegion(); }
        }

        [Category("Appearance")]
        [Description("Tebal garis border")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Warna border")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Warna isi tombol")]
        public Color FillColor
        {
            get => fillColor;
            set { fillColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Warna saat mouse hover (jika kosong gunakan FillColor)")]
        public Color HoverColor
        {
            get => hoverColor;
            set { hoverColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Warna saat mouse down (jika kosong gunakan FillColor)")]
        public Color PressedColor
        {
            get => pressedColor;
            set { pressedColor = value; Invalidate(); }
        }

        public CustomRoundedButton()
        {
            // Agar kita yang menggambar
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            // default colors
            hoverColor = Color.Empty;
            pressedColor = Color.Empty;

            // double buffer untuk mencegah flicker
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            // update region pada resize
            this.Resize += (s, e) => InvalidateRegion();
        }

        private void InvalidateRegion()
        {
            // Update region agar bentuk klik mengikuti rounded corners
            if (BorderRadius > 0)
            {
                using (GraphicsPath path = GetRoundedPath(ClientRectangle, BorderRadius))
                {
                    this.Region = new Region(path);
                }
            }
            else
            {
                this.Region = null;
            }

            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isMouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseOver = false;
            isMouseDown = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isMouseDown = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = ClientRectangle;

            // background color depending state
            Color fill = fillColor;
            if (isMouseDown && pressedColor != Color.Empty) fill = pressedColor;
            else if (isMouseOver && hoverColor != Color.Empty) fill = hoverColor;

            // If no hover/pressed colors set, we can slightly darken/lighten automatically
            if (isMouseOver && hoverColor == Color.Empty && !isMouseDown)
                fill = ControlPaint.Light(fillColor, 0.05f);
            if (isMouseDown && pressedColor == Color.Empty)
                fill = ControlPaint.Dark(fillColor, 0.08f);

            using (GraphicsPath path = GetRoundedPath(rect, borderRadius))
            using (SolidBrush brush = new SolidBrush(fill))
            using (Pen pen = new Pen(borderColor, borderSize))
            {
                // fill
                pevent.Graphics.FillPath(brush, path);

                // border (draw inside bounds so it doesn't clip)
                if (borderSize > 0)
                {
                    // adjust rectangle for border so it draws inside
                    Rectangle borderRect = Rectangle.Inflate(rect, -borderSize / 2, -borderSize / 2);
                    using (GraphicsPath borderPath = GetRoundedPath(borderRect, Math.Max(0, borderRadius - borderSize / 2)))
                    {
                        pevent.Graphics.DrawPath(pen, borderPath);
                    }
                }
            }

            // Draw image + text (let TextRenderer handle layout)
            DrawIconAndText(pevent.Graphics, rect);

            // focus rectangle for keyboard focus
            if (Focused && ShowFocusCues)
            {
                Rectangle focusRect = rect;
                focusRect.Inflate(-6, -6);
                ControlPaint.DrawFocusRectangle(pevent.Graphics, focusRect);
            }
        }

        private void DrawIconAndText(Graphics g, Rectangle rect)
        {
            // Use TextRenderer so it respects Text and Font and supports GDI text rendering (clear)
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;

            // If image exists, draw image left then text
            int padding = 8;
            int imageSpacing = 6;
            Rectangle textRect = rect;
            if (this.Image != null)
            {
                Size imgSize = this.Image.Size;
                // scale down image if too big
                int maxImgHeight = rect.Height - padding * 2;
                if (imgSize.Height > maxImgHeight)
                {
                    float scale = (float)maxImgHeight / imgSize.Height;
                    imgSize = new Size((int)(imgSize.Width * scale), (int)(imgSize.Height * scale));
                }

                // position image on left center
                Point imgPos = new Point(rect.Left + padding, rect.Top + (rect.Height - imgSize.Height) / 2);
                g.DrawImage(this.Image, new Rectangle(imgPos, imgSize));

                // adjust text rect to the right of image
                textRect = new Rectangle(imgPos.X + imgSize.Width + imageSpacing, rect.Top, rect.Width - (imgPos.X + imgSize.Width + imageSpacing - rect.Left) - padding, rect.Height);
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            }
            else
            {
                // no image -> centered text
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;
                textRect = Rectangle.Inflate(rect, -padding, -padding);
            }

            // draw text
            TextRenderer.DrawText(g, this.Text, this.Font, textRect, this.ForeColor, flags);
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // top-left
            path.AddArc(arcRect, 180, 90);

            // top-right
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // bottom-right
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // bottom-left
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }

        // ensure keyboard "Enter"/Space triggers Click (inherited already) and TabStop works
        protected override bool IsInputKey(Keys keyData)
        {
            // Keep default behavior
            return base.IsInputKey(keyData);
        }
    }

}
