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


namespace KamarKos
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MakeRounded(Panel p, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(p.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(p.Width - radius, p.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, p.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            p.Region = new Region(path);
        }

        private void btnKamar_Click(object sender, EventArgs e)
        {
            FormKamar frm = new FormKamar(this);
            this.Hide();
            frm.Show();

        }
        private void btnPenghuni_Click(object sender, EventArgs e)
        {
            FormPenghuni frm = new FormPenghuni(this);
            this.Hide();
            frm.Show();
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            FormPembayaran frm = new FormPembayaran(this);
            this.Hide();
            frm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Apakah Anda yakin ingin logout?",
              "Konfirmasi",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
          );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
            }
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            MakeRounded(panel1, 20);
            MakeRounded(panel2, 20);
            MakeRounded(panel3, 20);
            MakeRounded(panel4, 20);

            panel1.BackColor = Color.FromArgb(230, 240, 255);
            panel1.BorderStyle = BorderStyle.None;

            panel2.BackColor = Color.FromArgb(230, 240, 255);
            panel2.BorderStyle = BorderStyle.None;

            panel3.BackColor = Color.FromArgb(230, 240, 255);
            panel3.BorderStyle = BorderStyle.None;

            panel4.BackColor = Color.FromArgb(230, 240, 255);
            panel4.BorderStyle = BorderStyle.None;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void PanelBorderBlue(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            using (Pen pen = new Pen(Color.FromArgb(30, 90, 180), 2))
            {
                int radius = 20;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(p.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(p.Width - radius, p.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, p.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
