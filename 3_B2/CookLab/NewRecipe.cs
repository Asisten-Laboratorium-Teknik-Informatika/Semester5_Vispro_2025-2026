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
    public partial class NewRecipe : Form
    {
        string connectionString = "server=localhost;database=db_cooklab;uid=root;pwd=;";
        public NewRecipe()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();

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
            object selectedRecipe = GetFirstSavedRecipePlaceholder();

            if (selectedRecipe != null)
            {
                Recipe recipeDetailForm = new Recipe(selectedRecipe);

                recipeDetailForm.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Tidak ada resep yang ditemukan. Mengarahkan Anda ke Dashboard.", "Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dashboard dashboardForm = new Dashboard();
                dashboardForm.Show();
                this.Close();
            }
        }

        private object GetFirstSavedRecipePlaceholder()
        {
            return new object();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (txtNamaResep.Text == "" || txtBahan.Text == "" || txtLangkah.Text == "")
            {
                MessageBox.Show("Eits, jangan ada yang kosong dong, bestie!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO resep (nama_resep, bahan, langkah) VALUES (@nama, @bahan, @langkah)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", txtNamaResep.Text);
                        cmd.Parameters.AddWithValue("@bahan", txtBahan.Text);
                        cmd.Parameters.AddWithValue("@langkah", txtLangkah.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Resep berhasil disimpan! Kamu hebat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNamaResep.Clear();
                        txtBahan.Clear();
                        txtLangkah.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duh, ada error nih: " + ex.Message);
            }
        }
    }
}
