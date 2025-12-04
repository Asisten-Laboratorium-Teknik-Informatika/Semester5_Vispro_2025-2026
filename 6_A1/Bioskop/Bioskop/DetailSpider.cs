using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class DetailSpider : Form
    {
        public DetailSpider(string gender, string duration, string age, string rating, string sinopsis)
        {
            InitializeComponent();
            lblGender.Text = gender;
            lblDuration.Text = duration;
            lblAge.Text = age;
            lblRating.Text = rating;
            lblSinopsis.Text = sinopsis;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)

        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void lblDuration_Click(object sender, EventArgs e)
        {

        }

        private void lblAge_Click(object sender, EventArgs e)
        {

        }

        private void lblRating_Click(object sender, EventArgs e)
        {

        }

        private void lblSinopsis_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpiderTrailer spiderTrailer = new SpiderTrailer();
            spiderTrailer.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowFilm showFilm = new ShowFilm();
            showFilm.Show();
            this.Hide();
        }
    }
}
