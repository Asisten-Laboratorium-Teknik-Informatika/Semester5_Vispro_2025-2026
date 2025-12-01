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

namespace CookLab
{
    public partial class DetailResep : Form
    {
        string connectionString = "server=localhost;database=db_cooklab;uid=root;pwd=;";
        int idResepYangDipilih;
        public DetailResep(int id)
        {
            InitializeComponent();
            this.idResepYangDipilih = id;
        }
        private void DetailResep_Load(object sender, EventArgs e)
        {
            LoadDetail();
        }

        private void LoadDetail()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM resep WHERE id = @id"; // Ambil SPESIFIK 1 resep aja

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idResepYangDipilih);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Masukin data db ke TextBox biar bisa diedit
                                txtNama.Text = reader.GetString("nama_resep");
                                txtBahan.Text = reader.GetString("bahan");
                                txtLangkah.Text = reader.GetString("langkah");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ambil data: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Mantra Update
                    string query = "UPDATE resep SET nama_resep=@nama, bahan=@bahan, langkah=@langkah WHERE id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idResepYangDipilih);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@bahan", txtBahan.Text);
                        cmd.Parameters.AddWithValue("@langkah", txtLangkah.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Resep berhasil di-update! ✨");
                        this.Close(); // Tutup form setelah update
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
        "Yakin mau menghapus resep ini selamanya? \nData yang dihapus nggak bisa balik lagi loh (kayak mantan).",
        "Konfirmasi Hapus",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

            // Kalau user bilang "YES" (beneran mau hapus)
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        // 2. MANTRA PENGHANCUR
                        string query = "DELETE FROM resep WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Pastikan kita hapus ID yang BENAR (sesuai resep yang lagi dibuka)
                            cmd.Parameters.AddWithValue("@id", idResepYangDipilih);

                            int barisTerhapus = cmd.ExecuteNonQuery();

                            if (barisTerhapus > 0)
                            {
                                MessageBox.Show("Resep berhasil dihapus. Sayonara! 👋", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 3. Tutup form detail biar balik ke daftar
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Aneh, data gagal dihapus. Mungkin udah ilang duluan?", "Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void berandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();

            this.Close();
        }

        private void resepSayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recipe formResep = new Recipe(this);
            formResep.Show();
            this.Hide();
        }
    }
}
