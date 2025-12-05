using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PawLodge
{
    public partial class UC_Dashboard : UserControl
    {
        private string connStr = "server=localhost;user=root;password=;database=pawlodgedb;";
        private Timer refreshTimer; // Untuk auto refresh tiap 10 detik

        public UC_Dashboard()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;

            // Auto refresh tiap 10 detik (bisa diubah jadi 5 detik kalau mau lebih cepat)
            refreshTimer = new Timer();
            refreshTimer.Interval = 10000; // 10 detik
            refreshTimer.Tick += (s, e) => LoadDashboardData();
            refreshTimer.Start();

            LoadDashboardData();
        }

        // ==== AMBIL DATA DENGAN AMAN ====
        private int GetCount(string query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch { return 0; }
        }

        private decimal GetTotalPendapatanHariIni()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT COALESCE(SUM(total_bayar), 0) FROM transactions WHERE DATE(tanggal_bayar) = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == null || result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                    }
                }
            }
            catch { return 0; }
        }

        private void LoadDashboardData()
        {
            flowStats.Controls.Clear();

            // 1. Total Pendapatan Hari Ini
            decimal pendapatan = GetTotalPendapatanHariIni();
            flowStats.Controls.Add(CreateBigCard(
                "Pendapatan Hari Ini",
                "Rp " + pendapatan.ToString("N0"),
                Properties.Resources.icon_money,
                Color.FromArgb(255, 105, 180)
            ));

            // 2. Reservasi Hari Ini
            flowStats.Controls.Add(CreateCard(
                "Reservasi Hari Ini",
                GetCount("SELECT COUNT(*) FROM reservations WHERE DATE(tanggal_reservasi) = CURDATE()").ToString(),
                Properties.Resources.icon_calendar,
                Color.FromArgb(200, 100, 255)
            ));

            // 3. Menunggu Konfirmasi
            flowStats.Controls.Add(CreateCard(
                "Menunggu Konfirmasi",
                GetCount("SELECT COUNT(*) FROM reservations WHERE status = 'Menunggu Konfirmasi'").ToString(),
                Properties.Resources.icon_waiting,
                Color.FromArgb(255, 150, 100)
            ));
        
            // 4. Total Customer
            flowStats.Controls.Add(CreateCard(
                "Total Customer",
                GetCount("SELECT COUNT(*) FROM customers").ToString(),
                Properties.Resources.icon_customer,
                Color.FromArgb(150, 220, 100)
            ));

            // 5. Kamar Terisi
            flowStats.Controls.Add(CreateCard(
                "Kamar Terisi",
                GetCount("SELECT COUNT(*) FROM reservations WHERE status = 'Check-in'").ToString(),
                Properties.Resources.icon_room,
                Color.FromArgb(255, 100, 150)
            ));
        }

        // ==== CARD BESAR UNTUK PENDAPATAN (SPESIAL) ====
        private Panel CreateBigCard(string title, string value, Image icon, Color accentColor)
        {
            Panel card = new Panel
            {
                Size = new Size(540, 160),
                BackColor = Color.White,
                Margin = new Padding(20),
                Padding = new Padding(20),
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pb = new PictureBox
            {
                Image = icon,
                Size = new Size(70, 70),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(20, 30)
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = accentColor,
                AutoSize = true,
                Location = new Point(110, 30)
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = accentColor,
                AutoSize = true,
                Location = new Point(110, 70)
            };

            // Garis dekorasi
            Panel line = new Panel
            {
                BackColor = accentColor,
                Size = new Size(6, 100),
                Location = new Point(0, 30)
            };

            card.Controls.Add(line);
            card.Controls.Add(pb);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);

            return card;
        }

        // ==== CARD BIASA ====
        private Panel CreateCard(string title, string value, Image icon, Color accentColor)
        {
            Panel card = new Panel
            {
                Size = new Size(260, 150),
                BackColor = Color.White,
                Margin = new Padding(20),
                Padding = new Padding(15),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            // Hover effect
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(255, 245, 255);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            PictureBox pb = new PictureBox
            {
                Image = icon,
                Size = new Size(50, 50),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(15, 25)
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = accentColor,
                AutoSize = true,
                Location = new Point(80, 25)
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = accentColor,
                AutoSize = true,
                Location = new Point(80, 65)
            };

            card.Controls.Add(pb);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);

            return card;
        }
    }
}