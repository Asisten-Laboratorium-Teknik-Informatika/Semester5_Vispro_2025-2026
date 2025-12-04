using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
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

namespace budgetplanner
{
    public partial class Login : Form
    {

        private Register registerForm;

        public Login()
        {
            InitializeComponent();
        }

        private void inputEmail_Load(object sender, EventArgs e)
        {

        }

        private void inputPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string input = inputEmail.Text.Trim(); // bisa email atau username
            string password = inputPassword.Text.Trim();

            if (input == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Jika input mengandung '@', validasi email
            if (input.Contains("@"))
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(input, emailPattern))
                {
                    MessageBox.Show("Invalid email format!");
                    return;
                }
            }

            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            try
            {
                db.OpenConnection();

                string query = "SELECT * FROM users WHERE email = @input OR username = @input";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@input", input);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string hashedPassword = reader["password"].ToString();
                    int userId = Convert.ToInt32(reader["id"]);
                    string name = reader["name"].ToString();

                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        MessageBox.Show($"Welcome back, {name}!");

                        Form1 home = new Form1(userId);
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password!");
                    }
                }
                else
                {
                    MessageBox.Show("Email/Username not registered!");
                }

                reader.Close();
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




        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register regForm = new Register();
            regForm.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
