using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaTix.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CinemaTix
{
    public partial class FormPilihKursi : Form
    {
        private int _jadwalID;
        private int _jumlahTiket;
        private KursiDAL _kursiDAL = new KursiDAL(); // Inisialisasi DAL
        private List<KursiDetail> _listKursi;
        private string _username;

        // Asumsi Anda menggunakan FlowLayoutPanel bernama flpKursi
        // dan TextBox untuk menampilkan status kursi yang dipilih, misal: txtKursiTerpilih

        // KONSTRUKTOR (PENTING: Pastikan ini sama dengan kode di Konfirmasi)
        public FormPilihKursi(int jadwalId, int jumlahTiket, string username)
        {
            InitializeComponent();
            _jadwalID = jadwalId;
            _jumlahTiket = jumlahTiket;
            _username = username;

            // Panggil fungsi saat form dimuat
            this.Load += new EventHandler(FormPilihKursi_Load);
        }

        private void FormPilihKursi_Load(object sender, EventArgs e)
        {
            // 1. Ambil data kursi dari database
            LoadKursiData();

            // 2. Tampilkan kursi sebagai tombol di UI
            DisplayKursiButtons();
        }

        private void LoadKursiData()
        {
            try
            {
                // Panggil DAL untuk mendapatkan status kursi berdasarkan ID Jadwal
                _listKursi = _kursiDAL.GetStatusKursiByJadwal(_jadwalID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat data kursi: " + ex.Message);
            }
        }

        private void DisplayKursiButtons()
        {
            // Pastikan FlowLayoutPanel sudah bersih
            flpKursi.Controls.Clear();

            if (_listKursi == null || _listKursi.Count == 0)
            {
                MessageBox.Show("Tidak ada data kursi ditemukan untuk jadwal ini.");
                return;
            }

            foreach (var kursi in _listKursi)
            {
                Button btnKursi = new Button();
                btnKursi.Text = $"{kursi.Baris}{kursi.Nomor}"; // Contoh: A1, B5
                btnKursi.Tag = kursi; // Menyimpan objek KursiDetail di Tag

                // Atur Warna berdasarkan Status
                if (kursi.StatusKursi == "Terisi")
                {
                    btnKursi.BackColor = System.Drawing.Color.Red;
                    btnKursi.Enabled = false; // Kursi terisi tidak bisa dipilih
                }
                else
                {
                    btnKursi.BackColor = System.Drawing.Color.LightGray;
                    btnKursi.Click += BtnKursi_Click;
                }

                btnKursi.Size = new System.Drawing.Size(40, 40);
                flpKursi.Controls.Add(btnKursi);
            }
        }

        private List<KursiDetail> selectedSeats = new List<KursiDetail>();

        private void BtnKursi_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            KursiDetail kursi = clickedButton.Tag as KursiDetail;

            if (selectedSeats.Contains(kursi))
            {
                // Hapus kursi jika sudah dipilih
                selectedSeats.Remove(kursi);
                clickedButton.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                // Tambahkan kursi jika belum dipilih DAN belum melebihi batas jumlah tiket
                if (selectedSeats.Count < _jumlahTiket)
                {
                    selectedSeats.Add(kursi);
                    clickedButton.BackColor = System.Drawing.Color.Yellow; // Tanda dipilih
                }
                else
                {
                    MessageBox.Show($"Anda hanya bisa memilih {_jumlahTiket} kursi.");
                }
            }

            // Update tampilan kursi yang dipilih
            UpdateKursiTerpilihDisplay();
        }

        private void UpdateKursiTerpilihDisplay()
        {
            string selectedList = string.Join(", ", selectedSeats.Select(k => $"{k.Baris}{k.Nomor}"));
            txtKursiTerpilih.Text = selectedList;
        }

        // --- TOMBOL PESAN/LANJUT ---

        private void btnPesan_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count != _jumlahTiket)
            {
                MessageBox.Show($"Harap pilih tepat {_jumlahTiket} kursi.");
                return;
            }
            FormDetail formDetail = new FormDetail(_jadwalID, selectedSeats, _username);
            formDetail.ShowDialog();
            this.Close();
        }

        private void flpKursi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtKursiTerpilih_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            JadwalDAL jadwalDAL = new JadwalDAL();
            int filmID = jadwalDAL.GetFilmIDByJadwal(_jadwalID);

            // 2. Buka FormPilihJadwal
            // Kirim FilmID dan Username
            FormPilihJadwal formJadwal = new FormPilihJadwal(filmID, _username);
            formJadwal.Show();

            // 3. Tutup Form Kursi
            this.Close();
        }
    }
}
