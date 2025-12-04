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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        bool isPasswordVisible = false;
        
        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            labelPassword.ForeColor = Color.LightGray;
            labelKonfirmasiPassword.ForeColor = Color.LightGray;
            textBoxPassword.ForeColor = Color.LightGray;
            textBoxKonfirmasiPassword.ForeColor = Color.LightGray;
        }
        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            labelPassword.ForeColor = Color.Black;
            labelKonfirmasiPassword.ForeColor = Color.Black;
            textBoxPassword.ForeColor = Color.Black;
            textBoxKonfirmasiPassword.ForeColor = Color.Black;
        }
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            labelUser.ForeColor = Color.LightGray;
            textBoxUser.ForeColor = Color.LightGray;
        }
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            labelUser.ForeColor = Color.Black;
            textBoxUser.ForeColor = Color.Black;
        }
        private void textBoxKonfirmasiPassword_Enter(object sender, EventArgs e)
        {
            labelUser.ForeColor = Color.LightGray;
            textBoxUser.ForeColor = Color.LightGray;
        }
        private void textBoxKonfirmasiPassword_Leave(object sender, EventArgs e)
        {
            labelUser.ForeColor = Color.Black;
            textBoxUser.ForeColor = Color.Black;
        }
        private void labelMasuk_Click(object sender, EventArgs e)
        {
            labelMasuk.ForeColor = Color.FromArgb(192, 64, 0);
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            if(textBoxPassword.Text != textBoxKonfirmasiPassword.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password Tidak Sama", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Logic Daftar
            string username = textBoxUser.Text;
            string password = textBoxPassword.Text;
            string konfirmasipassword = textBoxKonfirmasiPassword.Text;
            string role = "kasir";

            MySqlConnection conn = Database.GetConnection();
            conn.Open();

            string query = "INSERT INTO users (username, password, role) VALUES (@user, @pass, @role)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@role", role);

            // Error Handling
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registrasi akun berhasil.");
                Form1 login = new Form1();
                this.Hide();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            conn.Close();
        }

        private void btnHidePassword1_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                textBoxPassword.UseSystemPasswordChar = true;
                isPasswordVisible = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = false;
                isPasswordVisible = true;
            }
        }

        private void btnHidePassword2_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                textBoxKonfirmasiPassword.UseSystemPasswordChar = true;
                isPasswordVisible = false;
            }
            else
            {
                textBoxKonfirmasiPassword.UseSystemPasswordChar = false;
                isPasswordVisible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
