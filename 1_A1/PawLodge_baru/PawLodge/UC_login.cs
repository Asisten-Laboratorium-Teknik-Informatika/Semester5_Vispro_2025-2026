using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PawLodge
{
    public partial class UC_Login : UserControl
    {
        string connStr = "server=127.0.0.1;port=3306;user=root;password=;database=pawlodgedb;";

        public UC_Login()
        {
            InitializeComponent();

            // Optimasi UI agar halus & cepat
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Isi username dan password!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hasil = 0;

            // Jalankan koneksi MySQL di background biar UI tidak lag
            await Task.Run(() =>
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string sql = "SELECT COUNT(*) FROM users WHERE username=@u AND password=@p";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@u", user);
                            cmd.Parameters.AddWithValue("@p", pass);
                            hasil = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi gagal!\n\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            if (hasil > 0)
            {
                Form parent = this.FindForm();
                parent.Hide();

                FormMain main = new FormMain();
                main.FormClosed += (s, args) => parent.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah!", "Login Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            // Pindahkan UserControl ke Register tanpa freeze
            var container = this.Parent;
            container.Controls.Clear();
            container.Controls.Add(new UC_Register());
        }
    }
}
