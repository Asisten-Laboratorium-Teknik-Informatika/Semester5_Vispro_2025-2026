using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTix.DAL;
using MySql.Data.MySqlClient;
using CinemaTix.Models;
using System.Windows.Forms;

namespace CinemaTix
{
    public class KursiDAL
    {
        public List<KursiDetail> GetStatusKursiByJadwal(int jadwalId)
        {
            List<KursiDetail> listKursi = new List<KursiDetail>();

            // Query untuk mendapatkan semua kursi di studio yang terkait dengan jadwal,
            // dan menentukan statusnya apakah sudah terisi berdasarkan DetailPemesanan.
            // Kita perlu StudioID dari tabel Jadwal terlebih dahulu.
            string query = @"
                SELECT 
                    K.KursiID, 
                    K.Baris, 
                    K.NomorKursi, 
                    CASE
                        WHEN DP.KursiID IS NOT NULL THEN 'Terisi'
                        ELSE K.Status 
                    END AS StatusKursi
                FROM Jadwal J
                JOIN Studio S ON J.StudioID = S.StudioID
                JOIN Kursi K ON K.StudioID = S.StudioID
                LEFT JOIN DetailPemesanan DP ON DP.KursiID = K.KursiID AND DP.JadwalID = J.JadwalID
                WHERE J.JadwalID = @JadwalID
                ORDER BY K.Baris, K.NomorKursi";

            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JadwalID", jadwalId);
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listKursi.Add(new KursiDetail
                                {
                                    KursiID = reader.GetInt32("KursiID"),
                                    Baris = reader.GetString("Baris"),
                                    Nomor = reader.GetInt32("NomorKursi"),
                                    StatusKursi = reader.GetString("StatusKursi"),
                                });
                            }
                        }
                        return listKursi;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saat mengambil status kursi: " + ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}
