using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KamarKos.Koneksi;

namespace KamarKos
{

    public partial class FormPembayaran : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        KoneksiDatabase konn = new KoneksiDatabase();
        MainMenuForm menuUtama;
        public FormPembayaran(MainMenuForm menu)
        {
            InitializeComponent();
            menuUtama = menu;
            conn = konn.GetConn();

            LoadPenghuni();
            LoadKamar();
            LoadStatus();
            LoadDataPembayaran();
        }

        private void LoadPenghuni()
        {
            try
            {
                conn = konn.GetConn();
                conn.Open();

                adapter = new MySqlDataAdapter("SELECT id_penghuni, nama FROM penghuni", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbPenghuni.DataSource = dt;
                cmbPenghuni.ValueMember = "id_penghuni";
                cmbPenghuni.DisplayMember = "nama";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load penghuni: " + ex.Message);
            }
        }

        private void LoadKamar()
        {
            try
            {
                conn = konn.GetConn();
                conn.Open();

                adapter = new MySqlDataAdapter("SELECT id_kamar, nama_kamar FROM kamar", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbKamar.DataSource = dt;
                cmbKamar.ValueMember = "id_kamar";
                cmbKamar.DisplayMember = "nama_kamar";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load kamar: " + ex.Message);
            }
        }

        private void LoadStatus()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("LUNAS");
            cmbStatus.Items.Add("BELUM LUNAS");
        }
        private void LoadDataPembayaran()
        {
            try
            {
                conn = konn.GetConn();
                conn.Open();

                adapter = new MySqlDataAdapter(
                    @"SELECT p.id_pembayaran AS ID,
                     h.nama AS Nama_Penghuni,
                     h.id_penghuni AS id_penghuni,
                     k.id_kamar AS id_kamar,
                     k.nama_kamar AS Nama_Kamar,
                     p.status AS Status,
                     p.tanggal_pembayaran AS Tanggal_Pembayaran
              FROM pembayaran p
              JOIN penghuni h ON p.id_penghuni = h.id_penghuni
              JOIN kamar k ON p.id_kamar = k.id_kamar
              ORDER BY p.id_pembayaran DESC", conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvPembayaran.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load pembayaran: " + ex.Message);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                conn = konn.GetConn();
                conn.Open();

                cmd = new MySqlCommand(
                    @"INSERT INTO pembayaran (id_penghuni, id_kamar, status, tanggal_pembayaran) 
              VALUES (@penghuni, @kamar, @status, @tanggal)", conn);

                cmd.Parameters.AddWithValue("@penghuni", cmbPenghuni.SelectedValue);
                cmd.Parameters.AddWithValue("@kamar", cmbKamar.SelectedValue);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@tanggal", dtpTanggalPembayaran.Value);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Data pembayaran berhasil ditambahkan!", "Sukses");
                ClearForm();
                LoadDataPembayaran();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah: " + ex.Message);
            }
        }

        private void dgvPembayaran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPembayaran.Rows[e.RowIndex];

                // ID Pembayaran
                txtIDPembayaran.Text =
                    row.Cells[0].Value == DBNull.Value || row.Cells[0].Value == null
                    ? ""
                    : row.Cells[0].Value.ToString();

                // Nama Penghuni
                cmbPenghuni.Text =
                    row.Cells[1].Value == DBNull.Value || row.Cells[1].Value == null
                    ? ""
                    : row.Cells[1].Value.ToString();

                // Nama Kamar
                cmbKamar.Text =
                    row.Cells[2].Value == DBNull.Value || row.Cells[2].Value == null
                    ? ""
                    : row.Cells[2].Value.ToString();

                // Status Pembayaran
                cmbStatus.Text =
                    row.Cells[3].Value == DBNull.Value || row.Cells[3].Value == null
                    ? ""
                    : row.Cells[3].Value.ToString();

                // Tanggal Pembayaran
                if (row.Cells[4].Value == DBNull.Value || row.Cells[4].Value == null || row.Cells[4].Value.ToString() == "")
                {
                    dtpTanggalPembayaran.Value = DateTime.Now;   // default jika NULL
                }
                else
                {
                    dtpTanggalPembayaran.Value = Convert.ToDateTime(row.Cells[4].Value);
                }
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (txtIDPembayaran.Text == "")
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            try
            {
                conn = konn.GetConn();
                conn.Open();

                cmd = new MySqlCommand(
                    @"UPDATE pembayaran SET 
                id_penghuni=@penghuni,
                id_kamar=@kamar,
                status=@status,
                tanggal_pembayaran=@tanggal
                WHERE id_pembayaran=@id", conn);

                cmd.Parameters.AddWithValue("@penghuni", cmbPenghuni.SelectedValue);
                cmd.Parameters.AddWithValue("@kamar", cmbKamar.SelectedValue);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@tanggal", dtpTanggalPembayaran.Value);
                cmd.Parameters.AddWithValue("@id", txtIDPembayaran.Text);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Data pembayaran berhasil diubah!", "Sukses");
                ClearForm();
                LoadDataPembayaran();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal edit: " + ex.Message);
            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtIDPembayaran.Text == "")
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            try
            {
                conn = konn.GetConn();
                conn.Open();

                cmd = new MySqlCommand(
                    "DELETE FROM pembayaran WHERE id_pembayaran=@id", conn);

                cmd.Parameters.AddWithValue("@id", txtIDPembayaran.Text);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Data pembayaran berhasil dihapus!", "Sukses");
                ClearForm();
                LoadDataPembayaran();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message);
            }
        }


        private void btnBersih_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtIDPembayaran.Clear();
            cmbPenghuni.SelectedIndex = 0;
            cmbKamar.SelectedIndex = 0;
            cmbStatus.SelectedIndex = -1;
            dtpTanggalPembayaran.Value = DateTime.Now;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuUtama.Show();
        }

        private void FormPembayaran_Load(object sender, EventArgs e)
        {
            dtpTanggalPembayaran.Value = DateTime.Now;
        }

        private void txtIDPembayaran_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }
    }
}
