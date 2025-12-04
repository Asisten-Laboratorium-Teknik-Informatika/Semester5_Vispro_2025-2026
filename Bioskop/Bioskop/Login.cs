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


namespace Bioskop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Email dan Password tidak boleh kosong!",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Koneksi kon = new Koneksi();
                MySqlConnection conn = kon.GetConn();
                conn.Open();

                // 🔍 Cek apakah email sudah terdaftar
                string checkEmailQuery = "SELECT COUNT(*) FROM register WHERE email=@email";
                MySqlCommand emailCmd = new MySqlCommand(checkEmailQuery, conn);
                emailCmd.Parameters.AddWithValue("@email", textBox1.Text);

                int emailExists = Convert.ToInt32(emailCmd.ExecuteScalar());

                if (emailExists == 0)
                {
                    MessageBox.Show("Akun belum terdaftar! Silakan daftar terlebih dahulu.",
                                    "Info",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    conn.Close();
                    return;
                }

                // 🔐 Email sudah ada → cek password
                string loginQuery = "SELECT * FROM register WHERE email=@email AND password=@password";
                MySqlCommand loginCmd = new MySqlCommand(loginQuery, conn);
                loginCmd.Parameters.AddWithValue("@email", textBox1.Text);
                loginCmd.Parameters.AddWithValue("@password", textBox2.Text);

                MySqlDataReader reader = loginCmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Login Berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowFilm showFilm = new ShowFilm();
                    showFilm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message);
            }
        }
    }
}
