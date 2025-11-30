using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PengaduanMasyarakat.Models;
using PengaduanMasyarakat.Utils;

namespace PengaduanMasyarakat.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Username = reader["username"].ToString(),
                            NamaLengkap = reader["nama_lengkap"].ToString(),
                            Email = reader["email"].ToString(),
                            Role = reader["role"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["created_at"])
                        };

                        SessionManager.CurrentUser = user;

                        MessageBox.Show($"Selamat datang, {user.NamaLengkap}!", "Login Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();

                        if (user.Role == "admin")
                        {
                            FormDashboardAdmin dashboardAdmin = new FormDashboardAdmin();
                            dashboardAdmin.ShowDialog();
                        }
                        else
                        {
                            FormDashboardUser dashboardUser = new FormDashboardUser();
                            dashboardUser.ShowDialog();
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah!", "Login Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            this.Hide();
            formRegister.ShowDialog();
            this.Show();
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}