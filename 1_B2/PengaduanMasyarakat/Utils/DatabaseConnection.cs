using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PengaduanMasyarakat.Utils
{
    public class DatabaseConnection
    {
        private static string connectionString = "Server=localhost;Database=pengaduan_masyarakat;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi database gagal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}