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
    public partial class DoctorDetail : Form
    {
        public DoctorDetail(string gender, string duration, string age, string rating, string sinopsis)
        {
            InitializeComponent();
            lblGender.Text = gender;
            lblDuration.Text = duration;
            lblAge.Text = age;
            lblRating.Text = rating;
            lblSinopsis.Text = sinopsis;
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

        private void Trailer_Click(object sender, EventArgs e)
        {
            DoctorTrailer doctorTrailer = new DoctorTrailer();
            doctorTrailer.Show();
            this.Hide();
        }
    }
}
