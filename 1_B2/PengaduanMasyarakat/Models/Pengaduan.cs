using System;

namespace PengaduanMasyarakat.Models
{
    public class Pengaduan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NamaPelapor { get; set; }
        public string NomorTelepon { get; set; }
        public string LokasiKejadian { get; set; }
        public string JenisKejadian { get; set; }
        public string Deskripsi { get; set; }
        public string FotoPath { get; set; }
        public string Status { get; set; }
        public DateTime TanggalLaporan { get; set; }
        public DateTime TanggalUpdate { get; set; }
    }
}