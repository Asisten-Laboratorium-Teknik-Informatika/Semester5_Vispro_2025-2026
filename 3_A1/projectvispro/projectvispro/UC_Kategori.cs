using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectvispro
{
    public partial class UC_Kategori : UserControl
    {
        public UC_Kategori()
        {
            InitializeComponent();
            LoadData();
            LoadSupplier();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string GenerateKodeKategori(string namaKategori)
        {
            if (comboBoxSupplier.SelectedValue == null)
                return "";

            string kodeSupplier = comboBoxSupplier.SelectedValue.ToString().Trim().ToUpper();

            string[] kata = namaKategori.Trim().Split(' ');
            string singkatan = "";

            if (kata.Length == 1)
            {
                singkatan = kata[0].Length >= 3 ? kata[0].Substring(0, 3) : kata[0];
            }
            else
            {
                foreach (string k in kata)
                {
                    if (!string.IsNullOrWhiteSpace(k))
                        singkatan += k.Substring(0, 1);
                }
            }

            return kodeSupplier + "-" + singkatan;
        }

        private void resetForm()
        {
            textBoxKodeKategori.Clear();
            textBoxKodeKategori.Clear();
            comboBoxSupplier.SelectedIndex = -1;
            btnSimpan.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void textBoxNamaKategori_TextChanged(object sender, EventArgs e)
        {
            string nama = textBoxNamaKategori.Text;
            if (nama.Length >= 3 && comboBoxSupplier.SelectedValue != null)
            {
                textBoxKodeKategori.Text = GenerateKodeKategori(nama);
            }
            if (textBoxNamaKategori.Text == "")
            {
                textBoxKodeKategori.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void LoadData()
        {
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT * FROM kategori", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKategori.DataSource = dt;
            conn.Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxNamaKategori.Text == "")
            {
                MessageBox.Show("Nama kategori wajib diisi!");
                return;
            }
            textBoxKodeKategori.Text = GenerateKodeKategori(textBoxNamaKategori.Text);
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO kategori (kode_kategori, nama_kategori) VALUES (@k, @n)", conn);
            cmd.Parameters.AddWithValue("@k", textBoxKodeKategori.Text);
            cmd.Parameters.AddWithValue("@n", textBoxNamaKategori.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            resetForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxKodeKategori.Text == "")
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE kategori SET nama_kategori=@n WHERE kode_kategori=@k";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@k", textBoxKodeKategori.Text);
                    cmd.Parameters.AddWithValue("@n", textBoxNamaKategori.Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Data berhasil diubah!");
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan atau tidak berubah!");
                    }
                }
            }
            LoadData();
            resetForm();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM kategori WHERE kode_kategori=@k", conn);
            cmd.Parameters.AddWithValue("@k", textBoxKodeKategori.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data berhasil dihapus!");
            LoadData();
            resetForm();
        }

        private void LoadSupplier()
        {
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            string query = "SELECT id_supplier, kode_supplier, nama_supplier FROM supplier";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxSupplier.DisplayMember = "nama_supplier";  //tampilan
            comboBoxSupplier.ValueMember = "kode_supplier";    //nilai yang diambil
            comboBoxSupplier.DataSource = dt;
            conn.Close();
        }

        private void dgvKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKategori.Rows[e.RowIndex];
                textBoxKodeKategori.Text = row.Cells["kode_kategori"].Value.ToString();
                textBoxNamaKategori.Text = row.Cells["nama_kategori"].Value.ToString();
                btnSimpan.Enabled = false;
                btnUpdate.Enabled = true;
                btnHapus.Enabled = true;
            }
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBoxNamaKategori.Text.Length >= 3 && comboBoxSupplier.SelectedValue != null)
            {
                textBoxKodeKategori.Text = GenerateKodeKategori(textBoxNamaKategori.Text);
            }
        }
    }
}
