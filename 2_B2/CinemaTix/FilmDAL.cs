using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace CinemaTix.DAL
{
    public class FilmDAL
    {
        public DataTable GetSemuaFilm()
        {
            // Query SQL Anda harus memilih kolom 'FilmID' agar fungsi CellClick bekerja
            string query = "SELECT FilmID, Judul, DurasiMenit, Genre, PathPoster FROM Films";

            DataTable dt = new DataTable();

            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat mengambil data film: " + ex.Message);
                    return null;
                }
            }
        }
        public DataRow GetFilmByID(int filmId)
        {
            DataTable dt = new DataTable();
            // Ambil semua kolom yang Anda butuhkan (minimal Judul)
            string query = "SELECT FilmID, Judul, DurasiMenit, Genre, PathPoster FROM Films WHERE FilmID = @FilmID";

            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FilmID", filmId);
                    try
                    {
                        conn.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);

                        // Kembalikan baris pertama (satu film)
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                    catch (Exception ex)
                    {
                        // Pastikan koneksi dan XAMPP berjalan
                        MessageBox.Show("Error saat mengambil detail film: " + ex.Message, "Error DAL Film");
                        return null;
                    }
                }
            }
        }
    }
}