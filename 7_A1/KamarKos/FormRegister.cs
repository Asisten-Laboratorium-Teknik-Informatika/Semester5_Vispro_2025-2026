using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KamarKos.Koneksi;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace KamarKos
{
    public partial class FormRegister : Form
    {
        MySqlConnection conn;
        public FormRegister()
        {
            InitializeComponent();
            KoneksiDatabase db = new KoneksiDatabase();
            conn = db.GetConn();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validasi input tidak boleh kosong
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Semua field wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password dan confirm harus sama
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak sama!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();

                // Cek apakah username sudah ada
                string checkQuery = "SELECT * FROM admin WHERE username=@user";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@user", txtUsername.Text);
                MySqlDataReader dr = checkCmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Username sudah digunakan! Silahkan pilih username lain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return;
                }
                conn.Close();

                conn.Open();
                string insertQuery = "INSERT INTO admin (username, password) VALUES (@user, @pass)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@user", txtUsername.Text);
                insertCmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                insertCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Registrasi berhasil! Silakan login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
