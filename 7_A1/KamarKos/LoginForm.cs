using KamarKos.Koneksi;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KamarKos
{
    public partial class LoginForm : Form
    {
        MySqlConnection conn;
        public LoginForm()
        {
            InitializeComponent();
            // Ambil koneksi dari class KoneksiDatabase.cs
            KoneksiDatabase db = new KoneksiDatabase();
            conn = db.GetConn();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM admin WHERE username=@user AND password=@pass";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MainMenuForm menu = new MainMenuForm();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister register = new FormRegister();
            register.Show();
        }
        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.Red;
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.Blue;
        }

    }
}
