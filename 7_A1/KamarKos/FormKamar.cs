using KamarKos.Koneksi;
using MySql.Data.MySqlClient;
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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KamarKos
{
    public partial class FormKamar : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        KoneksiDatabase konn = new KoneksiDatabase();
        MainMenuForm menuUtama;

        DataTable dt;
        public FormKamar(MainMenuForm menu)
        {
            InitializeComponent();
            menuUtama = menu;
            conn = konn.GetConn();
            LoadDataKamar();
        }
        private void LoadDataKamar()
        {
            try
            {
                conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(
                    "SELECT id_kamar AS 'ID', nama_kamar AS 'Nama Kamar', harga AS 'Harga', status AS 'Status' FROM kamar",
                    conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvKamar.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error memuat data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        void TampilData()
        {
            try
            {
                conn.Open();
                adapter = new MySqlDataAdapter(
                    "SELECT id_kamar, nama_kamar, harga, STATUS FROM kamar", conn);
                dt = new DataTable();
                adapter.Fill(dt);
                dgvKamar.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error memuat data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        void Bersihkan()
        {
            txtKodeKamar.Clear();
            txtNamaKamar.Clear();
            txtHarga.Clear();
            cmbStatus.SelectedIndex = -1;
        }
        private void FormKamar_Load_1(object sender, EventArgs e)
        {
            TampilData();
        }

        private void txtKodeKamar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand(
                    "INSERT INTO kamar (id_kamar, nama_kamar, harga, STATUS) VALUES (@kode, @nama, @harga, @status)",
                    conn);

                cmd.Parameters.AddWithValue("@kode", txtKodeKamar.Text);
                cmd.Parameters.AddWithValue("@nama", txtNamaKamar.Text);
                cmd.Parameters.AddWithValue("@harga", txtHarga.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data kamar berhasil ditambahkan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah: " + ex.Message);
            }
            finally
            {
                conn.Close();
                TampilData();
                Bersihkan();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand(
                    "UPDATE kamar SET nama_kamar=@nama, harga=@harga, status=@status WHERE id_kamar = @kode",
                    conn);
                cmd.Parameters.AddWithValue("@kode", txtKodeKamar.Text);
                cmd.Parameters.AddWithValue("@nama", txtNamaKamar.Text);
                cmd.Parameters.AddWithValue("@harga", txtHarga.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data kamar berhasil diperbarui!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message);
            }
            finally
            {
                conn.Close();
                TampilData();
                Bersihkan();
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand(
                    "DELETE FROM kamar WHERE id_kamar=@kode",
                    conn);

                cmd.Parameters.AddWithValue("@kode", txtKodeKamar.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data kamar berhasil dihapus!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message);
            }
            finally
            {
                conn.Close();
                TampilData();
                Bersihkan();
            }

        }

        private void btnBersih_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }

        private void dgvKamar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKamar.Rows[e.RowIndex];
                txtKodeKamar.Text = row.Cells["id_kamar"].Value.ToString();
                txtNamaKamar.Text = row.Cells["nama_kamar"].Value.ToString();
                txtHarga.Text = row.Cells["harga"].Value.ToString();
                cmbStatus.Text = row.Cells["status"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm menu = new MainMenuForm();
            menuUtama.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
