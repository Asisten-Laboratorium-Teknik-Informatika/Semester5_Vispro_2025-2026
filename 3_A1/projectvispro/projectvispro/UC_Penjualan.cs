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
    public partial class UC_Penjualan : UserControl
    {

        private DataTable dtPenjualan;

        public UC_Penjualan()
        {
            InitializeComponent();
            LoadBarang();
            SetupDataGridView();
            numericJumlah.Value = 1;
            dgvPenjualan.AutoGenerateColumns = false;
        }

        private void SetupDataGridView()
        {
            dgvPenjualan.Columns.Clear();
            dgvPenjualan.AutoGenerateColumns = false;

            dgvPenjualan.Columns.Add("Kode", "Kode Barang");
            dgvPenjualan.Columns.Add("Nama", "Nama Barang");
            dgvPenjualan.Columns.Add("Harga", "Harga");
            dgvPenjualan.Columns.Add("Jumlah", "Jumlah");
            dgvPenjualan.Columns.Add("Subtotal", "Subtotal");

            dgvPenjualan.Columns["Harga"].DefaultCellStyle.Format = "N2";
            dgvPenjualan.Columns["Subtotal"].DefaultCellStyle.Format = "N2";

            dgvPenjualan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPenjualan.MultiSelect = false;
        }

        private void LoadBarang()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT kode_barang, nama_barang, harga_jual, stok FROM barang";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBoxBarang.DisplayMember = "nama_barang";
                comboBoxBarang.ValueMember = "kode_barang";
                comboBoxBarang.DataSource = dt;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBarang.SelectedValue == null) return;
            DataRowView drv = comboBoxBarang.SelectedItem as DataRowView;
            if (drv != null)
            {
                labelHarga.Text = drv["harga_jual"].ToString();
            }
        }

        private void dgvPenjualan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPenjualan.Rows[e.RowIndex];
                labelHarga.Text = row.Cells["Harga"].Value.ToString();
                numericJumlah.Value = 1;
            }
        }

        private void ResetForm()
        {
            comboBoxBarang.SelectedIndex = -1;
            numericJumlah.Value = 1;
            dgvPenjualan.Rows.Clear();
            labelHarga.Text = "0";
            labelTotal.Text = "0";
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvPenjualan.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            labelTotal.Text = total.ToString("N2");
        }

        private void btnTambahBarang_Click(object sender, EventArgs e)
        {
            if (comboBoxBarang.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih barang terlebih dahulu.");
                return;
            }
            string kode = comboBoxBarang.SelectedValue.ToString();
            string nama = comboBoxBarang.Text;
            if (!decimal.TryParse(labelHarga.Text, out decimal harga))
            {
                MessageBox.Show("Harga tidak valid.");
                return;
            }
            int jumlah = (int)numericJumlah.Value;
            decimal subtotal = harga * jumlah;
            bool sudahAda = false;
            foreach (DataGridViewRow row in dgvPenjualan.Rows)
            {
                if (row.IsNewRow) continue;
                var cellValue = row.Cells["Kode"].Value;
                if (cellValue != null && cellValue.ToString() == kode)
                {
                    int prevJumlah = Convert.ToInt32(row.Cells["Jumlah"].Value);
                    decimal prevSubtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    row.Cells["Jumlah"].Value = prevJumlah + jumlah;
                    row.Cells["Subtotal"].Value = prevSubtotal + subtotal;
                    sudahAda = true;
                    break;
                }
            }
            if (!sudahAda)
            {
                dgvPenjualan.Rows.Add(kode, nama, harga, jumlah, subtotal);
            }
            UpdateTotal();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnSimpanTransaksi_Click(object sender, EventArgs e)
        {
            if (dgvPenjualan.Rows.Count == 0 || dgvPenjualan.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Tidak ada barang yang dibeli!");
                return;
            }
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string queryTransaksi = "INSERT INTO transaksi (tanggal, total) VALUES (@tanggal, @total)";
                    using (MySqlCommand cmdTransaksi = new MySqlCommand(queryTransaksi, conn, tran))
                    {
                        cmdTransaksi.Parameters.AddWithValue("@tanggal", DateTime.Now);
                        cmdTransaksi.Parameters.AddWithValue("@total", Convert.ToDecimal(labelTotal.Text));
                        cmdTransaksi.ExecuteNonQuery();
                    }
                    long idTransaksi;
                    using (MySqlCommand cmdGetId = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, tran))
                    {
                        idTransaksi = Convert.ToInt64(cmdGetId.ExecuteScalar());
                    }
                    foreach (DataGridViewRow row in dgvPenjualan.Rows)
                    {
                        if (row.IsNewRow) continue;
                        if (row.Cells["Kode"].Value == null) continue;
                        string kode = row.Cells["Kode"].Value.ToString();
                        decimal harga = Convert.ToDecimal(row.Cells["Harga"].Value);
                        int jumlah = Convert.ToInt32(row.Cells["Jumlah"].Value);
                        decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                        string queryDetail = @"INSERT INTO detail_transaksi
                                       (id_transaksi, kode_barang, harga, jumlah, subtotal)
                                       VALUES (@id, @kode, @harga, @jumlah, @subtotal)";
                        using (MySqlCommand cmdDetail = new MySqlCommand(queryDetail, conn, tran))
                        {
                            cmdDetail.Parameters.AddWithValue("@id", idTransaksi);
                            cmdDetail.Parameters.AddWithValue("@kode", kode);
                            cmdDetail.Parameters.AddWithValue("@harga", harga);
                            cmdDetail.Parameters.AddWithValue("@jumlah", jumlah);
                            cmdDetail.Parameters.AddWithValue("@subtotal", subtotal);
                            cmdDetail.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    MessageBox.Show("Transaksi berhasil disimpan!");
                    ResetForm();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Gagal menyimpan transaksi: " + ex.Message);
                }
            }
        }
    }
}
