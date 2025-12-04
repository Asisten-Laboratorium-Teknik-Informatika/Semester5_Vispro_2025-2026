using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Bioskop
{
    public partial class BookingTiket : Form
    {
        // Variabel stok (di-sync dari DB)
        int stockSpiderman = 100;
        int stockNun = 100;
        int stockDrStrange = 100;

        // Kursi yang dipilih sementara
        List<string> selectedSeats = new List<string>();

        // Kursi yang sudah dibooking permanen selama aplikasi berjalan
        // key = "<movie>-<studio>" -> list of seat codes
        Dictionary<string, List<string>> bookedSeats = new Dictionary<string, List<string>>();

        // Harga Film (default/in-memory). Akan disinkronkan dari DB saat load.
        Dictionary<string, int> hargaFilm = new Dictionary<string, int>()
        {
            { "SPIDERMAN", 55000 },
            { "THE NUN II", 45000 },
            { "Doctor Strange", 50000 }
        };

        public BookingTiket()
        {
            InitializeComponent();

            // Optional: matikan double-buffer jika perlu
            try
            {
                panelDetailTiket.GetType()
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValue(panelDetailTiket, false);
            }
            catch { /* safe ignore */ }
        }

        private void BookingTiket_Load(object sender, EventArgs e)
        {
            LoadStokDanHargaDariDatabase();
            LoadDataGridTiket();
            // Render kursi sesuai bookedSeats (jika ada)
            ResetAllSeats();
        }

        // Buat key unik per film+studio
        private string GetSeatKey()
        {
            return comboMovie.Text + "-" + comboStudio.Text;
        }

        // Reset & render kursi sesuai bookedSeats; juga kosongkan selectedSeats
        private void ResetAllSeats()
        {
            // Jangan hilangkan seatsStr jika ingin menampilkan detail sebelum reset
            selectedSeats.Clear();
            labelSeatNumber.Text = "";

            string key = GetSeatKey();

            if (!bookedSeats.ContainsKey(key))
                bookedSeats[key] = new List<string>();

            // Cari semua button kursi di form (asumsi Text A1..C10)
            foreach (Control control in this.Controls)
            {
                if (control is Button btn &&
                   (btn.Text.StartsWith("A") || btn.Text.StartsWith("B") || btn.Text.StartsWith("C")))
                {
                    if (bookedSeats[key].Contains(btn.Text))
                        btn.BackColor = Color.Red;   // sudah dibooking (permanen)
                    else
                        btn.BackColor = Color.White; // tersedia
                }
            }
        }

        // Load stok & harga film dari DB (sinkronisasi)
        private void LoadStokDanHargaDariDatabase()
        {
            try
            {
                Koneksi kon = new Koneksi();
                using (MySqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    string query = "SELECT title, stock, price FROM movies";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string movie = reader["title"].ToString();
                        int stock = Convert.ToInt32(reader["stock"]);
                        int price = 0;
                        try { price = Convert.ToInt32(reader["price"]); } catch { /* ignore */ }

                        // Update stok lokal dan label
                        if (movie == "SPIDERMAN")
                        {
                            stockSpiderman = stock;
                            lblStockSpiderman.Text = stock.ToString();
                        }
                        else if (movie == "THE NUN II")
                        {
                            stockNun = stock;
                            lblStockNun.Text = stock.ToString();
                        }
                        else if (movie == "Doctor Strange")
                        {
                            stockDrStrange = stock;
                            lblStockStrange.Text = stock.ToString();
                        }

                        // Sinkron harga ke dictionary agar saat memilih movie harga sesuai DB
                        if (price > 0)
                        {
                            if (hargaFilm.ContainsKey(movie))
                                hargaFilm[movie] = price;
                            else
                                hargaFilm.Add(movie, price);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load stok/harga film: " + ex.Message);
            }
        }

        // Update stok di database
        private void UpdateStockInDatabase(string movieTitle, int newStock)
        {
            try
            {
                Koneksi kon = new Koneksi();
                using (MySqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    string sql = "UPDATE movies SET stock = @stock WHERE title = @title";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@stock", newStock);
                    cmd.Parameters.AddWithValue("@title", movieTitle);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update stok database: " + ex.Message);
            }
        }

        // Load data tiket ke DataGridView
        private void LoadDataGridTiket()
        {
            try
            {
                Koneksi kon = new Koneksi();
                using (MySqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    string sql = @"SELECT movie_title AS 'Film', qty AS 'Qty', price AS 'Total', 
                                    seat AS 'Seat', date AS 'Tanggal', studio AS 'Studio'
                                   FROM tickets";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data tiket: " + ex.Message);
            }
        }

        // Event ketika klik tombol kursi (semua kursi Button harus terhubung ke handler ini)
        private void Seat_Click(object sender, EventArgs e)
        {
            Button seat = sender as Button;
            if (seat == null) return;

            string key = GetSeatKey();

            // Pastikan key ada
            if (!bookedSeats.ContainsKey(key))
                bookedSeats[key] = new List<string>();

            // Jika kursi sudah dibooking permanen
            if (bookedSeats[key].Contains(seat.Text))
            {
                MessageBox.Show("Kursi sudah dibooking!");
                return;
            }

            int qty = (int)txtQty.Value;

            // Jika sudah mencapai batas quantity
            if (!selectedSeats.Contains(seat.Text) && selectedSeats.Count >= qty)
            {
                MessageBox.Show($"Hanya dapat memilih maksimal {qty} kursi sesuai quantity!", "Peringatan");
                return;
            }

            // Toggle selection
            if (selectedSeats.Contains(seat.Text))
            {
                selectedSeats.Remove(seat.Text);
                seat.BackColor = Color.White;
            }
            else
            {
                selectedSeats.Add(seat.Text);
                seat.BackColor = Color.Yellow; // kursi sementara dipilih
            }

            labelSeatNumber.Text = string.Join(", ", selectedSeats);
        }

        // Saat ganti movie: update harga (dari dictionary) lalu render kursi sesuai key baru
        private void comboMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string movie = comboMovie.Text;
            if (hargaFilm.ContainsKey(movie))
            {
                // set harga dalam textbox (format angka biasa)
                textBox1.Text = hargaFilm[movie].ToString();
            }

            // Reset selected seats & render berdasarkan bookedSeats untuk movie-studio baru
            ResetAllSeats();
        }

        // Saat ganti studio: reset kursi sesuai key baru
        private void comboStudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAllSeats();
        }

        // Checkout: validasi, kurangi stok, simpan bookedSeats, lalu tampilkan detail tiket
        private void btnCheckou_Click(object sender, EventArgs e)
        {
            if (comboMovie.SelectedIndex == -1 ||
                comboShowTimes.SelectedIndex == -1 ||
                comboStudio.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(labelSeatNumber.Text) ||
                txtQty.Value <= 0)
            {
                MessageBox.Show("Semua data harus lengkap!");
                return;
            }

            string movie = comboMovie.Text;
            int qty = (int)txtQty.Value;

            if (selectedSeats.Count != qty)
            {
                MessageBox.Show($"Jumlah kursi terpilih ({selectedSeats.Count}) harus sama dengan quantity ({qty})!");
                return;
            }

            // Ambil harga dari dictionary jika ada, fallback ke input textBox1 (numeric)
            int unitPrice;
            if (hargaFilm.ContainsKey(movie))
                unitPrice = hargaFilm[movie];
            else if (!int.TryParse(textBox1.Text, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out unitPrice))
            {
                MessageBox.Show("Harga tidak valid!");
                return;
            }

            int total = qty * unitPrice;

            // Update stok memory + database (cek stok dulu)
            if (movie == "SPIDERMAN")
            {
                if (qty > stockSpiderman) { MessageBox.Show("Stok tidak cukup!"); return; }
                stockSpiderman -= qty;
                lblStockSpiderman.Text = stockSpiderman.ToString();
                UpdateStockInDatabase("SPIDERMAN", stockSpiderman);
            }
            else if (movie == "THE NUN II")
            {
                if (qty > stockNun) { MessageBox.Show("Stok tidak cukup!"); return; }
                stockNun -= qty;
                lblStockNun.Text = stockNun.ToString();
                UpdateStockInDatabase("THE NUN II", stockNun);
            }
            else if (movie == "Doctor Strange")
            {
                if (qty > stockDrStrange) { MessageBox.Show("Stok tidak cukup!"); return; }
                stockDrStrange -= qty;
                lblStockStrange.Text = stockDrStrange.ToString();
                UpdateStockInDatabase("Doctor Strange", stockDrStrange);
            }

            // Simpan booking seat ke bookedSeats (permanen selama app hidup)
            string key = GetSeatKey();
            if (!bookedSeats.ContainsKey(key))
                bookedSeats[key] = new List<string>();

            foreach (string s in selectedSeats)
            {
                if (!bookedSeats[key].Contains(s))
                    bookedSeats[key].Add(s);
            }

            // Simpan string seat sebelum reset (karena ResetAllSeats() mengosongkan selectedSeats & label)
            string seatsStr = string.Join(", ", selectedSeats);

            // Isi detail tiket dulu (pakai seatsStr) — penting agar tidak kosong
            lblDetailMovie.Text = movie;
            lblDetailShowtimes.Text = comboShowTimes.Text;
            lblDetailStudio.Text = comboStudio.Text;
            lblDetailQty.Text = qty.ToString();
            lblDetailDate.Text = datePicker.Text;
            lblDetailSeatt.Text = seatsStr;
            lblDetailPrice.Text = "Rp " + total.ToString("N0", CultureInfo.InvariantCulture);

            // Reset tampilan kursi berdasarkan bookedSeats (kursi permanen jadi merah)
            ResetAllSeats();

            MessageBox.Show("Checkout Berhasil!");
        }

        // Cetak tiket ke PNG (menggambar manual)
        private void btnCetak_Click_1(object sender, EventArgs e)
        {
            int width = 700;
            int height = 250;
            using (Bitmap tiket = new Bitmap(width, height))
            using (Graphics g = Graphics.FromImage(tiket))
            {
                g.FillRectangle(Brushes.Black, 0, 0, width, height);

                if (panelDetailTiket.BackgroundImage != null)
                {
                    g.DrawImage(panelDetailTiket.BackgroundImage, 0, 0, width, height);
                }

                Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
                Font fontData = new Font("Arial", 14, FontStyle.Regular);
                Brush brush = Brushes.White;

                g.DrawString("🎬 CINEMA XXI TICKET", fontTitle, brush, 10, 10);

                g.DrawString("Movie Title : " + lblDetailMovie.Text, fontData, brush, 10, 50);
                g.DrawString("Quantity : " + lblDetailQty.Text, fontData, brush, 10, 80);
                g.DrawString("Studio : " + lblDetailStudio.Text, fontData, brush, 10, 110);

                g.DrawString("Date : " + lblDetailDate.Text, fontData, brush, 350, 50);
                g.DrawString("Price : " + lblDetailPrice.Text, fontData, brush, 350, 80);
                g.DrawString("Show Times : " + lblDetailShowtimes.Text, fontData, brush, 350, 110);
                g.DrawString("Seat Number: " + lblDetailSeatt.Text, fontData, brush, 350, 140);

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PNG Image|*.png";
                save.Title = "Simpan E-Ticket";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    tiket.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Tiket berhasil disimpan!");
                }
            }
        }

        // Jika quantity berkurang: reset selected seats (agar jumlah sesuai)
        private void txtQty_ValueChanged(object sender, EventArgs e)
        {
            int qty = (int)txtQty.Value;

            if (selectedSeats.Count > qty)
            {
                MessageBox.Show($"Quantity dikurangi menjadi {qty}. Kursi yang dipilih akan direset.", "Peringatan");
                ResetAllSeats();
            }
        }

        // Kembali ke ShowFilm
        private void button2_Click(object sender, EventArgs e)
        {
            ShowFilm showFilm = new ShowFilm();
            showFilm.ShowDialog();
            this.Close();
        }

        // Simpan tiket ke database (tombol "Input" / Save)
        // Saat menyimpan, simpan price sebagai angka (tanpa "Rp ")
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblDetailMovie.Text))
            {
                MessageBox.Show("Checkout tiket dulu!");
                return;
            }

            try
            {
                // Ambil numeric price dari label (hilangkan "Rp " dan tanda pemisah)
                string priceText = lblDetailPrice.Text.Replace("Rp", "").Replace(" ", "").Replace(".", "").Replace(",", "");
                int priceNumeric = 0;
                int.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out priceNumeric);

                Koneksi kon = new Koneksi();
                using (MySqlConnection conn = kon.GetConn())
                {
                    conn.Open();
                    string sql = "INSERT INTO tickets(movie_title, qty, price, studio, seat, date) " +
                                "VALUES(@movie, @qty, @price, @studio, @seat, @date)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@movie", lblDetailMovie.Text);
                    cmd.Parameters.AddWithValue("@qty", int.Parse(lblDetailQty.Text));
                    cmd.Parameters.AddWithValue("@price", priceNumeric);
                    cmd.Parameters.AddWithValue("@studio", lblDetailStudio.Text);
                    cmd.Parameters.AddWithValue("@seat", lblDetailSeatt.Text);
                    cmd.Parameters.AddWithValue("@date", lblDetailDate.Text);
                    cmd.ExecuteNonQuery();
                }

                LoadDataGridTiket();
                MessageBox.Show("Tiket berhasil dimasukkan ke database!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Event handlers kosong untuk designer
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblStockSpiderman_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void lblMovie_Click(object sender, EventArgs e) { }
        private void lblDetailMovie_Click(object sender, EventArgs e) { }
        private void lblDetailDate_Click(object sender, EventArgs e) { }
        private void panelDetailTiket_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
