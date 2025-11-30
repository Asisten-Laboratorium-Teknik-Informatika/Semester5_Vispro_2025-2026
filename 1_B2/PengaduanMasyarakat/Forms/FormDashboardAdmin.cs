using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PengaduanMasyarakat.Utils;
using PengaduanMasyarakat.Models;

namespace PengaduanMasyarakat.Forms
{
    public partial class FormDashboardAdmin : Form
    {
        public FormDashboardAdmin()
        {
            InitializeComponent();
            lblUsername.Text = SessionManager.CurrentUser.NamaLengkap;
            LoadPengaduanMasukPanel();
        }

        private void btnPengaduanMasuk_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnPengaduanMasuk.BackColor = Color.FromArgb(56, 142, 60);
            lblTitle.Text = "Pengaduan Masuk";
            LoadPengaduanMasukPanel();
        }

        private void btnRiwayatSelesai_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnRiwayatSelesai.BackColor = Color.FromArgb(56, 142, 60);
            lblTitle.Text = "Riwayat Selesai";
            LoadRiwayatSelesaiPanel();
        }

        private void ResetButtonColors()
        {
            btnPengaduanMasuk.BackColor = Color.FromArgb(46, 125, 50);
            btnRiwayatSelesai.BackColor = Color.FromArgb(46, 125, 50);
        }

        private void LoadPengaduanMasukPanel()
        {
            panelContent.Controls.Clear();

            DataGridView dgv = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(890, 450),
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

            Button btnLihatDetail = new Button
            {
                Text = "Lihat Detail",
                Location = new Point(20, 490),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            btnLihatDetail.FlatAppearance.BorderSize = 0;

            Button btnUbahStatus = new Button
            {
                Text = "Ubah Status",
                Location = new Point(150, 490),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(255, 152, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            btnUbahStatus.FlatAppearance.BorderSize = 0;

            Button btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Location = new Point(280, 490),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;

            try
            {
                LoadDataPengaduan(dgv);

                dgv.CellFormatting += (s, ev) =>
                {
                    if (dgv.Columns["Status"] != null && ev.ColumnIndex == dgv.Columns["Status"].Index && ev.Value != null)
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

            btnLihatDetail.Click += (s, ev) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    int pengaduanId = Convert.ToInt32(dgv.SelectedRows[0].Cells["ID"].Value);
                    ShowDetailPengaduan(pengaduanId);
                }
                else
                {
                    MessageBox.Show("Pilih pengaduan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnUbahStatus.Click += (s, ev) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    int pengaduanId = Convert.ToInt32(dgv.SelectedRows[0].Cells["ID"].Value);
                    string currentStatus = GetOriginalStatus(dgv.SelectedRows[0].Cells["Status"].Value.ToString());
                    ShowUbahStatusDialog(pengaduanId, currentStatus, dgv);
                }
                else
                {
                    MessageBox.Show("Pilih pengaduan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnRefresh.Click += (s, ev) =>
            {
                LoadDataPengaduan(dgv);
                MessageBox.Show("Data berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            panelContent.Controls.AddRange(new Control[] { dgv, btnLihatDetail, btnUbahStatus, btnRefresh });
        }

        private void LoadDataPengaduan(DataGridView dgv)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT p.id as 'ID', p.nama_pelapor as 'Pelapor', p.jenis_kejadian as 'Jenis', " +
                             "p.lokasi_kejadian as 'Lokasi', DATE_FORMAT(p.tanggal_laporan, '%d-%m-%Y %H:%i') as 'Tanggal', " +
                             "p.status as 'Status' FROM pengaduan p ORDER BY p.tanggal_laporan DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);

                dgv.DataSource = dt;

                if (dgv.Columns["Status"] != null)
                {
                    dgv.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private string GetOriginalStatus(string displayStatus)
        {
            if (displayStatus.Contains("Belum")) return "pending";
            if (displayStatus.Contains("Sedang")) return "diproses";
            if (displayStatus.Contains("Selesai")) return "selesai";
            return "pending";
        }

        private void ShowDetailPengaduan(int pengaduanId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM pengaduan WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", pengaduanId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Pengaduan p = new Pengaduan
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            NamaPelapor = reader["nama_pelapor"].ToString(),
                            NomorTelepon = reader["nomor_telepon"].ToString(),
                            LokasiKejadian = reader["lokasi_kejadian"].ToString(),
                            JenisKejadian = reader["jenis_kejadian"].ToString(),
                            Deskripsi = reader["deskripsi"].ToString(),
                            FotoPath = reader["foto_path"] != DBNull.Value ? reader["foto_path"].ToString() : null,
                            Status = reader["status"].ToString(),
                            TanggalLaporan = Convert.ToDateTime(reader["tanggal_laporan"])
                        };

                        reader.Close();

                        Form detailForm = new Form
                        {
                            Text = "Detail Pengaduan #" + p.Id,
                            Size = new Size(600, 650),
                            StartPosition = FormStartPosition.CenterParent,
                            FormBorderStyle = FormBorderStyle.FixedDialog,
                            MaximizeBox = false,
                            MinimizeBox = false
                        };

                        Panel panel = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White, Padding = new Padding(20) };

                        int yPos = 10;

                        AddDetailLabel(panel, "ID Pengaduan:", p.Id.ToString(), ref yPos);
                        AddDetailLabel(panel, "Nama Pelapor:", p.NamaPelapor, ref yPos);
                        AddDetailLabel(panel, "Nomor Telepon:", p.NomorTelepon, ref yPos);
                        AddDetailLabel(panel, "Jenis Kejadian:", p.JenisKejadian, ref yPos);
                        AddDetailLabel(panel, "Lokasi:", p.LokasiKejadian, ref yPos);
                        AddDetailLabel(panel, "Tanggal Laporan:", p.TanggalLaporan.ToString("dd MMMM yyyy HH:mm"), ref yPos);

                        Label lblDeskripsi = new Label
                        {
                            Text = "Deskripsi:",
                            Location = new Point(20, yPos),
                            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                            AutoSize = true
                        };
                        panel.Controls.Add(lblDeskripsi);
                        yPos += 25;

                        TextBox txtDeskripsi = new TextBox
                        {
                            Text = p.Deskripsi,
                            Location = new Point(20, yPos),
                            Size = new Size(520, 80),
                            Multiline = true,
                            ReadOnly = true,
                            Font = new Font("Segoe UI", 9F),
                            BackColor = Color.White
                        };
                        panel.Controls.Add(txtDeskripsi);
                        yPos += 95;

                        if (!string.IsNullOrEmpty(p.FotoPath) && File.Exists(p.FotoPath))
                        {
                            Label lblFoto = new Label
                            {
                                Text = "Foto Kejadian:",
                                Location = new Point(20, yPos),
                                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                                AutoSize = true
                            };
                            panel.Controls.Add(lblFoto);
                            yPos += 25;

                            PictureBox picBox = new PictureBox
                            {
                                Location = new Point(20, yPos),
                                Size = new Size(300, 200),
                                SizeMode = PictureBoxSizeMode.Zoom,
                                BorderStyle = BorderStyle.FixedSingle,
                                Image = Image.FromFile(p.FotoPath)
                            };
                            panel.Controls.Add(picBox);
                            yPos += 210;
                        }

                        Button btnTutup = new Button
                        {
                            Text = "Tutup",
                            Location = new Point(240, yPos),
                            Size = new Size(100, 35),
                            BackColor = Color.FromArgb(46, 125, 50),
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Cursor = Cursors.Hand
                        };
                        btnTutup.FlatAppearance.BorderSize = 0;
                        btnTutup.Click += (s, ev) => detailForm.Close();
                        panel.Controls.Add(btnTutup);

                        detailForm.Controls.Add(panel);
                        detailForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDetailLabel(Panel panel, string label, string value, ref int yPos)
        {
            Label lbl = new Label
            {
                Text = label,
                Location = new Point(20, yPos),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                AutoSize = true
            };
            panel.Controls.Add(lbl);

            Label lblValue = new Label
            {
                Text = value,
                Location = new Point(180, yPos),
                Font = new Font("Segoe UI", 10F),
                AutoSize = true,
                MaximumSize = new Size(380, 0)
            };
            panel.Controls.Add(lblValue);

            yPos += 30;
        }

        private void ShowUbahStatusDialog(int pengaduanId, string currentStatus, DataGridView dgv)
        {
            Form statusForm = new Form
            {
                Text = "Ubah Status Pengaduan",
                Size = new Size(400, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblInfo = new Label
            {
                Text = "Pilih status baru untuk pengaduan:",
                Location = new Point(30, 30),
                Font = new Font("Segoe UI", 10F),
                AutoSize = true
            };

            ComboBox cmbStatus = new ComboBox
            {
                Location = new Point(30, 60),
                Size = new Size(320, 25),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new string[] { "pending", "diproses", "selesai" });
            cmbStatus.SelectedItem = currentStatus;

            Button btnSimpan = new Button
            {
                Text = "Simpan",
                Location = new Point(130, 120),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(46, 125, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSimpan.FlatAppearance.BorderSize = 0;

            btnSimpan.Click += (s, ev) =>
            {
                string newStatus = cmbStatus.SelectedItem.ToString();

                try
                {
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE pengaduan SET status = @status WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", pengaduanId);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Status berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataPengaduan(dgv);
                            statusForm.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            statusForm.Controls.AddRange(new Control[] { lblInfo, cmbStatus, btnSimpan });
            statusForm.ShowDialog();
        }

        private void LoadRiwayatSelesaiPanel()
        {
            panelContent.Controls.Clear();

            DataGridView dgv = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(890, 520),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(76, 175, 80),
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
                    string query = "SELECT p.id as 'ID', p.nama_pelapor as 'Pelapor', p.jenis_kejadian as 'Jenis', " +
                                 "p.lokasi_kejadian as 'Lokasi', DATE_FORMAT(p.tanggal_laporan, '%d-%m-%Y') as 'Tanggal Laporan', " +
                                 "DATE_FORMAT(p.tanggal_update, '%d-%m-%Y') as 'Tanggal Selesai' " +
                                 "FROM pengaduan p WHERE p.status = 'selesai' ORDER BY p.tanggal_update DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    dgv.DataSource = dt;
                }

                dgv.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
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