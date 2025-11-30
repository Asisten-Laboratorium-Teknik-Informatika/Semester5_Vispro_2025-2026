using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaTix.DAL;

namespace CinemaTix
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPass_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            UserDAL userDAL = new UserDAL();
            DataTable dtUser = userDAL.ValidateUser(user, pass);

            if (dtUser != null && dtUser.Rows.Count == 1)
            {
                // 1. LOGIN BERHASIL
                string role = dtUser.Rows[0]["Role"].ToString();
                MessageBox.Show($"Selamat datang, {user}! Anda login sebagai {role}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 2. Tampilkan Form Utama (Form1)
                Form1 formUtama = new Form1(user);
                formUtama.Show();

                // 3. Sembunyikan Form Login
                this.Hide();
            }
            else
            {
                // LOGIN GAGAL
                MessageBox.Show("Username atau Password salah.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister register = new FormRegister();
            register.Show();
            this.Hide();
        }
    }
}
