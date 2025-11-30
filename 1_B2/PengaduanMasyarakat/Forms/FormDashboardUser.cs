using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PengaduanMasyarakat.Utils;

namespace PengaduanMasyarakat.Forms
{
    public partial class FormDashboardUser : Form
    {
        private Panel currentPanel;

        public FormDashboardUser()
        {
            InitializeComponent();
            lblUsername.Text = SessionManager.CurrentUser.NamaLengkap;
            LoadBuatPengaduanPanel();
        }

        private void btnBuatPengaduan_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnBuatPengaduan.BackColor = Color.FromArgb(56, 142, 60);
            lblTitle.Text = "Buat Pengaduan";
            LoadBuatPengaduanPanel();
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnRiwayat.BackColor = Color.FromArgb(56, 142, 60);
            lblTitle.Text = "Riwayat Pengaduan";
            LoadRiwayatPanel();
        }

        private void ResetButtonColors()
        {
            btnBuatPengaduan.BackColor = Color.FromArgb(46, 125, 50);
            btnRiwayat.BackColor = Color.FromArgb(46, 125, 50);
        }

        private void LoadBuatPengaduanPanel()
        {
            panelContent.Controls.Clear();

            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(30)
            };

            Label lblNama = new Label { Text = "Nama Pelapor", Location = new Point(30, 30), Font = new Font("Segoe UI", 10F), AutoSize = true };
            TextBox txtNama = new TextBox { Location = new Point(30, 55), Size = new Size(350, 25), Font = new Font("Segoe UI", 10F), Name = "txtNama" };
            txtNama.Text = SessionManager.CurrentUser.NamaLengkap;

            Label lblTelepon = new Label { Text = "Nomor Telepon", Location = new Point(30, 95), Font = new Font("Segoe UI", 10F), AutoSize = true };
            TextBox txtTelepon = new TextBox { Location = new Point(30, 120), Size = new Size(350, 25), Font = new Font("Segoe UI", 10F), Name = "txtTelepon" };

            Label lblLokasi = new Label { Text = "Lokasi Kejadian", Location = new Point(30, 160), Font = new Font("Segoe UI", 10F), AutoSize = true };
            TextBox txtLokasi = new TextBox { Location = new Point(30, 185), Size = new Size(680, 25), Font = new Font("Segoe UI", 10F), Name = "txtLokasi" };

            Label lblJenis = new Label { Text = "Jenis Kejadian", Location = new Point(30, 225), Font = new Font("Segoe UI", 10F), AutoSize = true };
            ComboBox cmbJenis = new ComboBox { Location = new Point(30, 250), Size = new Size(350, 25), Font = new Font("Segoe UI", 10F), DropDownStyle = ComboBoxStyle.DropDownList, Name = "cmbJenis" };
            cmbJenis.Items.AddRange(new string[] { "Kecelakaan", "Perampokan", "Penipuan", "Kerusakan Fasilitas", "Lainnya" });

            Label lblDeskripsi = new Label { Text = "Deskripsi Kejadian", Location = new Point(30, 290), Font = new Font("Segoe UI", 10F), AutoSize = true };
            TextBox txtDeskripsi = new TextBox { Location = new Point(30, 315), Size = new Size(680, 80), Font = new Font("Segoe UI", 10F), Multiline = true, Name = "txtDeskripsi" };

            Label lblFoto = new Label { Text = "Foto Kejadian (Opsional)", Location = new Point(30, 410), Font = new Font("Segoe UI", 10F), AutoSize = true };
            Button btnPilihFoto = new Button { Text = "Pilih Foto", Location = new Point(30, 435), Size = new Size(120, 35), BackColor = Color.FromArgb(46, 125, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Name = "btnPilihFoto" };
            btnPilihFoto.FlatAppearance.BorderSize = 0;

            Label lblNamaFoto = new Label { Text = "Belum ada foto dipilih", Location = new Point(160, 443), Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray, AutoSize = true, Name = "lblNamaFoto" };

            Button btnSubmit = new Button { Text = "KIRIM PENGADUAN", Location = new Point(30, 480), Size = new Size(200, 40), BackColor = Color.FromArgb(46, 125, 50), ForeColor = Color.White, Font = new Font("Segoe UI", 11F, FontStyle.Bold), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnSubmit.FlatAppearance.BorderSize = 0;

            string selectedFilePath = "";

            btnPilihFoto.Click += (s, ev) =>
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                    Title = "Pilih Foto Kejadian"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    lblNamaFoto.Text = Path.GetFileName(selectedFilePath);
                    lblNamaFoto.ForeColor = Color.FromArgb(46, 125, 50);
                }
            };

            btnSubmit.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtTelepon.Text) ||
                    string.IsNullOrWhiteSpace(txtLokasi.Text) || cmbJenis.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtDeskripsi.Text))
                {
                    MessageBox.Show("Semua field wajib diisi kecuali foto!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string fotoPath = null;

                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                        if (!Directory.Exists(imagesFolder))
                            Directory.CreateDirectory(imagesFolder);

                        string fileName = $"{DateTime.Now.Ticks}_{Path.GetFileName(selectedFilePath)}";
                        fotoPath = Path.Combine(imagesFolder, fileName);
                        File.Copy(selectedFilePath, fotoPath);
                    }

                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string query = "INSERT INTO pengaduan (user_id, nama_pelapor, nomor_telepon, lokasi_kejadian, jenis_kejadian, deskripsi, foto_path, status) " +
                                     "VALUES (@user_id, @nama, @telepon, @lokasi, @jenis, @deskripsi, @foto, 'pending')";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@user_id", SessionManager.CurrentUser.Id);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@telepon", txtTelepon.Text);
                        cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text);
                        cmd.Parameters.AddWithValue("@jenis", cmbJenis.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text);
                        cmd.Parameters.AddWithValue("@foto", fotoPath ?? (object)DBNull.Value);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Pengaduan berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNama.Clear();
                            txtTelepon.Clear();
                            txtLokasi.Clear();
                            cmbJenis.SelectedIndex = -1;
                            txtDeskripsi.Clear();
                            selectedFilePath = "";
                            lblNamaFoto.Text = "Belum ada foto dipilih";
                            lblNamaFoto.ForeColor = Color.Gray;
                            txtNama.Text = SessionManager.CurrentUser.NamaLengkap;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            panel.Controls.AddRange(new Control[] { lblNama, txtNama, lblTelepon, txtTelepon, lblLokasi, txtLokasi, lblJenis, cmbJenis, lblDeskripsi, txtDeskripsi, lblFoto, btnPilihFoto, lblNamaFoto, btnSubmit });
            panelContent.Controls.Add(panel);
        }

        private void LoadRiwayatPanel()
        {
            panelContent.Controls.Clear();

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(46, 125, 50),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9F),
                    SelectionBackColor = Color.FromArgb(200, 230, 201)
                }
            };

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id as 'ID', jenis_kejadian as 'Jenis', lokasi_kejadian as 'Lokasi', " +
                                 "DATE_FORMAT(tanggal_laporan, '%d-%m-%Y %H:%i') as 'Tanggal', status as 'Status' " +
                                 "FROM pengaduan WHERE user_id = @user_id ORDER BY tanggal_laporan DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user_id", SessionManager.CurrentUser.Id);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    dgv.DataSource = dt;

                    if (dgv.Columns["Status"] != null)
                    {
                        dgv.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                }

                dgv.CellFormatting += (s, ev) =>
                {
                    if (ev.ColumnIndex == dgv.Columns["Status"].Index && ev.Value != null)
                    {
                        string status = ev.Value.ToString();
                        if (status == "pending")
                        {
                            ev.CellStyle.BackColor = Color.LightGray;
                            ev.CellStyle.ForeColor = Color.Black;
                            ev.Value = "⚪ Belum Ditindaki";
                        }
                        else if (status == "diproses")
                        {
                            ev.CellStyle.BackColor = Color.Yellow;
                            ev.CellStyle.ForeColor = Color.Black;
                            ev.Value = "🟡 Sedang Diproses";
                        }
                        else if (status == "selesai")
                        {
                            ev.CellStyle.BackColor = Color.LightGreen;
                            ev.CellStyle.ForeColor = Color.Black;
                            ev.Value = "🟢 Selesai";
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panelContent.Controls.Add(dgv);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Close();
            }
        }
    }
}