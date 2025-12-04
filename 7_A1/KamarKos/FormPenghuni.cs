using KamarKos.Koneksi;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamarKos
{
    public partial class FormPenghuni : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        KoneksiDatabase konn = new KoneksiDatabase();
        DataTable dt;
        MainMenuForm menuUtama;
        public FormPenghuni(MainMenuForm menu)
        {
            InitializeComponent();
            menuUtama = menu;
            conn = konn.GetConn();
        }

        // ======== Fungsi Tampil Data Penghuni ========
        void TampilData()
        {
            try
            {
                conn.Open();
                adapter = new MySqlDataAdapter(
                    "SELECT id_penghuni, nama, tanggal_masuk, no_hp, alamat, id_kamar FROM penghuni",
                    conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dgvPenghuni.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void LoadKamar()
        {
            try
            {
                using (MySqlConnection conn = konn.GetConn())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "SELECT id_kamar FROM kamar WHERE status='Kosong'",
                        conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    cmbKamar.Items.Clear();
                    while (dr.Read())
                    {
                        cmbKamar.Items.Add(dr["id_kamar"].ToString());
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat kamar: " + ex.Message);
            }
        }

        void Bersihkan()
        {
            txtIDPenghuni.Clear();
            txtNamaPenghuni.Clear();
            txtNoHP.Clear();
            txtAlamat.Clear();
            cmbKamar.SelectedIndex = -1;
        }
        private void txtIDPenghuni_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtIDPenghuni.Text == "" || txtNamaPenghuni.Text == "" || txtNoHP.Text == "" || cmbKamar.Text == "")
            {
                MessageBox.Show("Data belum lengkap!");
                return;
            }

            try
            {
                conn.Open();
                cmd = new MySqlCommand(
                    "INSERT INTO penghuni (id_penghuni, nama, tanggal_masuk, no_hp, alamat, id_kamar) VALUES(@id, @nama, @tanggal_masuk, @hp, @alamat, @kamar)",
                     conn);
                cmd.Parameters.AddWithValue("@id", txtIDPenghuni.Text);
                cmd.Parameters.AddWithValue("@nama", txtNamaPenghuni.Text);
                cmd.Parameters.AddWithValue("@tanggal_masuk", dtpTanggalMasuk.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@hp", txtNoHP.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@kamar", cmbKamar.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data penghuni berhasil ditambahkan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtIDPenghuni.Text == "")
            {
                MessageBox.Show("Pilih data yang akan diubah!");
                return;
            }

            try
            {
                conn.Open();
                cmd = new MySqlCommand(
                    "UPDATE penghuni SET nama=@nama, tanggal_masuk=@tanggal_masuk, no_hp=@hp, alamat=@alamat, id_kamar=@kamar WHERE id_penghuni = @id",
                    conn);
                cmd.Parameters.AddWithValue("@id", txtIDPenghuni.Text);
                cmd.Parameters.AddWithValue("@nama", txtNamaPenghuni.Text);
                cmd.Parameters.AddWithValue("@tanggal_masuk", dtpTanggalMasuk.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@hp", txtNoHP.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@kamar", cmbKamar.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data penghuni berhasil diperbarui!");
                TampilData();
                Bersihkan();
            }
            catch
            {
                MessageBox.Show("Gagal memperbarui data (sementara abaikan error DB)!");
            }
        }
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtIDPenghuni.Text == "")
            {
                MessageBox.Show("Pilih data yang akan dihapus!");
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    cmd = new MySqlCommand(
                        "DELETE FROM penghuni WHERE id_penghuni=@id",
                        conn);
                    cmd.Parameters.AddWithValue("@id", txtIDPenghuni.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Data penghuni berhasil dihapus!");
                    TampilData();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Gagal menghapus data (sementara abaikan error DB)!");
                }
            }
        }
        private void btnBersih_Click(object sender, EventArgs e)
        {
            Bersihkan();
            dtpTanggalMasuk.Value = DateTime.Today;
        }
        private void dgvPenghuni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPenghuni.Rows[e.RowIndex].Cells.Count >= 5)
            {
                DataGridViewRow row = dgvPenghuni.Rows[e.RowIndex];
                txtIDPenghuni.Text = row.Cells["id_penghuni"].Value?.ToString();
                txtNamaPenghuni.Text = row.Cells["nama"].Value?.ToString();
                cmbKamar.Text = row.Cells["id_kamar"].Value?.ToString();
                txtNoHP.Text = row.Cells["no_hp"].Value?.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value?.ToString();
                cmbKamar.Text = row.Cells["id_kamar"].Value?.ToString();
            }
        }
        private void lblKamar_Click(object sender, EventArgs e)
        {

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuUtama.Show();
        }
        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }
        private void FormPenghuni_Load_1(object sender, EventArgs e)
        {
            LoadKamar();
            TampilData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblNama_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpTanggalMasuk_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
