using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace projectvispro
{
    public partial class UC_Dashboard : UserControl
    {
        private string currentUser;
        private string currentRole;

        public UC_Dashboard()
        {
            InitializeComponent();
            this.Load += UC_Dashboard_Load;
            LoadTotalBarang();
            LoadTotalSupplier();
            LoadTotalKategori();
            LoadTodayTransaksi();
            LoadChartTransaksi();
            LoadDataGridTransaksi();
        }

        private void LoadTotalBarang()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM barang";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                labelPanelTotalBarang.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void LoadTotalKategori()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM kategori";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                labelPanelTotalKategori.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void LoadTotalSupplier()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM supplier";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                labelPanelTotalSupplier.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void LoadTodayTransaksi()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) AS total_transaksi_hari_ini FROM transaksi WHERE DATE(tanggal) = CURDATE();";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                labelPanelTodayTransaksi.Text = cmd.ExecuteScalar().ToString();
            }
        }


        private void borderTumpul(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            //borderTumpul(panelTotalBarang, 35);
            //borderTumpul(panelTotalKategori, 35);
            //borderTumpul(panelTotalSupplier, 35);
            //borderTumpul(panelTodayTransaksi, 35);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadChartTransaksi()
        {
            chartTransaksi.Series.Clear();
            chartTransaksi.Series.Clear();
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            string query = @"SELECT DATE(tanggal) AS tanggal, COUNT(*) AS jumlah_transaksi FROM transaksi WHERE tanggal >= CURDATE() - INTERVAL 6 DAY GROUP BY DATE(tanggal) ORDER BY tanggal ASC;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            Series series = new Series("Transaksi");
            series.ChartType = SeriesChartType.Bar; // bisa diganti Line
            while (reader.Read())
            {
                string tanggal = Convert.ToDateTime(reader["tanggal"]).ToString("dd-MM");
                int jumlah = Convert.ToInt32(reader["jumlah_transaksi"]);
                series.Points.AddXY(tanggal, jumlah);
            }
            chartTransaksi.Series.Add(series);
            conn.Close();
        }

        private void LoadDataGridTransaksi()
        {
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            string query = @"SELECT id AS 'ID Transaksi', tanggal AS 'Tanggal', total AS 'Total' 
                     FROM transaksi 
                     ORDER BY tanggal DESC 
                     LIMIT 10;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dgvTransaksi.DataSource = dt;
            conn.Close();
        }
    }
}
