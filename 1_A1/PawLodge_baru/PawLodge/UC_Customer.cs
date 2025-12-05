using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PawLodge
{
    public partial class UC_Customer : UserControl
    {
        private string connStr = "server=127.0.0.1;port=3306;user=root;password=;database=pawlodgedb;";

        public UC_Customer()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void UC_Customer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            id,
                            nama_pemilik AS 'Nama Pemilik',
                            alamat AS 'Alamat',
                            no_hp AS 'No. HP',
                            jenis_hewan AS 'Jenis Hewan'
                        FROM customers 
                        ORDER BY id DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCustomers.DataSource = null;
                    dgvCustomers.Columns.Clear();
                    dgvCustomers.DataSource = dt;

                    // Sembunyikan kolom ID
                    if (dgvCustomers.Columns.Contains("id"))
                        dgvCustomers.Columns["id"].Visible = false;

                    // Styling tambahan
                    dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 245, 252);
                    dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                    dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "INSERT INTO customers (nama_pemilik, alamat, no_hp, jenis_hewan) VALUES (@nama, @alamat, @nohp, @jenis)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", form.NamaPemilik);
                            cmd.Parameters.AddWithValue("@alamat", form.Alamat);
                            cmd.Parameters.AddWithValue("@nohp", form.NoHP);
                            cmd.Parameters.AddWithValue("@jenis", form.JenisHewan);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadCustomers();
                    MessageBox.Show("Customer berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih satu baris data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["id"].Value);
            string nama = dgvCustomers.SelectedRows[0].Cells["Nama Pemilik"].Value.ToString();
            string alamat = dgvCustomers.SelectedRows[0].Cells["Alamat"].Value?.ToString() ?? "";
            string nohp = dgvCustomers.SelectedRows[0].Cells["No. HP"].Value.ToString();
            string jenis = dgvCustomers.SelectedRows[0].Cells["Jenis Hewan"].Value?.ToString() ?? "";

            var form = new CustomerForm(nama, alamat, nohp, jenis);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "UPDATE customers SET nama_pemilik=@nama, alamat=@alamat, no_hp=@nohp, jenis_hewan=@jenis WHERE id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@nama", form.NamaPemilik);
                            cmd.Parameters.AddWithValue("@alamat", form.Alamat);
                            cmd.Parameters.AddWithValue("@nohp", form.NoHP);
                            cmd.Parameters.AddWithValue("@jenis", form.JenisHewan);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadCustomers();
                    MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["id"].Value);
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "DELETE FROM customers WHERE id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadCustomers();
                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }
    }

    // Form dialog (tetap cantik)
    public class CustomerForm : Form
    {
        public string NamaPemilik { get; private set; }
        public string Alamat { get; private set; }
        public string NoHP { get; private set; }
        public string JenisHewan { get; private set; }

        private TextBox txtNama, txtAlamat, txtNoHP, txtJenis;

        public CustomerForm(string nama = "", string alamat = "", string nohp = "", string jenis = "")
        {
            this.Text = "Tambah / Edit Customer";
            this.Size = new Size(420, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            CreateField("Nama Pemilik:", 20, ref txtNama, nama);
            CreateField("Alamat:", 70, ref txtAlamat, alamat);
            CreateField("No. HP:", 120, ref txtNoHP, nohp);
            CreateField("Jenis Hewan:", 170, ref txtJenis, jenis);

            Button btnSave = new Button
            {
                Text = "Simpan",
                Size = new Size(100, 40),
                Location = new Point(160, 220),
                BackColor = Color.FromArgb(255, 200, 220),
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += (s, e) =>
            {
                NamaPemilik = txtNama.Text.Trim();
                Alamat = txtAlamat.Text.Trim();
                NoHP = txtNoHP.Text.Trim();
                JenisHewan = txtJenis.Text.Trim();

                if (string.IsNullOrEmpty(NamaPemilik) || string.IsNullOrEmpty(NoHP))
                {
                    MessageBox.Show("Nama Pemilik dan No. HP wajib diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            this.Controls.Add(btnSave);
            this.AcceptButton = btnSave;
        }

        private void CreateField(string label, int y, ref TextBox txt, string value)
        {
            this.Controls.Add(new Label { Text = label, Location = new Point(30, y + 3), AutoSize = true });
            txt = new TextBox { Location = new Point(30, y + 25), Width = 340, Text = value };
            this.Controls.Add(txt);
        }
    }
}