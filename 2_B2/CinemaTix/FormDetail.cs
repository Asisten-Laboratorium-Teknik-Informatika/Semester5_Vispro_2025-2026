using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaTix.DAL;
using CinemaTix.Models;
using MySql.Data.MySqlClient;

namespace CinemaTix
{
    public partial class FormDetail : Form
    {
        private int _jadwalID;
        private List<KursiDetail> _kursiTerpilih;
        private string _namaCustomer;
        private int _totalHargaHitungan; // Variabel untuk menyimpan total harga

        // Constructor: Menerima ID, List Kursi, dan Nama User
        public FormDetail(int jadwalId, List<KursiDetail> kursiTerpilih, string namaCustomer)
        {
            InitializeComponent();
            _jadwalID = jadwalId;
            _kursiTerpilih = kursiTerpilih;
            _namaCustomer = namaCustomer;
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {
            // 1. Set data yang sudah ada (Kursi & Customer)
            lblCustomer.Text = _namaCustomer;

            // Menggabungkan list kursi menjadi string (contoh: "A1, A2, B3")
            string daftarKursi = string.Join(", ", _kursiTerpilih.Select(k => k.Baris + k.Nomor));
            lblKursi.Text = daftarKursi;

            // 2. Ambil detail film dari database
            LoadDataJadwal();
        }

        private void LoadDataJadwal()
        {
            // Query untuk mengambil Judul Film, Nama Studio, dan Harga
            string query = @"
                SELECT 
                    F.Judul, 
                    S.NamaStudio, 
                    S.StudioID,
                    J.TanggalTayang, 
                    J.JamMulai, 
                    J.Harga
                FROM Jadwal J
                JOIN Films F ON J.FilmID = F.FilmID
                JOIN Studio S ON J.StudioID = S.StudioID
                WHERE J.JadwalID = @JadwalID";

            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JadwalID", _jadwalID);
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // --- MAPPING KE UI (Sesuaikan nama label Anda) ---

                                lblJudul.Text = reader["Judul"].ToString();

                                // Tampilkan ID Studio yang besar (angka 1 di desain Anda)
                                lblNoStudio.Text = reader["StudioID"].ToString();

                                // Tampilkan Nama/Tipe Studio (Legend/Epic)
                                lblTipeStudio.Text = reader["NamaStudio"].ToString();

                                // Format Tanggal
                                DateTime tgl = Convert.ToDateTime(reader["TanggalTayang"]);
                                lblJadwal.Text = tgl.ToString("yyyy-MM-dd");

                                // Format Jam
                                TimeSpan jam = (TimeSpan)reader["JamMulai"];
                                lblWaktu.Text = jam.ToString(@"hh\:mm");

                                // Hitung Total Harga
                                int hargaSatuan = Convert.ToInt32(reader["Harga"]);
                                _totalHargaHitungan = hargaSatuan * _kursiTerpilih.Count;

                                // Format Rupiah
                                lblHarga.Text = "Rp. " + _totalHargaHitungan.ToString("N0");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memuat detail: " + ex.Message);
                    }
                }
            }
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTgl_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblWaktu_Click(object sender, EventArgs e)
        {

        }

        private void lblFilmDT_Click(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // 1. Ambil jumlah tiket dari list kursi yang dibawa saat ini
            int jumlahTiket = _kursiTerpilih.Count;

            // 2. Buka kembali FormPilihKursi
            // Ingat Constructor FormPilihKursi butuh 3 hal: (JadwalID, JumlahTiket, Username)
            FormPilihKursi formKursi = new FormPilihKursi(_jadwalID, jumlahTiket, _namaCustomer);

            formKursi.Show();

            // 3. Tutup Form Detail saat ini
            this.Close();
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            try
            {
                PemesananDAL pemesananDAL = new PemesananDAL();

                // Simpan ke database
                bool sukses = pemesananDAL.SimpanTransaksi(_jadwalID, _namaCustomer, _totalHargaHitungan, _kursiTerpilih);

                if (sukses)
                {
                    MessageBox.Show("Pemesanan Berhasil Disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 1. Buat Instance Form1 Baru
                    // Kita kirim _namaCustomer agar label "Selamat Datang" tetap berisi nama user
                    Form1 formUtama = new Form1(_namaCustomer);

                    // 2. Tampilkan Form1
                    formUtama.Show();

                    // 3. Tutup Form Detail saat ini
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan pemesanan: " + ex.Message, "Error Database");
            }
        }
    }
}
