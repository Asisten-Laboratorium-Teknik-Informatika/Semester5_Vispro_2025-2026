using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaTix.DAL;

namespace CinemaTix
{
    public partial class FormHistory : Form
    {
        private string _username;

        // Constructor menerima username
        public FormHistory(string username)
        {
            InitializeComponent();
            _username = username;

            // Ubah judul form
            this.Text = "Riwayat Pemesanan - " + _username;
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            LoadHistoryData();
        }

        private void LoadHistoryData()
        {
            PemesananDAL pemesananDAL = new PemesananDAL();
            DataTable dt = pemesananDAL.GetRiwayatByUser(_username);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvHistory.DataSource = dt;

                // Opsional: Formatting kolom agar lebih rapi
                if (dgvHistory.Columns.Contains("TotalHarga"))
                {
                    dgvHistory.Columns["TotalHarga"].DefaultCellStyle.Format = "N0"; // Format angka ribuan
                }

                dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Belum ada riwayat pemesanan.", "Info");
            }
        }
        public FormHistory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
