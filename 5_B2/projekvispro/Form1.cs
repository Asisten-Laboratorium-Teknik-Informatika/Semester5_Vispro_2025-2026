using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace projekvispro
{
    public partial class Form1 : Form
    {
        Connection kon = new Connection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = kon.GetConn();

            try
            {
                conn.Open();
                MessageBox.Show("Koneksi Berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal konek: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection koneksi = kon.GetConn())
                {
                    koneksi.Open();

                    string query = "SELECT * FROM TBL_KASIR WHERE KodeKasir = @kode AND PasswordKasir = @pass";
                    MySqlCommand cmd = new MySqlCommand(query, koneksi);

                    cmd.Parameters.AddWithValue("@kode", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text.Trim());

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string kode = reader["KodeKasir"].ToString();
                        string nama = reader["NamaKasir"].ToString();

                        FormMenuUtama frm = new FormMenuUtama(kode, nama);
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ID atau password salah!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}



