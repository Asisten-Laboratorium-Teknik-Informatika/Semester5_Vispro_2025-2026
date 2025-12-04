using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace budgetplanner
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void pnlName_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = inputNama.Text.Trim();
            string username = inputUsername.Text.Trim();
            string email = inputEmail.Text.Trim();
            string password = inputPassword.Text.Trim();

            // Validasi input
            if (name == "" || username == "" || email == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // VALIDASI FORMAT EMAIL (Regex)
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Invalid email format!");
                return;
            }

            // Hash password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            try
            {
                db.OpenConnection();

                // Cek username / email apakah sudah terdaftar
                string checkQuery =
                    "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";

                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                checkCmd.Parameters.AddWithValue("@email", email);

                long exists = (long)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Username or email already registered!");
                    return;
                }

                // Insert user baru
                string query = "INSERT INTO users (name, username, email, password) " +
                               "VALUES (@name, @username, @email, @password)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Registration successful!");

                // Pindah ke Login
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }




        private void LoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void inputNama_Load(object sender, EventArgs e)
        {

        }

        private void inputUsername_Load(object sender, EventArgs e)
        {

        }

        private void inputEmail_Load(object sender, EventArgs e)
        {

        }

        private void inputPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
