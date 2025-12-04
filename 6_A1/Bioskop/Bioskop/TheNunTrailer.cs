using LibVLCSharp.Shared;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class TheNunTrailer : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        private bool isFullscreen = true; // fullscreen awal
        private FormBorderStyle oldBorder;
        private Rectangle oldBounds;

        public TheNunTrailer()
        {
            InitializeComponent();
            Core.Initialize();

            this.KeyPreview = true;

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            videoView1.MediaPlayer = _mediaPlayer;

            // DOUBLE-CLICK EVENT
            videoView1.MouseDoubleClick += ToggleFullscreen;
        }

        private void TheNunTrailer_Load(object sender, EventArgs e)
        {
            // ================
            // FULL SCREEN AWAL
            // ================
            oldBorder = this.FormBorderStyle;
            oldBounds = this.Bounds;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            videoView1.Dock = DockStyle.Fill;

            string path = @"D:\ProjekBioskop\Bioskop\Bioskop\vidio\THE-NUN-II-OFFICIAL.mp4";

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("FILE VIDEO TIDAK DITEMUKAN:\n" + path);
                return;
            }

            using (var media = new Media(_libVLC, path, FromType.FromPath))
            {
                _mediaPlayer.Play(media);
            }
        }

        // ==============================
        // TOGGLE FULLSCREEN DENGAN DOUBLE CLICK
        // ==============================
        private void ToggleFullscreen(object sender, MouseEventArgs e)
        {
            if (isFullscreen)
            {
                // keluar fullscreen
                this.FormBorderStyle = oldBorder;
                this.Bounds = oldBounds;
                isFullscreen = false;
            }
            else
            {
                // masuk fullscreen
                oldBorder = this.FormBorderStyle;
                oldBounds = this.Bounds;

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                isFullscreen = true;
            }

            videoView1.Dock = DockStyle.Fill;
        }

        // ==============================
        // ESC → KEMBALI KE SHOWFILM
        // ==============================
       

        private void TheNunII_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _mediaPlayer.Stop();

                ShowFilm sf = new ShowFilm();
                sf.Show();

                this.Close();
            }
        }

        private void videoView1_Click(object sender, EventArgs e)
        {

        }
    }
}
