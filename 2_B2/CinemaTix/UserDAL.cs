using MySql.Data.MySqlClient;
using System.Data;

namespace CinemaTix.DAL
{
    public class UserDAL
    {
        // Method untuk memvalidasi kredensial pengguna
        public DataTable ValidateUser(string username, string password)
        {
            DataTable dt = new DataTable();
            string query = "SELECT UserID, Username, Role FROM Users " +
                           "WHERE Username = @user AND Password = @pass";

            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Gunakan Parameter untuk mencegah SQL Injection
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    try
                    {
                        conn.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt; // Mengembalikan DataTable berisi 1 baris jika berhasil
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error database saat login: " + ex.Message);
                        return null;
                    }
                }
            }
        }
        public bool RegisterUser(string username, string password)
        {
            // 1. Cek apakah Username sudah ada (untuk mencegah duplikat)
            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Username sudah terpakai, silakan pilih yang lain.");
                        return false;
                    }
                }
            }

            // 2. Jika belum ada, Lakukan INSERT
            string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, 'Customer')";

            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal mendaftar: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}