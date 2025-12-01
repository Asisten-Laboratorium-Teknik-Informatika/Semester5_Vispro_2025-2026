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
    public partial class Recipe : Form
    {
        private Dashboard parentDashboard;
        private NewRecipe newRecipe;

        string connectionString = "server=localhost;database=db_cooklab;uid=root;pwd=;";

        public Recipe(Dashboard dashboardYangMemanggil)
        {
            InitializeComponent();

            this.parentDashboard = dashboardYangMemanggil;
        }

        public Recipe(object resepYangDipilih)
        {
            InitializeComponent();
        }

        public Recipe(NewRecipe newRecipe)
        {
            this.newRecipe = newRecipe;
        }

        public Recipe()
        {
        }

        private void TampilkanData()
        {
            flowPanelResep.Controls.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM resep ORDER BY tanggal_dibuat DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nama = reader.GetString("nama_resep");
                                DateTime tgl = reader.GetDateTime("tanggal_dibuat");

                                ResepCard kartu = new ResepCard();
                                kartu.SetData(id, nama, tgl);
                                kartu.Click += (s, e) =>
                                {
                                    DetailResep formDetail = new DetailResep(id);
                                    formDetail.ShowDialog();

                                    TampilkanData();
                                };

                                flowPanelResep.Controls.Add(kartu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Recipe_Load(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.parentDashboard.Show();
            this.Close();
        

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void buatResepBaruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRecipe newRecipeForm = new NewRecipe();
            newRecipeForm.Show();

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Recipe_Load_1(object sender, EventArgs e)
        {

        }
    }
}
