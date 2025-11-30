using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTix.DAL;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CinemaTix
{
    internal class JadwalDAL
    {
        public DataTable GetJadwalByFilm(int filmId)
        {
            DataTable dt = new DataTable();
            // Menggunakan JOIN untuk mendapatkan NamaStudio (lebih informatif)
            string query = @"
                SELECT 
                    J.JadwalID, 
                    S.NamaStudio, 
                    CONCAT(DATE_FORMAT(J.TanggalTayang, '%m/%d/%Y'), ' ', TIME_FORMAT(J.JamMulai, '%H:%i')) AS TanggalWaktu,
                    J.Harga 
                FROM Jadwal J
                JOIN Studio S ON J.StudioID = S.StudioID
                WHERE J.FilmID = @FilmID
                ORDER BY J.TanggalTayang ASC, J.JamMulai ASC";

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
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saat mengambil jadwal film: " + ex.Message);
                        return null;
                    }
                }
            }
        }
        // Di dalam JadwalDAL.cs
        public int GetFilmIDByJadwal(int jadwalId)
        {
            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                string query = "SELECT FilmID FROM Jadwal WHERE JadwalID = @JadwalID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JadwalID", jadwalId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
            }
        }
    }
}
    
