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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isPasswordVisible = false;

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            labelPassword.ForeColor = Color.LightGray;
            textBoxPassword.ForeColor = Color.LightGray;
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            labelUser.ForeColor = Color.LightGray;
            textBoxUser.ForeColor = Color.LightGray;
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            labelPassword.ForeColor = Color.Black;
            textBoxPassword.ForeColor = Color.Black;
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            labelUser.ForeColor = Color.Black;
            textBoxUser.ForeColor = Color.Black;
        }

        private void labelDaftar_Click(object sender, EventArgs e)
        {
            labelDaftar.ForeColor = Color.FromArgb(192, 64, 0);
            FormRegister reg = new FormRegister();
            this.Hide();
            reg.Show();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Logic Login
            string username = textBoxUser.Text;
            string password = textBoxPassword.Text;

            MySqlConnection conn = Database.GetConnection();
            conn.Open();

            string query = "SELECT role FROM users WHERE username=@user AND password=@pass";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);

            object roleObj = cmd.ExecuteScalar();

            if (roleObj != null)
            {
                string role = roleObj.ToString();

                Dashboard dash = new Dashboard(username, role);
                dash.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau password salah!");
            }

        }
    }
}
