using LibVLCSharp.Shared;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class SpiderTrailer : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        private bool isFullscreen = true; // FULLSCREEN AWAL
        private FormBorderStyle oldBorder;
        private Rectangle oldBounds;

        public SpiderTrailer()
        {
            InitializeComponent();
            Core.Initialize();

            this.KeyPreview = true;

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mediaPlayer;

            // DOUBLE CLICK → toggle fullscreen
            videoView1.MouseDoubleClick += ToggleFullscreen;
        }

        private void SpiderTrailer_Load(object sender, EventArgs e)
        {
            oldBorder = this.FormBorderStyle;
            oldBounds = this.Bounds;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            videoView1.Dock = DockStyle.Fill;

            string path = @"D:\ProjekBioskop\Bioskop\Bioskop\vidio\SPIDER-MAN NO WAY HOME.mp4";

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("FILE TIDAK DITEMUKAN:\n" + path);
                return;
            }

            using (var media = new Media(_libVLC, path, FromType.FromPath))
            {
                _mediaPlayer.Play(media);
            }
        }

        // ==============================
        // DOUBLE-CLICK → TOGGLE FULLSCREEN 
        // ==============================
        private void ToggleFullscreen(object sender, MouseEventArgs e)
        {
            if (isFullscreen)
            {
                // KELUAR FULLSCREEN
                this.FormBorderStyle = oldBorder;
                this.Bounds = oldBounds;
                isFullscreen = false;
            }
            else
            {
                // MASUK FULLSCREEN
                oldBorder = this.FormBorderStyle;
                oldBounds = this.Bounds;

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                isFullscreen = true;
            }

            videoView1.Dock = DockStyle.Fill;
        }

        // ==============================
        // ESC → kembali ke ShowFilm
        // ==============================
        private void SpiderTrailer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _mediaPlayer.Stop();

                ShowFilm sf = new ShowFilm();
                sf.Show();

                this.Close();
            }
        }

        private void videoView1_Click(object sender, EventArgs e) { }
    }
}
