using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawLodge
{
    public partial class UC_Register : UserControl
    {
        private readonly string connStr = 
            "server=localhost;port=3306;user=root;password=;database=pawlodgedb;Charset=utf8mb4;";

        public UC_Register()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
        }

        // ============================================
        // EVENT - Tombol Daftar
        // ============================================
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;
            string confirm = txtConfirm.Text;

            // Validasi Input
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Semua field harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Password dan konfirmasi tidak sama!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirm.Focus();
                txtConfirm.SelectAll();
                return;
            }

            if (user.Length < 4 || pass.Length < 6)
            {
                MessageBox.Show("Username minimal 4 karakter\nPassword minimal 6 karakter", 
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnRegister.Enabled = false;
            btnRegister.Text = "Mendaftar...";

            bool berhasil = false;

            try
            {
                berhasil = await Task.Run(() => ProsesRegistrasi(user, pass));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan database!\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnRegister.Enabled = true;
            btnRegister.Text = "Daftar";

            // Jika gagal (username sudah ada)
            if (!berhasil)
            {
                MessageBox.Show("Username sudah digunakan!", "Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Jika berhasil
            MessageBox.Show("Registrasi berhasil! Silakan login kembali.",
                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // NAVIGASI kembali ke login (PASTI WORK)
            if (this.Parent is Panel panel)
            {
                panel.Controls.Clear();
                panel.Controls.Add(new UC_Login { Dock = DockStyle.Fill });
            }
        }



        // ============================================
        // PROSES DATABASE (thread terpisah)
        // ============================================
        private bool ProsesRegistrasi(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // CEK USERNAME
                string checkSql = "SELECT COUNT(*) FROM users WHERE username=@u";
                using (MySqlCommand cmd = new MySqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        return false; // Username sudah ada
                    }
                }

                // INSERT USER BARU
                string insertSql = "INSERT INTO users (username, password) VALUES (@u, @p)";
                using (MySqlCommand cmd = new MySqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password); // nanti ganti dengan hash
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }

     
        // Tekan ENTER = daftar
        private void txtConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnRegister.PerformClick();
            }
        }
         private void lblBackLogin_Click(object sender, EventArgs e)
        {
            // Pindahkan UserControl ke Register tanpa freeze
            var container = this.Parent;
            container.Controls.Clear();
            container.Controls.Add(new UC_Login());
        }
    }
    }

