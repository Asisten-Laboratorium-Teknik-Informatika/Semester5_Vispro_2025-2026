using System;
using System.Windows.Forms;
using System.Drawing;
using CinemaTix.DAL;
using System.IO;
using System.Data;// Sesuaikan jika namespace DAL berbeda!

// Tambahkan using untuk FormPilihJadwal jika Form tersebut berada di subfolder/namespace lain
// using CinemaTix.Forms; 

namespace CinemaTix
{
    public partial class Form1 : Form // Pastikan HANYA ada satu deklarasi class ini!
    {
        private string _loggedInUser;
        public Form1(string username)
        {
            InitializeComponent();
            _loggedInUser = username;

            labelWelcome.Text = "Selamat datang, " + _loggedInUser + "!";
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            try
            {
                FilmDAL filmDAL = new FilmDAL();
                DataTable dtFilms = filmDAL.GetSemuaFilm();

                // Opsional: Sembunyikan kolom ID agar tidak terlihat oleh pengguna
                if (dtFilms != null)
                {
                    dgvFilms.RowTemplate.Height = 150;

                    dgvFilms.DataSource = dtFilms;

                    dgvFilms.RowTemplate.Height = 120;

                    if (!dgvFilms.Columns.Contains("Poster"))
                    {
                        DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                        imgCol.Name = "Poster";
                        imgCol.HeaderText = "Poster";
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        dgvFilms.Columns.Insert(0, imgCol); // Masukkan di indeks 0 (paling kiri)
                        dgvFilms.Columns["Poster"].Width = 100;
                    }

                    for (int i = 0; i < dtFilms.Rows.Count; i++)
                    {
                        // Dapatkan path dari kolom 'PathPoster' yang dimuat dari database
                        string path = dtFilms.Rows[i]["PathPoster"].ToString();

                        if (File.Exists(path))
                        {
                            try
                            {
                                // Muat gambar secara aman tanpa mengunci file
                                using (Image tempImg = Image.FromFile(path))
                                {
                                    Image img = new Bitmap(tempImg); // Membuat salinan
                                    dgvFilms.Rows[i].Cells["Poster"].Value = img;
                                }
                            }
                            catch (Exception imgEx)
                            {
                                // Handle jika gambar tidak dapat dimuat (misal, format rusak)
                                MessageBox.Show($"Gagal memuat gambar untuk baris {i}: {imgEx.Message}");
                            }
                        }
                    }
                    // 4. Sembunyikan kolom PathPoster dan FilmID
                    if (dgvFilms.Columns.Contains("PathPoster"))
                    {
                        dgvFilms.Columns["PathPoster"].Visible = false;
                    }
                    if (dgvFilms.Columns.Contains("FilmID"))
                    {
                        dgvFilms.Columns["FilmID"].Visible = false;
                    }

                    // Opsional: Atur agar judul film terlihat di samping poster
                    if (dgvFilms.Columns.Contains("Judul"))
                    {
                        dgvFilms.Columns["Judul"].DisplayIndex = 1; // Posisikan Judul setelah Poster
                    }

                    // --- END: KODE UNTUK MENAMBAHKAN POSTER ---
                }
                else
                {
                    MessageBox.Show("Tidak ada data film yang ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data film. Pastikan XAMPP (MySQL) berjalan dan koneksi benar. \nError: " + ex.Message, "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFilms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil FilmID dari kolom yang diklik
                int filmId = Convert.ToInt32(dgvFilms.Rows[e.RowIndex].Cells["FilmID"].Value);

                // Asumsi class FormPilihJadwal sudah dibuat
                FormPilihJadwal formJadwal = new FormPilihJadwal(filmId, _loggedInUser);
                formJadwal.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Tampilkan konfirmasi (Opsional, agar tidak terpencet tidak sengaja)
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Buat instance baru FormLogin
                FormLogin formLogin = new FormLogin();

                // 3. Tampilkan FormLogin
                formLogin.Show();

                // 4. Tutup Form Utama saat ini
                this.Close();
            }
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }

        private void dgvFilms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void miPesan_Click(object sender, EventArgs e)
        {
            // Buka FormHistory dan kirim username yang sedang login (_loggedInUser)
            FormHistory historyForm = new FormHistory(_loggedInUser);
            historyForm.ShowDialog(); // Gunakan ShowDialog agar fokus ke history dulu
        }
    }
}