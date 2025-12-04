using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Semua field harus diisi!",
                                "Peringatan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Koneksi kon = new Koneksi();
                MySqlConnection conn = kon.GetConn();
                conn.Open();

                // Cek apakah email sudah terdaftar
                string checkQuery = "SELECT COUNT(*) FROM register WHERE email=@Email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Email", textBox2.Text);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Email sudah terdaftar!",
                                    "Gagal",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    conn.Close();
                    return;
                }

                // Insert data baru
                string query = "INSERT INTO register(username, email, password) VALUES (@Username, @Email, @Password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Registrasi Berhasil! Silakan Login.",
                                "Sukses",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                Login login = new Login();
                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
