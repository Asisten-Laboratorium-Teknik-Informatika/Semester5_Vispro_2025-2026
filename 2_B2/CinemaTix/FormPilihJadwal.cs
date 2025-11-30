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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CinemaTix
{
    // Pastikan sekarang ada di sini!
    public partial class FormPilihJadwal : Form
    {
        private int _filmID;
        private DataTable _dtJadwal;
        private string _username;
        // Constructor yang menerima FilmID
        public FormPilihJadwal(int filmId, string username)
        {
            InitializeComponent();
            _filmID = filmId;
            _username = username;
        }
        private void FormPilihJadwal_Load(object sender, EventArgs e)
        {
            FilmDAL filmDAL = new FilmDAL();
            DataRow drFilm = filmDAL.GetFilmByID(_filmID);


            if (drFilm != null)
            {
                string judulFilm = drFilm["Judul"].ToString();

                // Cek tipe kontrol film Anda:

                txtFilm.Text = judulFilm;
            }
            else
            {
                MessageBox.Show("Gagal menemukan detail film.", "Error");
                this.Close();
            }
            JadwalDAL jadwalDAL = new JadwalDAL();
            _dtJadwal = jadwalDAL.GetJadwalByFilm(_filmID);

            List<JadwalDisplay> listJadwalDisplay = new List<JadwalDisplay>();

            if (_dtJadwal != null && _dtJadwal.Rows.Count > 0)
            {
                foreach (DataRow row in _dtJadwal.Rows)
                {
                    string tanggalWaktuFormatted = row["TanggalWaktu"].ToString();
                    string namaStudio = row["NamaStudio"].ToString();
                    string displayText = $"{tanggalWaktuFormatted} - {namaStudio} (Rp {row["Harga"]:N0})";

                    listJadwalDisplay.Add(new JadwalDisplay
                    {
                        JadwalID = Convert.ToInt32(row["JadwalID"]),
                        DisplayText = displayText,
                        NamaStudio = namaStudio
                    });
                }
                cbJadwal.DataSource = listJadwalDisplay;
                cbJadwal.DisplayMember = "DisplayText";
                cbJadwal.ValueMember = "JadwalID";

                cbJadwal.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Tidak ada jadwal tersedia untuk film ini.", "Informasi");
                this.Close();
            }
            // Opsi: Isi ComboBox Jumlah (1 sampai 10)
            for (int i = 1; i <= 10; i++)
            {
                cbJumlah.Items.Add(i);
            }
            cbJumlah.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbJadwal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pastikan ada item yang dipilih
            if (cbJadwal.SelectedItem != null)
            {
                // Ambil DataRowView dari item yang dipilih
                JadwalDisplay selectedItem = cbJadwal.SelectedItem as JadwalDisplay;

                if (selectedItem != null)
                {
                    txtStudio.Text = selectedItem.NamaStudio;
                }
            }
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            if (cbJadwal.SelectedItem == null || cbJumlah.SelectedItem == null)
            {
                MessageBox.Show("Mohon lengkapi pilihan Film, Jadwal, dan Jumlah Tiket.", "Peringatan");
                return;
            }

            // 1. Ambil data yang diperlukan
            int selectedJadwalID = Convert.ToInt32(cbJadwal.SelectedValue);
            int jumlahTiket = Convert.ToInt32(cbJumlah.SelectedItem);

            // 2. Lanjutkan ke Form Pilih Kursi
            // Di FormPilihKursi, Anda perlu mengetahui JADWAL ID dan JUMLAH TIKET yang diminta.
            // Kirim JADWAL ID ke FormPilihKursi (sama seperti sebelumnya)
            FormPilihKursi formKursi = new FormPilihKursi(selectedJadwalID, jumlahTiket, _username);
            formKursi.Show();
            this.Hide();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // 1. Buka kembali Form Utama (Daftar Film)
            // Kirim username agar user tidak perlu login lagi
            Form1 formUtama = new Form1(_username);
            formUtama.Show();

            // 2. Tutup Form Jadwal
            this.Close();
        }
    }
}
