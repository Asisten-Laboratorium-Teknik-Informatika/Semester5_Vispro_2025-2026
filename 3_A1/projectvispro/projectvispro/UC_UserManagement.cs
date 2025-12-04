using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projectvispro
{
    public partial class UC_UserManagement : UserControl
    {
        int selectedUserId = 0;

        public UC_UserManagement()
        {
            InitializeComponent();
            TampilkanData();
            LoadRole();
        }

        private void TampilkanData()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        private void LoadRole()
        {
            var data = new[]
            {
        new { Text = "Administrator", Value = "admin" },
        new { Text = "Kasir", Value = "kasir" }
    };

            comboBoxRole.DisplayMember = "Text";
            comboBoxRole.ValueMember = "Value";
            comboBoxRole.DataSource = data;
        }

        private void ResetForm()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxKonfirmasiPassword.Clear();
            comboBoxRole.SelectedIndex = 0;
            btnSimpan.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Username wajib diisi!");
                return;
            }
            if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Password wajib diisi!");
                return;
            }
            if (textBoxPassword.Text != textBoxKonfirmasiPassword.Text)
            {
                MessageBox.Show("Password tidak sama!");
                return;
            }
            string role = comboBoxRole.Text;
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO users (username, password, role) VALUES (@u, @p, @r)", conn);
            cmd.Parameters.AddWithValue("@u", textBoxUsername.Text);
            cmd.Parameters.AddWithValue("@p", textBoxPassword.Text);
            cmd.Parameters.AddWithValue("@r", comboBoxRole.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("User berhasil ditambahkan!");
            TampilkanData();
            ResetForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Pilih user terlebih dahulu!");
                return;
            }
            if (textBoxPassword.Text != textBoxKonfirmasiPassword.Text)
            {
                MessageBox.Show("Password tidak sama!");
                return;
            }
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            string query;
            if (textBoxPassword.Text == "")
            {
                query = "UPDATE users SET username=@u, role=@r WHERE id_user=@id";
            }
            else
            {
                query = "UPDATE users SET username=@u, password=@p, role=@r WHERE id_user=@id";
            }
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", textBoxUsername.Text);
            cmd.Parameters.AddWithValue("@r", comboBoxRole.SelectedValue);
            cmd.Parameters.AddWithValue("@id", selectedUserId);
            if (textBoxPassword.Text != "")
            {
                cmd.Parameters.AddWithValue("@p", textBoxPassword.Text);
            }
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("User berhasil diupdate!");
            TampilkanData();
            ResetForm();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["id_user"].Value);
                textBoxUsername.Text = row.Cells["username"].Value.ToString();
                comboBoxRole.SelectedValue = row.Cells["role"].Value.ToString();
                btnSimpan.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Pilih data yang mau dihapus!");
                return;
            }
            string id = dgvUsers.CurrentRow.Cells["id_user"].Value.ToString();
            DialogResult dr = MessageBox.Show(
                "Yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (dr == DialogResult.No) return;
            MySqlConnection conn = Database.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM users WHERE id_user=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("User berhasil dihapus!");
            TampilkanData();
            ResetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
