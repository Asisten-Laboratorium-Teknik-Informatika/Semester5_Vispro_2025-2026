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

namespace projekvispro
{
    public partial class FormMasterBarang : Form
    {
        Connection conn = new Connection();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        void munculSatuan()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("PCS");
            comboBox1.Items.Add("BOX");
            comboBox1.Items.Add("BOTOL");
            comboBox1.Items.Add("PAXX");
            comboBox1.Items.Add("KG");
            comboBox1.Items.Add("KARUNG");
            comboBox1.SelectedIndex = -1;
        }

        void kondisiAwal()
        {
            txtKodeBarang.Text = "";
            txtNamaBarang.Text = "";
            txtHargaBeli.Text = "";
            txtHargaJual.Text = "";
            txtJumlahBarang.Text = "";
            comboBox1.Text = "";
            munculSatuan();
            ShowDataBarang();
        }
        public FormMasterBarang()
        {
            InitializeComponent();
        }

        void ShowDataBarang()
        {
            MySqlConnection koneksi = conn.GetConn();
            koneksi.Open();

            cmd = new MySqlCommand("SELECT * FROM TBL_BAARANG", koneksi);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "TBL_BAARANG");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_BAARANG";

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();

            koneksi.Close();

        }

        private void FormMasterBarang_Load(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (txtKodeBarang.Text == "" || 
                txtNamaBarang.Text == "" ||
                txtHargaBeli.Text == "" || 
                txtHargaJual.Text == "" ||
                txtJumlahBarang.Text == "" || 
                comboBox1.Text == "")
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            using (MySqlConnection koneksi = conn.GetConn())
            {
                koneksi.Open();
                string query = "INSERT INTO TBL_BAARANG VALUES (@kode, @nama, @beli, @jual, @jumlah, @satuan)";

                cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@kode", txtKodeBarang.Text);
                cmd.Parameters.AddWithValue("@nama", txtNamaBarang.Text);
                cmd.Parameters.AddWithValue("@beli", txtHargaBeli.Text);
                cmd.Parameters.AddWithValue("@jual", txtHargaJual.Text);
                cmd.Parameters.AddWithValue("@jumlah", txtJumlahBarang.Text);
                cmd.Parameters.AddWithValue("@satuan", comboBox1.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan!");
            }

            kondisiAwal();
        }

        private void txtKodeBarang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MySqlConnection koneksi = conn.GetConn();
                koneksi.Open();
                cmd = new MySqlCommand("SELECT * FROM TBL_BAARANG WHERE KodeBarang=@kode", koneksi);
                cmd.Parameters.AddWithValue("@kode", txtKodeBarang.Text);

                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtNamaBarang.Text = rd["NamaBarang"].ToString();
                    txtHargaBeli.Text = rd["HargaBeli"].ToString();
                    txtHargaJual.Text = rd["HargaJual"].ToString();
                    txtJumlahBarang.Text = rd["JumlahBarang"].ToString();
                    comboBox1.Text = rd["SatuanBarang"].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan!");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtKodeBarang.Text.Trim() == "" || 
                txtNamaBarang.Text.Trim() == "" || 
                txtHargaBeli.Text.Trim() == "" ||
                txtHargaJual.Text.Trim() == "" ||
                txtJumlahBarang.Text.Trim() == "" ||
                comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Tolong Isi Dahulu Semua Form Ya ><");
            }
            else
            {
                MySqlConnection koneksi = conn.GetConn();
                koneksi.Open();
                cmd = new MySqlCommand("UPDATE TBL_BAARANG SET " + "NamaBarang = @nama, " + "HargaBeli = @beli, " + "HargaJual = @jual, " + "JumlahBarang = @jumlah, " + "SatuanBarang = @satuan " + "WHERE KodeBarang = @kode", koneksi);

                cmd.Parameters.AddWithValue("@nama", txtNamaBarang.Text);
                cmd.Parameters.AddWithValue("@beli", txtHargaBeli.Text);
                cmd.Parameters.AddWithValue("@jual", txtHargaJual.Text);
                cmd.Parameters.AddWithValue("@jumlah", txtJumlahBarang.Text);
                cmd.Parameters.AddWithValue("@satuan", comboBox1.Text);
                cmd.Parameters.AddWithValue("@kode", txtKodeBarang.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Kamu Telah Berhasil Di-Edit");
                kondisiAwal();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtKodeBarang.Text.Trim() == "")
            {
                MessageBox.Show("Masukkan Kode Barang yang mau dihapus!");
                return;
            }

            MySqlConnection koneksi = conn.GetConn();
            koneksi.Open();

            try
            {
                string query = "DELETE FROM TBL_BAARANG WHERE KodeBarang = @kode";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);

                cmd.Parameters.AddWithValue("@kode", txtKodeBarang.Text);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Data berhasil dihapus!");
                    kondisiAwal(); 
                }
                else
                {
                    MessageBox.Show("Kode Barang tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
