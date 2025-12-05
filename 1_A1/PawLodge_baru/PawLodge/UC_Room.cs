using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PawLodge
{
    public partial class UC_Room : UserControl
    {
        private string connStr = "server=127.0.0.1;port=3306;user=root;password=;database=pawlodgedb;";

        public UC_Room()
        {
            InitializeComponent();
            btnAddRoom.Click += btnAddRoom_Click;
            btnEditRoom.Click += btnEditRoom_Click;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
        }

        private void UC_Room_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void LoadRooms()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            r.id,
                            r.no_kamar AS 'No. Kamar',
                            r.tipe_kamar AS 'Tipe Kamar',
                            COALESCE(res.status, 'Kosong') AS 'Status',
                            IFNULL(c.nama_pemilik, '-') AS 'Diisi Oleh'
                        FROM rooms r
                        LEFT JOIN reservations res ON r.id = res.room_id 
                            AND res.status IN ('Menunggu Konfirmasi', 'Check-in')
                        LEFT JOIN customers c ON res.customer_id = c.id
                        ORDER BY r.no_kamar";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvRooms.DataSource = null;
                    dgvRooms.Columns.Clear();
                    dgvRooms.DataSource = dt;

                    if (dgvRooms.Columns.Contains("id")) dgvRooms.Columns["id"].Visible = false;

                    // Styling cantik
                    foreach (DataGridViewRow row in dgvRooms.Rows)
                    {
                        row.Height = 60;
                        string status = row.Cells["Status"].Value?.ToString() ?? "Kosong";

                        if (status.Contains("Terisi") || status == "Check-in" || status == "Menunggu Konfirmasi")
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
                            row.Cells["Status"].Style.ForeColor = Color.Crimson;
                            row.Cells["Status"].Value = "Terisi";
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
                            row.Cells["Status"].Style.ForeColor = Color.DarkGreen;
                            row.Cells["Status"].Value = "Kosong";
                        }
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    }

                    // Header
                    dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 105, 180);
                    dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    dgvRooms.EnableHeadersVisualStyles = false;
                    dgvRooms.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgvRooms.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data kamar: " + ex.Message);
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var form = new RoomForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();

                        // Simpan kamar
                        string insertRoom = "INSERT INTO rooms (no_kamar, tipe_kamar) VALUES (@no, @tipe)";
                        using (MySqlCommand cmd = new MySqlCommand(insertRoom, conn))
                        {
                            cmd.Parameters.AddWithValue("@no", form.NoKamar);
                            cmd.Parameters.AddWithValue("@tipe", form.TipeKamar);
                            cmd.ExecuteNonQuery();
                        }

                        // Jika status "Terisi", simpan ke reservations
                        if (form.SelectedCustomerId > 0)
                        {
                            string insertRes = @"INSERT INTO reservations 
                                               (customer_id, room_id, jenis_hewan, layanan, tanggal_reservasi, status) 
                                               VALUES (@cust, LAST_INSERT_ID(), @hewan, 'Penitipan', @tgl, 'Check-in')";
                            using (MySqlCommand cmd = new MySqlCommand(insertRes, conn))
                            {
                                cmd.Parameters.AddWithValue("@cust", form.SelectedCustomerId);
                                cmd.Parameters.AddWithValue("@hewan", form.JenisHewan ?? "Tidak diketahui");
                                cmd.Parameters.AddWithValue("@tgl", DateTime.Today);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    LoadRooms();
                    MessageBox.Show("Kamar berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0) { MessageBox.Show("Pilih kamar dulu!"); return; }

            int id = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["id"].Value);
            string no = dgvRooms.SelectedRows[0].Cells["No. Kamar"].Value.ToString();
            string tipe = dgvRooms.SelectedRows[0].Cells["Tipe Kamar"].Value.ToString();
            string status = dgvRooms.SelectedRows[0].Cells["Status"].Value.ToString();

            var form = new RoomForm(no, tipe, status == "Terisi");
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();

                        // Update kamar
                        string update = "UPDATE rooms SET no_kamar=@no, tipe_kamar=@tipe WHERE id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@no", form.NoKamar);
                            cmd.Parameters.AddWithValue("@tipe", form.TipeKamar);
                            cmd.ExecuteNonQuery();
                        }

                        // Hapus reservasi lama jika ada
                        new MySqlCommand("DELETE FROM reservations WHERE room_id = " + id, conn).ExecuteNonQuery();

                        // Jika status "Terisi", buat reservasi baru
                        if (form.SelectedCustomerId > 0)
                        {
                            string insertRes = @"INSERT INTO reservations 
                                               (customer_id, room_id, jenis_hewan, layanan, tanggal_reservasi, status) 
                                               VALUES (@cust, @room, @hewan, 'Penitipan', @tgl, 'Check-in')";
                            using (MySqlCommand cmd = new MySqlCommand(insertRes, conn))
                            {
                                cmd.Parameters.AddWithValue("@cust", form.SelectedCustomerId);
                                cmd.Parameters.AddWithValue("@room", id);
                                cmd.Parameters.AddWithValue("@hewan", form.JenisHewan ?? "Tidak diketahui");
                                cmd.Parameters.AddWithValue("@tgl", DateTime.Today);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    LoadRooms();
                    MessageBox.Show("Kamar berhasil diperbarui!");
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0) { MessageBox.Show("Pilih kamar!"); return; }
            if (MessageBox.Show("Yakin hapus kamar ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["id"].Value);
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        new MySqlCommand("DELETE FROM reservations WHERE room_id = " + id, conn).ExecuteNonQuery();
                        new MySqlCommand("DELETE FROM rooms WHERE id = " + id, conn).ExecuteNonQuery();
                    }
                    LoadRooms();
                    MessageBox.Show("Kamar berhasil dihapus!");
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }
    }

    // FORM TAMBAH/EDIT KAMAR YANG SESUAI PERMINTAANMU!
    public class RoomForm : Form
    {
        public string NoKamar { get; private set; }
        public string TipeKamar { get; private set; }
        public int SelectedCustomerId { get; private set; } = 0;
        public string JenisHewan { get; private set; }

        private ComboBox cmbCustomer;
        private RadioButton rbKosong, rbTerisi;

        public RoomForm(string no = "", string tipe = "", bool isTerisi = false)
        {
            this.Text = no == "" ? "Tambah Kamar" : "Edit Kamar";
            this.Size = new Size(500, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.White;

            // No. Kamar
            new Label { Text = "No. Kamar:", Location = new Point(30, 20), Parent = this, Font = new Font("Segoe UI", 11F) };
            var txtNo = new TextBox { Location = new Point(30, 50), Width = 420, Text = no, Parent = this, Font = new Font("Segoe UI", 11F) };

            // Tipe Kamar
            new Label { Text = "Tipe Kamar:", Location = new Point(30, 90), Parent = this, Font = new Font("Segoe UI", 11F) };
            var txtTipe = new TextBox { Location = new Point(30, 120), Width = 420, Text = tipe, Parent = this, Font = new Font("Segoe UI", 11F) };

            // Status
            new Label { Text = "Status Kamar:", Location = new Point(30, 170), Parent = this, Font = new Font("Segoe UI", 11F, FontStyle.Bold) };
            rbKosong = new RadioButton { Text = "Kosong", Location = new Point(30, 200), Checked = !isTerisi, Parent = this, Font = new Font("Segoe UI", 10F) };
            rbTerisi = new RadioButton { Text = "Terisi (Pilih Customer)", Location = new Point(160, 200), Checked = isTerisi, Parent = this, Font = new Font("Segoe UI", 10F) };

            // Pilih Customer
            new Label { Text = "Diisi Oleh (Customer):", Location = new Point(30, 240), Parent = this, Font = new Font("Segoe UI", 11F) };
            cmbCustomer = new ComboBox { Location = new Point(30, 270), Width = 420, DropDownStyle = ComboBoxStyle.DropDownList, Parent = this, Font = new Font("Segoe UI", 11F) };
            cmbCustomer.Enabled = isTerisi;

            // Load customer dari database
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=;database=pawlodgedb;"))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT id, nama_pemilik, jenis_hewan FROM customers ORDER BY nama_pemilik", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string nama = reader.GetString("nama_pemilik");
                        string hewan = reader.GetString("jenis_hewan");
                        cmbCustomer.Items.Add(new { Id = id, Text = $"{nama} - {hewan}" });
                    }
                    cmbCustomer.DisplayMember = "Text";
                }
            }
            catch { }

            rbTerisi.CheckedChanged += (s, e) => cmbCustomer.Enabled = rbTerisi.Checked;

            // Tombol Simpan
            var btnSave = new Button
            {
                Text = "Simpan Kamar",
                Size = new Size(180, 50),
                Location = new Point(150, 320),
                BackColor = Color.FromArgb(255, 105, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Parent = this
            };

            btnSave.Click += (s, e) =>
            {
                NoKamar = txtNo.Text.Trim();
                TipeKamar = txtTipe.Text.Trim();

                if (string.IsNullOrEmpty(NoKamar) || string.IsNullOrEmpty(TipeKamar))
                {
                    MessageBox.Show("No. Kamar dan Tipe Kamar wajib diisi!");
                    return;
                }

                if (rbTerisi.Checked && cmbCustomer.SelectedItem == null)
                {
                    MessageBox.Show("Pilih customer jika status Terisi!");
                    return;
                }

                if (rbTerisi.Checked && cmbCustomer.SelectedItem != null)
                {
                    dynamic item = cmbCustomer.SelectedItem;
                    SelectedCustomerId = item.Id;
                    JenisHewan = item.Text.Split('-')[1].Trim();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }
    }
}