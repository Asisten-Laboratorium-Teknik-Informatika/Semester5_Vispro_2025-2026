using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PengaduanMasyarakat.Utils;

namespace PengaduanMasyarakat.Forms
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string namaLengkap = txtNamaLengkap.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(namaLengkap) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Semua field harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show("Username minimal 4 karakter!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password minimal 6 karakter!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Username sudah digunakan!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertQuery = "INSERT INTO users (username, password, nama_lengkap, email, role) " +
                                       "VALUES (@username, @password, @nama_lengkap, @email, 'user')";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@nama_lengkap", namaLengkap);
                    cmd.Parameters.AddWithValue("@email", email);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Registrasi berhasil! Silakan login dengan akun Anda.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Registrasi gagal. Silakan coba lagi.", "Error",
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

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}