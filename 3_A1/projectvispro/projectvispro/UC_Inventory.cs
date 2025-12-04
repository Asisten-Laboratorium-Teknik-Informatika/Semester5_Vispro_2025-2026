using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectvispro
{
    public partial class UC_Inventory : UserControl
    {
        public UC_Inventory()
        {
            InitializeComponent();
            TampilData();
            LoadKategori();
            LoadSupplier();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadKategori()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT kode_kategori, nama_kategori FROM kategori";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBoxKategori.DisplayMember = "nama_kategori";
                comboBoxKategori.ValueMember = "kode_kategori";
                comboBoxKategori.DataSource = dt;
            }
        }

        private void LoadSupplier()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT kode_supplier, nama_supplier FROM supplier";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBoxSupplier.DisplayMember = "nama_supplier";
                comboBoxSupplier.ValueMember = "kode_supplier";
                comboBoxSupplier.DataSource = dt;
            }
        }

        private void TampilData()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM barang";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInventory.DataSource = dt;
            }
        }

        private void GenerateKodeBarang()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT kode_barang FROM barang ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                int nextNumber = 1;
                if (result != null && result != DBNull.Value)
                {
                    string lastKode = result.ToString();   // contoh BRG0012
                    string angka = lastKode.Substring(3);   // ambil "0012"
                    nextNumber = int.Parse(angka) + 1;
                }
                textBoxKodeBarang.Text = "BRG" + nextNumber.ToString("0000");
                textBoxKodeBarang.ReadOnly = true;
            }
        }

        private bool ValidasiInput()
        {
            if (textBoxNamaBarang.Text == "" || comboBoxKategori.Text == "" || textBoxHargaBeli.Text == "" || textBoxStok.Text == "" || textBoxHargaJual.Text == "" || labelPathGambar.Text == ". . . / . . .")
            {
                MessageBox.Show("Semua data dan gambar wajib diisi!");
                return false;
            }
            if (!decimal.TryParse(textBoxHargaBeli.Text, out _))
            {
                MessageBox.Show("Harga harus berupa angka!");
                return false;
            }
            if (!decimal.TryParse(textBoxHargaJual.Text, out _))
            {
                MessageBox.Show("Harga harus berupa angka!");
                return false;
            }
            if (!int.TryParse(textBoxStok.Text, out _))
            {
                MessageBox.Show("Stok harus berupa angka!");
                return false;
            }
            return true;
        }

        private void ResetForm()
        {
            textBoxKodeBarang.Clear();
            textBoxNamaBarang.Clear();
            textBoxHargaBeli.Clear();
            textBoxHargaJual.Clear();
            textBoxStok.Clear();
            comboBoxKategori.SelectedIndex = -1;
            comboBoxSupplier.SelectedIndex = -1;
            dtpTanggalMasuk.Value = DateTime.Now;
            labelPathGambar.Text = "";
            btnSimpan.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;
            string folder = @"C:\Users\acer\OneDrive\Desktop\Project Lab VISPRO\Gambar\";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string gambarPath = null;
            if (!string.IsNullOrEmpty(labelPathGambar.Text))
            {
                string fileName = Path.GetFileName(labelPathGambar.Text);
                gambarPath = Path.Combine(folder, fileName);
                File.Copy(labelPathGambar.Text, gambarPath, true);
            }
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO barang (kode_barang, nama_barang, kategori, supplier, harga_beli, harga_jual, stok, tanggal_masuk, gambar) VALUES (@kode, @nama, @kategori, @supplier, @hbeli, @hjual, @stok, @tanggal, @gambar)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", textBoxKodeBarang.Text);
                cmd.Parameters.AddWithValue("@nama", textBoxNamaBarang.Text);
                cmd.Parameters.AddWithValue("@kategori", comboBoxKategori.Text);
                cmd.Parameters.AddWithValue("@supplier", comboBoxSupplier.Text);
                cmd.Parameters.AddWithValue("@hbeli", textBoxHargaBeli.Text);
                cmd.Parameters.AddWithValue("@hjual", textBoxHargaJual.Text);
                cmd.Parameters.AddWithValue("@stok", textBoxStok.Text);
                cmd.Parameters.AddWithValue("@tanggal", dtpTanggalMasuk.Value.Date);
                cmd.Parameters.AddWithValue("@gambar", (object)gambarPath ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Data barang berhasil disimpan!");
            ResetForm();
            TampilData();
            GenerateKodeBarang();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;
            string folder = @"C:\Users\acer\OneDrive\Desktop\Project Lab VISPRO\Gambar\";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string gambarPath = null;
            if (!string.IsNullOrEmpty(labelPathGambar.Text))
            {
                string fileName = Path.GetFileName(labelPathGambar.Text);
                gambarPath = Path.Combine(folder, fileName);
                File.Copy(labelPathGambar.Text, gambarPath, true);
            }
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO barang 
            (kode_barang, nama_barang, kategori, supplier, harga_beli, harga_jual, stok, tanggal_masuk, gambar)
            VALUES 
            (@kode, @nama, @kategori, @supplier, @hbeli, @hjual, @stok, @tanggal, @gambar)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", textBoxKodeBarang.Text);
                cmd.Parameters.AddWithValue("@nama", textBoxNamaBarang.Text);
                cmd.Parameters.AddWithValue("@kategori", comboBoxKategori.Text);
                cmd.Parameters.AddWithValue("@supplier", comboBoxSupplier.Text);
                cmd.Parameters.AddWithValue("@hbeli", textBoxHargaBeli.Text);
                cmd.Parameters.AddWithValue("@hjual", textBoxHargaJual.Text);
                cmd.Parameters.AddWithValue("@stok", textBoxStok.Text);
                cmd.Parameters.AddWithValue("@tanggal", dtpTanggalMasuk.Value.Date);
                cmd.Parameters.AddWithValue("@gambar", (object)gambarPath ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Data barang berhasil disimpan!");
            ResetForm();
            TampilData();
            GenerateKodeBarang();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (textBoxKodeBarang.Text == "")
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }
            if (MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM barang WHERE kode_barang=@kode";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kode", textBoxKodeBarang.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus!");
                    ResetForm();
                    TampilData();
                    GenerateKodeBarang();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            GenerateKodeBarang();
        }

        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateKodeBarang();
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateKodeBarang();
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInventory.Rows[e.RowIndex];
                textBoxNamaBarang.Text = row.Cells["nama_barang"].Value.ToString();
                textBoxKodeBarang.Text = row.Cells["kode_barang"].Value.ToString();
                textBoxHargaBeli.Text = row.Cells["harga_beli"].Value.ToString();
                textBoxHargaJual.Text = row.Cells["harga_jual"].Value.ToString();
                textBoxStok.Text = row.Cells["stok"].Value.ToString();
                btnSimpan.Enabled = false;
                btnUpdate.Enabled = true;
                btnHapus.Enabled = true;
            }
        }

        private void btnPilihGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labelPathGambar.Text = ofd.FileName;
            }
        }
    }
}
