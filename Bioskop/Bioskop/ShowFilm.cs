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
    public partial class ShowFilm : Form
    {
        public ShowFilm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingTiket bookingTiket = new BookingTiket();
            bookingTiket.Show();
            this.Hide();
        }

        private void spidey_Click(object sender, EventArgs e)
        {
            DetailSpider df = new DetailSpider(
                "Action, Adventure, Sci-Fi",
                "2 Jam 28 Menit",
                "13+",
                "8.7 / 10",
                "Ketika identitas Spider-Man terbongkar kepada publik,\n" +
    "Peter meminta bantuan Doctor Strange.\n" +
    "Namun mantra yang gagal membuka multiverse\n" +
    "dan menghadirkan musuh dari dimensi lain."
            );

            df.Show();
            this.Hide();
        }



        

        private void TheNunII_Click_1(object sender, EventArgs e)
        {
            TheNunIIDetail df = new TheNunIIDetail(
                           "Horror, Mystery, Thriller",
                           "1 Jam 50 Menit",
                           "17+",
                           "6.0 / 10",
                           "Kisah kelanjutan dari biarawati yang\n" +
                           "berhadapan dengan iblis Valak\n" +
                           "di biara tua Eropa."
                        );

            df.Show();
            this.Hide();
        }

       

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DoctorDetail df = new DoctorDetail(
              "Action, Adventure, Fantasy",
              "2 Jam 6 Menit",
              "13+",
              "7.0 / 10",
              "Setelah membuka multiverse, Doctor Strange harus\n" +
              "menghadapi ancaman dari berbagai dimensi.\n" +
              "Ia bekerja sama dengan Wanda, Wong, dan America Chavez,\n" +
              "namun kenyataan runtuh ketika musuh tak terduga muncul."
          );

            df.Show();
            this.Hide();
        }
    }
}
