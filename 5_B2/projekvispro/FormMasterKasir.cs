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

namespace projekvispro
{
    public partial class FormMasterKasir : Form
    {
        Connection conn = new Connection();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        void munculLevel()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Kasir");
            comboBox1.Items.Add("Manager");
            comboBox1.SelectedIndex = -1;
        }

        void kondisiAwal()
        {
            txtKodeKasir.Text = "";
            txtNamaKasir.Text = "";
            txtPassKasir.Text = "";
            comboBox1.Text = "";
            munculLevel();
            ShowDataKasir();
        }


        public FormMasterKasir()
        {
            InitializeComponent();
            kondisiAwal();
            munculLevel();
            ShowDataKasir();
        }

        private void FormMasterKasir_Load(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        void ShowDataKasir()
        {
            MySqlConnection koneksi = conn.GetConn();
            koneksi.Open();

            cmd = new MySqlCommand("SELECT * FROM TBL_KASIR", koneksi);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "TBL_KASIR");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_KASIR";

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();

            // Sembunyikan password di DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["PasswordKasir"].Value = new string('*', row.Cells["PasswordKasir"].Value.ToString().Length);
            }

            koneksi.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKodeKasir.Text.Trim() == "" || txtNamaKasir.Text.Trim() == "" || txtPassKasir.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Tolong Isi Dahulu Semua Form Ya ><");
            }
            else
            {
                MySqlConnection koneksi = conn.GetConn();
                koneksi.Open();
                cmd = new MySqlCommand("INSERT INTO TBL_KASIR values ('" + txtKodeKasir.Text + "','" + txtNamaKasir.Text + "','" + txtPassKasir.Text + "','" + comboBox1.Text + "')", koneksi);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Kamu Telah Berhasil Di Simpan");
                kondisiAwal();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKodeKasir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MySqlConnection koneksi = conn.GetConn();
                koneksi.Open();
                cmd = new MySqlCommand("SELECT * FROM TBL_KASIR where KodeKasir='" + txtKodeKasir.Text + "'", koneksi);
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtKodeKasir.Text  = rd[0].ToString();
                    txtNamaKasir.Text = rd[1].ToString();
                    txtPassKasir.Text = rd[2].ToString();
                    comboBox1.Text = rd[3].ToString();
                }
                else
                {
                    MessageBox.Show("Datanya Tidak Ada, Coba Periksa Lagi");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtKodeKasir.Text.Trim() == "" || txtNamaKasir.Text.Trim() == "" || txtPassKasir.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Tolong Isi Dahulu Semua Form Ya ><");
            }
            else
            {
                MySqlConnection koneksi = conn.GetConn();
                koneksi.Open();
                cmd = new MySqlCommand("UPDATE TBL_KASIR SET " + "NamaKasir = @nama, " + "PasswordKasir = @pass, " + "LevelKasir = @level " + "WHERE KodeKasir = @kode", koneksi);

                cmd.Parameters.AddWithValue("@nama", txtNamaKasir.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassKasir.Text);
                cmd.Parameters.AddWithValue("@level", comboBox1.Text);
                cmd.Parameters.AddWithValue("@kode", txtKodeKasir.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Kamu Telah Berhasil Di-Edit");
                kondisiAwal();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtKodeKasir.Text.Trim() == "")
            {
                MessageBox.Show("Masukkan Kode Kasir yang mau dihapus!");
                return;
            }

            MySqlConnection koneksi = conn.GetConn();
            koneksi.Open();

            try
            {
                string query = "DELETE FROM TBL_KASIR WHERE KodeKasir = @kode";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);

                cmd.Parameters.AddWithValue("@kode", txtKodeKasir.Text);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Data berhasil dihapus!");
                    kondisiAwal();
                }
                else
                {
                    MessageBox.Show("Kode kasir tidak ditemukan.");
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
    }
}

