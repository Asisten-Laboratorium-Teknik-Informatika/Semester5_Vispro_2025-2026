using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PawLodge
{
    public partial class UC_Reservation : UserControl
    {
        private string connStr = "server=127.0.0.1;port=3306;user=root;password=;database=pawlodgedb;";

        // Class kecil untuk menyimpan ID + Nama Customer
        private class CustomerItem
        {
            public int Id { get; set; }
            public string Nama { get; set; }
            public override string ToString() => Nama;
        }

        public UC_Reservation()
        {
            InitializeComponent();
            btnReserve.Click += btnReserve_Click;
        }

        private void UC_Reservation_Load(object sender, EventArgs e)
        {
            LoadCustomersAndPets();
        }

        private void LoadCustomersAndPets()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 1. Load Customer (nama + simpan ID)
                    string queryCust = "SELECT id, nama_pemilik FROM customers ORDER BY nama_pemilik";
                    using (MySqlCommand cmd = new MySqlCommand(queryCust, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbCustomer.Items.Clear();
                        while (reader.Read())
                        {
                            cmbCustomer.Items.Add(new CustomerItem
                            {
                                Id = reader.GetInt32("id"),
                                Nama = reader.GetString("nama_pemilik")
                            });
                        }
                    }

                    // 2. Load Jenis Hewan (unik)
                    string queryPet = "SELECT DISTINCT jenis_hewan FROM customers WHERE jenis_hewan IS NOT NULL AND jenis_hewan != '' ORDER BY jenis_hewan";
                    using (MySqlCommand cmd = new MySqlCommand(queryPet, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbPet.Items.Clear();
                        while (reader.Read())
                        {
                            string jenis = reader.GetString("jenis_hewan");
                            cmbPet.Items.Add(jenis);
                        }
                    }
                }

                // Jika ada data, pilih yang pertama (opsional)
                if (cmbCustomer.Items.Count > 0) cmbCustomer.SelectedIndex = 0;
                if (cmbPet.Items.Count > 0) cmbPet.SelectedIndex = 0;
                if (cmbService.Items.Count > 0) cmbService.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data customer/hewan:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem == null || cmbPet.SelectedItem == null || cmbService.SelectedItem == null)
            {
                MessageBox.Show("Harap lengkapi semua pilihan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCust = (CustomerItem)cmbCustomer.SelectedItem;
            int customerId = selectedCust.Id;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"INSERT INTO reservations 
                                   (customer_id, jenis_hewan, layanan, tanggal_reservasi, status) 
                                   VALUES (@cid, @hewan, @layanan, @tgl, 'Menunggu Konfirmasi')";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", customerId);
                        cmd.Parameters.AddWithValue("@hewan", cmbPet.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@layanan", cmbService.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@tgl", dtpDate.Value.Date);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Reservasi berhasil disimpan atas nama:\n{selectedCust.Nama}\nKami akan segera konfirmasi!",
                              "Sukses!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form
                cmbCustomer.SelectedIndex = -1;
                cmbPet.SelectedIndex = -1;
                cmbService.SelectedIndex = -1;
                dtpDate.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan reservasi:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}