using LibVLCSharp.Shared;
using System;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class DoctorTrailer : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        private bool isFullscreen = true; // fullscreen awal

        public DoctorTrailer()
        {
            InitializeComponent();
            Core.Initialize();
            this.KeyPreview = true;

            // Inisialisasi VLC
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            // Hubungkan MediaPlayer ke videoView
            videoView1.MediaPlayer = _mediaPlayer;

            // Event double click fullscreen toggle
            videoView1.MouseDoubleClick += ToggleFullscreen;
        }

        // ===== LOAD FORM =====
        private void DoctorTrailer_Load(object sender, EventArgs e)
        {
            EnterFullScreen();

            string path = @"D:\ProjekBioskop\Bioskop\Bioskop\vidio\Doctor Strange Trailer.mp4";

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("FILE TIDAK DITEMUKAN:\n" + path);
                return;
            }

            // Putar video
            using (var media = new Media(_libVLC, path, FromType.FromPath))
            {
                _mediaPlayer.Play(media);
            }
        }

        // ===== FULLSCREEN SEPERTI SPIDERTRAILER =====
        private void EnterFullScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            videoView1.Dock = DockStyle.Fill;
        }

        private void ExitFullScreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            videoView1.Dock = DockStyle.Fill;
        }

        private void ToggleFullscreen(object sender, MouseEventArgs e)
        {
            if (isFullscreen)
                ExitFullScreen();
            else
                EnterFullScreen();

            isFullscreen = !isFullscreen;
        }

        // ===== ESC → KEMBALI KE SHOWFILM =====
        private void DoctorTrailer_KeyDown(object sender, KeyEventArgs e)
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
