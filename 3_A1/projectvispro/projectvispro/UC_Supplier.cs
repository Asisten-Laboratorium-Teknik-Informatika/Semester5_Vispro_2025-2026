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
    public partial class UC_Supplier : UserControl
    {
        public UC_Supplier()
        {
            InitializeComponent();
            TampilData();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ResetForm()
        {
            textBoxKodeSupplier.Clear();
            textBoxNamaSupplier.Clear();
            textBoxNoTelp.Clear();
            textBoxAlamat.Clear();
            btnSimpan.Enabled = true;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }

        private bool Validasi()
        {
            if (textBoxNamaSupplier.Text == "" || textBoxNoTelp.Text == "")
            {
                MessageBox.Show("Nama dan telepon wajib diisi!");
                return false;
            }
            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;  
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO supplier 
                                (kode_supplier, nama_supplier, no_telp, alamat)
                                VALUES (@kode,@nama,@telp,@alamat)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", textBoxKodeSupplier.Text);
                cmd.Parameters.AddWithValue("@nama", textBoxNamaSupplier.Text);
                cmd.Parameters.AddWithValue("@telp", textBoxNoTelp.Text);
                cmd.Parameters.AddWithValue("@alamat", textBoxAlamat.Text);
                cmd.ExecuteNonQuery();
                ResetForm();
                TampilData();
            }
        }

        private void TampilData()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM supplier";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSupplier.DataSource = dt;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE supplier SET 
                                nama_supplier=@nama, no_telp=@telp, alamat=@alamat 
                                WHERE kode_supplier=@kode";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", textBoxKodeSupplier.Text);
                cmd.Parameters.AddWithValue("@nama", textBoxNamaSupplier.Text);
                cmd.Parameters.AddWithValue("@telp", textBoxNoTelp.Text);
                cmd.Parameters.AddWithValue("@alamat", textBoxAlamat.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate!");
                TampilData();
                ResetForm();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (textBoxKodeSupplier.Text == "") return;
            if (MessageBox.Show("Yakin hapus?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM supplier WHERE kode_supplier=@kode";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kode", textBoxKodeSupplier.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data dihapus!");
                    ResetForm();
                    TampilData();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
                textBoxKodeSupplier.Text = row.Cells["kode_supplier"].Value.ToString();
                textBoxNamaSupplier.Text = row.Cells["nama_supplier"].Value.ToString();
                textBoxNoTelp.Text = row.Cells["no_telp"].Value.ToString();
                textBoxAlamat.Text = row.Cells["alamat"].Value.ToString();
                btnSimpan.Enabled = false;
                btnUpdate.Enabled = true;
                btnHapus.Enabled = true;
            }
        }

        private int GetNextSupplierSequence(string prefix)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM supplier 
            WHERE kode_supplier LIKE @prefix";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prefix", prefix + "%");
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count + 1;
            }
        }

        private string GenerateSupplierCode(string nama)
        {
            string clean = new string(nama
                .ToUpper()
                .Replace(" ", "")
                .Where(char.IsLetter)
                .ToArray());
            string prefix;
            if (clean.Length >= 3)
                prefix = clean.Substring(0, 3);
            else if (clean.Length == 2)
                prefix = clean + "X";
            else if (clean.Length == 1)
                prefix = clean + "XX";
            else
                throw new Exception("Nama supplier tidak valid");
            int urutan = GetNextSupplierSequence(prefix);
            return $"{prefix}{urutan.ToString("D3")}";
        }

        private void textBoxNamaSupplier_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNamaSupplier.Text))
            {
                textBoxKodeSupplier.Text = GenerateSupplierCode(textBoxNamaSupplier.Text);
            }
            if (textBoxNamaSupplier.Text == "")
            {
                textBoxKodeSupplier.Text = "";
            }
        }
    }
}
