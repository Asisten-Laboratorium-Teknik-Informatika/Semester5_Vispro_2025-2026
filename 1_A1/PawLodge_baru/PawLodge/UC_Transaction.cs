using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PawLodge
{
    public partial class UC_Transaction : UserControl
    {
        private string connStr = "server=127.0.0.1;port=3306;user=root;password=;database=pawlodgedb;";
        private Button btnDelete;

        public UC_Transaction()
        {
            InitializeComponent();

            // HAPUS GAMBAR TOTAL
            if (this.Controls.Contains(picTransaction))
            {
                this.Controls.Remove(picTransaction);
                picTransaction.Dispose();
            }

            // Tambah tombol Hapus
            btnDelete = new Button
            {
                Text = "Hapus Transaksi",
                Location = new Point(380, 450),
                Size = new Size(160, 23),
                BackColor = Color.FromArgb(220, 20, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            this.Controls.Add(btnDelete);

            // Event
            this.Load += UC_Transaction_Load;
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            btnPrint.Click += btnPrint_Click;
        }

        private void UC_Transaction_Load(object sender, EventArgs e)
        {
            SetupDataGridView(); // PENTING: Atur ulang kolom agar pasti 4 saja
            LoadTransactions();
        }

        private void SetupDataGridView()
        {
            dgvTransactions.Columns.Clear(); // Hapus semua kolom lama

            // Tambah 4 kolom sesuai keinginanmu
            dgvTransactions.Columns.Add("Tanggal", "Tanggal");
            dgvTransactions.Columns.Add("NamaCustomer", "Nama Customer");
            dgvTransactions.Columns.Add("Layanan", "Layanan");
            dgvTransactions.Columns.Add("Total", "Total");

            // Atur lebar
            dgvTransactions.Columns["Tanggal"].Width = 120;
            dgvTransactions.Columns["NamaCustomer"].Width = 200;
            dgvTransactions.Columns["Layanan"].Width = 180;
            dgvTransactions.Columns["Total"].Width = 140;

            // Styling cantik
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkMagenta;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.BackgroundColor = Color.FromArgb(255, 240, 250);
            dgvTransactions.GridColor = Color.LightPink;
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 250, 255);
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadTransactions()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            DATE(t.tanggal_bayar) AS tanggal,
                            c.nama_pemilik AS customer,
                            r.layanan AS layanan,
                            t.total_bayar AS total
                        FROM transactions t
                        JOIN reservations r ON t.reservation_id = r.id
                        JOIN customers c ON r.customer_id = c.id
                        WHERE DATE(t.tanggal_bayar) = CURDATE()
                        ORDER BY t.tanggal_bayar DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTransactions.Rows.Clear();

                    decimal totalHariIni = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvTransactions.Rows.Add(
                            ((DateTime)row["tanggal"]).ToString("dd/MM/yyyy"),
                            row["customer"].ToString(),
                            row["layanan"].ToString(),
                            "Rp " + Convert.ToDecimal(row["total"]).ToString("N0")
                        );
                        totalHariIni += Convert.ToDecimal(row["total"]);
                    }

                    lblTotal.Text = $"Total Pendapatan Hari Ini: Rp {totalHariIni:N0}";
                    lblTotal.ForeColor = Color.MediumVioletRed;
                    lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddTransactionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string sql = "INSERT INTO transactions (reservation_id, total_bayar, tanggal_bayar) VALUES (@id, @total, NOW())";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", form.ReservationId);
                            cmd.Parameters.AddWithValue("@total", form.TotalBayar);
                            cmd.ExecuteNonQuery();
                        }
                        new MySqlCommand($"UPDATE reservations SET status = 'Selesai' WHERE id = {form.ReservationId}", conn).ExecuteNonQuery();
                    }
                    LoadTransactions();
                    MessageBox.Show("Transaksi berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Hapus transaksi ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Ambil data dari baris yang dipilih
                string nama = dgvTransactions.SelectedRows[0].Cells["NamaCustomer"].Value.ToString();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        // Cari reservation_id dari nama customer & tanggal hari ini
                        string sql = "SELECT t.id, t.reservation_id FROM transactions t " +
                                   "JOIN reservations r ON t.reservation_id = r.id " +
                                   "JOIN customers c ON r.customer_id = c.id " +
                                   "WHERE c.nama_pemilik = @nama AND DATE(t.tanggal_bayar) = CURDATE() " +
                                   "ORDER BY t.tanggal_bayar DESC LIMIT 1";

                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        MySqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            int transId = r.GetInt32("id");
                            int resId = r.GetInt32("reservation_id");
                            r.Close();

                            new MySqlCommand($"DELETE FROM transactions WHERE id = {transId}", conn).ExecuteNonQuery();
                            new MySqlCommand($"UPDATE reservations SET status = 'Check-in' WHERE id = {resId}", conn).ExecuteNonQuery();
                        }
                    }
                    LoadTransactions();
                    MessageBox.Show("Transaksi dihapus!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih transaksi dulu!");
                return;
            }

            var row = dgvTransactions.SelectedRows[0];
            string nama = row.Cells["NamaCustomer"].Value.ToString();
            string layanan = row.Cells["Layanan"].Value.ToString();
            string total = row.Cells["Total"].Value.ToString();

            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF File|*.pdf",
                FileName = $"Nota_{nama}_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = save.FileName;

                pd.PrintPage += (s, ev) =>
                {
                    Font title = new Font("Segoe UI", 22, FontStyle.Bold);
                    Font normal = new Font("Segoe UI", 11);
                    Font bold = new Font("Segoe UI", 13, FontStyle.Bold);
                    Font big = new Font("Segoe UI", 20, FontStyle.Bold);

                    float y = 80;
                    float x = 100;

                    ev.Graphics.DrawString("PAWLODGE PET CARE", title, new SolidBrush(Color.HotPink), x, y);
                    y += 60;
                    ev.Graphics.DrawString($"Customer: {nama}", bold, Brushes.Black, x, y);
                    y += 40;
                    ev.Graphics.DrawString($"Layanan : {layanan}", normal, Brushes.Black, x, y);
                    y += 60;
                    ev.Graphics.DrawLine(Pens.HotPink, x, y, 400, y);
                    y += 40;
                    ev.Graphics.DrawString("TOTAL", big, Brushes.Crimson, x, y);
                    ev.Graphics.DrawString(total, big, new SolidBrush(Color.DeepPink), x + 150, y);
                    y += 80;
                    ev.Graphics.DrawString("Terima kasih", normal, Brushes.Black, x, y);
                };

                pd.Print();
                MessageBox.Show("Nota disimpan!\n" + save.FileName);
            }
        }
    }

    // Form Tambah Transaksi - Harga Manual
    public class AddTransactionForm : Form
    {
        public int ReservationId { get; private set; }
        public decimal TotalBayar { get; private set; }
        private ComboBox cmb;
        private TextBox txtHarga;

        public AddTransactionForm()
        {
            this.Text = "Tambah Transaksi";
            this.Size = new Size(580, 320);
            this.StartPosition = FormStartPosition.CenterParent;

            new Label { Text = "Pilih Reservasi:", Top = 30, Left = 30, Parent = this };
            cmb = new ComboBox { Top = 60, Left = 30, Width = 500, DropDownStyle = ComboBoxStyle.DropDownList, Parent = this };

            new Label { Text = "Total Bayar (Rp):", Top = 110, Left = 30, Parent = this };
            txtHarga = new TextBox { Top = 140, Left = 30, Width = 500, Text = "0", TextAlign = HorizontalAlignment.Right, Font = new Font("Segoe UI", 14F), Parent = this };

            LoadData();

            var btn = new Button { Text = "Simpan", Top = 210, Left = 200, Width = 150, Height = 50, BackColor = Color.HotPink, ForeColor = Color.White, Parent = this };
            btn.Click += (s, e) =>
            {
                if (cmb.SelectedItem == null || !decimal.TryParse(txtHarga.Text, out decimal harga) || harga <= 0)
                {
                    MessageBox.Show("Isi dengan benar!");
                    return;
                }
                dynamic item = cmb.SelectedItem;
                ReservationId = item.Id;
                TotalBayar = harga;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection c = new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=;database=pawlodgedb;"))
                {
                    c.Open();
                    var cmd = new MySqlCommand("SELECT r.id, c.nama_pemilik, r.layanan FROM reservations r JOIN customers c ON r.customer_id = c.id WHERE r.status IN ('Menunggu Konfirmasi','Check-in')", c);
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        cmb.Items.Add(new { Id = r.GetInt32(0), Text = r.GetString(1) + " - " + r.GetString(2) });
                    }
                    r.Close();
                }
                cmb.DisplayMember = "Text";
                if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
            }
            catch { }
        }
    }
}