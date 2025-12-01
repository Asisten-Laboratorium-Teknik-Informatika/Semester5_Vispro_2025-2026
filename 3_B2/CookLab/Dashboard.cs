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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void viewRepices_Click(object sender, EventArgs e)
        {
            Recipe formResep = new Recipe(this);
            formResep.Show();
            this.Hide();
        }

        private void addRecipe_Click(object sender, EventArgs e)
        {
            NewRecipe formInput = new NewRecipe();

            this.Hide();
            formInput.ShowDialog();
            this.Show();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau ninggalin CookLab?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        

    }
}
