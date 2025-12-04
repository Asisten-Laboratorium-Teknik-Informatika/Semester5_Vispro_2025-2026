using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace budgetplanner
{
    public partial class Form5 : Form
    {
        private Form1 mainForm;

        public Form5(Form1 form1)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.Shown += Form5_Shown;
        }

        // ===================================
        //   LOAD USER DATA SAAT FORM DIBUKA
        // ===================================
        private void Form5_Shown(object sender, EventArgs e)
        {
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            try
            {
                db.OpenConnection();

                string query = "SELECT name, username, email FROM users WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", mainForm.currentUserId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TextBoxNama.Text = reader["name"].ToString();
                    TextBoxUsername.Text = reader["username"].ToString();
                    TextBoxEmail.Text = reader["email"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            db.CloseConnection();
        }

        // ===================================
        //         UPDATE PROFILE USER
        // ===================================
        private void TombolEdit_Click(object sender, EventArgs e)
        {
            string nama = TextBoxNama.Text.Trim();
            string username = TextBoxUsername.Text.Trim();
            string email = TextBoxEmail.Text.Trim();

            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            try
            {
                db.OpenConnection();

                string query = "UPDATE users SET name = @name, username = @username, email = @email WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", nama);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", mainForm.currentUserId);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Profil berhasil diperbarui!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // ===================================
        //              LOGOUT
        // ===================================
        private void TombolLogout_Click(object sender, EventArgs e)
        {
            // Tutup semua form
            this.Hide();
            mainForm.Hide();

            // Balik ke Login
            Login login = new Login();
            login.Show();
        }

        // ===================================
        //   NAVIGASI DALAM APP (TIDAK DIUBAH)
        // ===================================
        private void btnHome_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Hide();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            mainForm.form3.UpdateDisplay();
            mainForm.form3.Show();
            this.Hide();
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            mainForm.form4.Show();
            this.Hide();
        }
    }
}
