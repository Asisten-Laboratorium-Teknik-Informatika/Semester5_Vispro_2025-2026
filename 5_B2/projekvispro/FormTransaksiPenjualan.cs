using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace projekvispro
{
    public partial class FormTransaksiPenjualan : Form
    {
        Connection conn = new Connection();
        private MySqlCommand cmd;
        private MySqlDataReader rd;

        public FormTransaksiPenjualan()
        {
            InitializeComponent();
        }

        // RESET FORM
        void KondisiAwal()
        {
            labelNama.Text = "-";
            labelHarga.Text = "-";
            labelItem.Text = "0";
            labelKasir.Text = "-";
            labelTanggal.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labelKembali.Text = "0";
            labelTotal.Text = "0";

            txtKode.Text = "";
            txtJumlah.Text = "";
            txtDibayar.Text = "";

            dataGridView1.Rows.Clear();
        }

        private void FormTransaksiPenjualan_Load(object sender, EventArgs e)
        {
            KondisiAwal();
            ShowDataPenjualan();
            timer1.Start();
            labelNoJual.Text = BuatNomorJual();
            labelKasir.Text = FormMenuUtama.NamaKasir;


        }

        // SET KOLOM GRID
        void ShowDataPenjualan()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("KodeBarang", "Kode");
            dataGridView1.Columns.Add("NamaBarang", "Nama");
            dataGridView1.Columns.Add("HargaBarang", "Harga");
            dataGridView1.Columns.Add("Jumlah", "Jumlah");
            dataGridView1.Columns.Add("SubTotal", "Sub Total");

            dataGridView1.Columns[1].Width = 350;
        }

        // CARI BARANG (ENTER)
        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MySqlConnection koneksi = conn.GetConn();
                koneksi.Open();

                cmd = new MySqlCommand("SELECT * FROM TBL_BAARANG WHERE KodeBarang=@kode", koneksi);
                cmd.Parameters.AddWithValue("@kode", txtKode.Text);

                rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    labelNama.Text = rd["NamaBarang"].ToString();
                    labelHarga.Text = rd["HargaJual"].ToString();
                }
                else
                {
                    MessageBox.Show("Barang tidak ditemukan!");
                    labelNama.Text = "-";
                    labelHarga.Text = "-";
                }

                koneksi.Close();
            }
        }

        // INSERT ITEM KE DATAGRID
        private void button1_Click(object sender, EventArgs e)
        {
            if (labelNama.Text == "-" || txtJumlah.Text == "")
            {
                MessageBox.Show("Masukkan kode barang dan jumlah dulu!");
                return;
            }

            int harga = int.Parse(labelHarga.Text);
            int jumlah = int.Parse(txtJumlah.Text);
            int subtotal = harga * jumlah;

            dataGridView1.Rows.Add(
                txtKode.Text,
                labelNama.Text,
                harga,
                jumlah,
                subtotal
            );

            HitungTotal();
            HitungItem();

            txtKode.Text = "";
            txtJumlah.Text = "";
            txtKode.Focus();
        }

        void HitungTotal()
        {
            int total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                total += Convert.ToInt32(row.Cells["SubTotal"].Value);
            }


            labelTotal.Text = total.ToString();
        }

        void HitungItem()
        {
            labelItem.Text = dataGridView1.Rows.Cast<DataGridViewRow>()
    .       Where(r => !r.IsNewRow).Count().ToString();

        }

        private void txtDibayar_TextChanged(object sender, EventArgs e)
        {
            if (txtDibayar.Text == "")
            {
                labelKembali.Text = "0";
                return;
            }

            int total = int.Parse(labelTotal.Text);
            int bayar = int.Parse(txtDibayar.Text);

            labelKembali.Text = (bayar - total).ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada item untuk disimpan!");
                    return;
                }

                MySqlConnection koneksi = conn.GetConn();
                koneksi.Open();

                string noJual = labelNoJual.Text;
                string tanggal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                cmd = new MySqlCommand(
                    "INSERT INTO TBL_JUAL (NoJual, TglJual, ItemJual, TotalJual, Bayar, Kembali, KodeKasir) " +
                    "VALUES (@no, @tgl, @item, @total, @bayar, @kembali, @kasir)", koneksi);

                cmd.Parameters.AddWithValue("@no", noJual);
                cmd.Parameters.AddWithValue("@tgl", tanggal);
                cmd.Parameters.AddWithValue("@item", labelItem.Text);
                cmd.Parameters.AddWithValue("@total", labelTotal.Text);
                cmd.Parameters.AddWithValue("@bayar", txtDibayar.Text);
                cmd.Parameters.AddWithValue("@kembali", labelKembali.Text);
                cmd.Parameters.AddWithValue("@kasir", FormMenuUtama.KodeKasir);

                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string kode = row.Cells[0].Value.ToString();
                    int qty = int.Parse(row.Cells[3].Value.ToString());

                    MySqlCommand cmdStok = new MySqlCommand(
                        "UPDATE tbl_baarang SET JumlahBarang = JumlahBarang - @qty WHERE KodeBarang=@kode", koneksi);

                    cmdStok.Parameters.AddWithValue("@qty", qty);
                    cmdStok.Parameters.AddWithValue("@kode", kode);
                    cmdStok.ExecuteNonQuery();
                }


                koneksi.Close();

                MessageBox.Show("Transaksi berhasil disimpan!");

                KondisiAwal();

                labelNoJual.Text = BuatNomorJual();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR INSERT: " + ex.Message);
            }
        }

        string BuatNomorJual()
        {
            string noBaru = "";
            MySqlConnection koneksi = conn.GetConn();
            koneksi.Open();

            cmd = new MySqlCommand("SELECT NoJual FROM TBL_JUAL WHERE NoJual LIKE 'TRX%' ORDER BY NoJual DESC LIMIT 1", koneksi);

            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                string last = rd["NoJual"].ToString().Substring(3);
                int next = int.Parse(last) + 1;
                noBaru = "TRX" + next.ToString("000");
            }
            else
            {
                noBaru = "TRX001";
            }

            koneksi.Close();
            return noBaru;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelJam.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void txtDibayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int total = int.Parse(labelTotal.Text);
                int bayar = int.Parse(txtDibayar.Text);

                labelKembali.Text = (bayar - total).ToString();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }
    }
}



