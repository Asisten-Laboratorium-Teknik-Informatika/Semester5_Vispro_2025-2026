using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace APLIKASI_POS_KASIR_MODERN
{
    public partial class HomeForm : Form
    {
        private string _username;

        public HomeForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        // ====== DROP SHADOW ======
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        // ====== FORM SUDUT MELENGKUNG ======
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeft, int nTop,
            int nRight, int nBottom,
            int nWidthEllipse, int nHeightEllipse
        );

        private void SetRoundedForm(int radius)
        {
            this.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, this.Width, this.Height, radius, radius)
            );
        }

        // ====== FADE IN ======
        private Timer fadeTimer;
        private void StartFadeIn()
        {
            this.Opacity = 0;
            fadeTimer = new Timer();
            fadeTimer.Interval = 15;
            fadeTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fadeTimer.Stop();
            };
            fadeTimer.Start();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = _username;

            SetRoundedForm(25); // Rounded Form
            StartFadeIn();      // Fade Effect

            LoadKasirSummary();
        }

        private void LoadKasirSummary()
        {
            string connStr = "Data Source=.;Initial Catalog=POSDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // TOTAL TERJUAL & PENDAPATAN
                string query = @"
                    SELECT 
                        COUNT(*) AS TotalProdukTerjual,
                        SUM(TotalHarga) AS TotalPendapatan,
                        COUNT(NoTransaksi) AS TotalTransaksi
                    FROM Penjualan
                    WHERE Kasir = @Kasir";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Kasir", _username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTotalProduk.Text = reader["TotalProdukTerjual"].ToString();
                            lblTotalTransaksi.Text = reader["TotalTransaksi"].ToString();

                            lblPendapatan.Text = reader["TotalPendapatan"] != DBNull.Value
                                ? Convert.ToDecimal(reader["TotalPendapatan"]).ToString("C")
                                : "Rp 0";
                        }
                    }
                }
            }
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void panelProduk_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
