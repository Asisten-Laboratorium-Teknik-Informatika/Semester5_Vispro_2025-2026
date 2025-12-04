using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bioskop
{
    public partial class TheNunIIDetail : Form
    {
      

        public TheNunIIDetail(string gender, string duration, string age, string rating, string sinopsis)
        {
            InitializeComponent();

            lblGender.Text = gender;
            lblDuration.Text = duration;
            lblAge.Text = age;
            lblRating.Text = rating;
            lblSinopsis.Text = sinopsis;
        }


 
        private void TheNunII_Click(object sender, EventArgs e)
        {

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowFilm showFilm = new ShowFilm();
            showFilm.ShowDialog();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TheNunTrailer theNunTrailer = new TheNunTrailer();
            theNunTrailer.Show();
            this.Close();
        }

        private void TheNunIIDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
