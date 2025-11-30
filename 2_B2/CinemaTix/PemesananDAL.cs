using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTix.DAL;
using CinemaTix.Models;
using MySql.Data.MySqlClient;

namespace CinemaTix
{
    public class PemesananDAL
    {
        public bool SimpanTransaksi(int jadwalID, string namaPemesan, int totalHarga, List<KursiDetail> kursiTerpilih)
        {
            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert ke Tabel Pemesanan (Header)
                    string queryHeader = @"INSERT INTO Pemesanan (JadwalID, NamaPemesan, TotalHarga, TanggalPesan) 
                                           VALUES (@JadwalID, @NamaPemesan, @TotalHarga, NOW()); 
                                           SELECT LAST_INSERT_ID();";

                    int pemesananID = 0;
                    using (MySqlCommand cmdHeader = new MySqlCommand(queryHeader, conn, transaction))
                    {
                        cmdHeader.Parameters.AddWithValue("@JadwalID", jadwalID);
                        cmdHeader.Parameters.AddWithValue("@NamaPemesan", namaPemesan);
                        cmdHeader.Parameters.AddWithValue("@TotalHarga", totalHarga);

                        // Dapatkan ID Transaksi yang baru dibuat
                        pemesananID = Convert.ToInt32(cmdHeader.ExecuteScalar());
                    }

                    // 2. Insert ke Tabel DetailPemesanan (Untuk setiap kursi)
                    string queryDetail = @"INSERT INTO DetailPemesanan (KursiID, JadwalID, PemesananID) 
                                           VALUES (@KursiID, @JadwalID, @PemesananID)";

                    foreach (var kursi in kursiTerpilih)
                    {
                        using (MySqlCommand cmdDetail = new MySqlCommand(queryDetail, conn, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@KursiID", kursi.KursiID);
                            cmdDetail.Parameters.AddWithValue("@JadwalID", jadwalID);
                            cmdDetail.Parameters.AddWithValue("@PemesananID", pemesananID);
                            cmdDetail.ExecuteNonQuery();
                        }
                    }

                    // Jika semua berhasil, simpan permanen
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Jika ada error, batalkan semua perubahan
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public DataTable GetRiwayatByUser(string username)
        {
            DataTable dt = new DataTable();

            // Query ini menggabungkan tabel Pemesanan -> Jadwal -> Film -> Studio
            // Agar kita bisa melihat Judul Film dan Nama Studio, bukan cuma ID-nya.
            string query = @"
        SELECT 
            P.PemesananID,
            P.TanggalPesan,
            F.Judul AS 'Films',
            S.NamaStudio AS 'Studio',
            J.TanggalTayang,
            J.JamMulai,
            P.TotalHarga
        FROM Pemesanan P
        JOIN Jadwal J ON P.JadwalID = J.JadwalID
        JOIN Films F ON J.FilmID = F.FilmID
        JOIN Studio S ON J.StudioID = S.StudioID
        WHERE P.NamaPemesan = @Username
        ORDER BY P.TanggalPesan DESC"; // Urutkan dari yang terbaru

            using (MySqlConnection conn = KoneksiDB.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    try
                    {
                        conn.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal mengambil histori: " + ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}
