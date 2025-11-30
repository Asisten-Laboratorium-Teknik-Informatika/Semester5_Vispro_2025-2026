using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTix.Models
{
    // Tambahkan di bawah FormPilihJadwal class atau di file Models/JadwalDisplay.cs
    public class JadwalDisplay
    {
        public int JadwalID { get; set; }
        public string DisplayText { get; set; }
        public string NamaStudio { get; set; }
        // Anda juga bisa menambahkan Harga di sini jika diperlukan
    }
}
