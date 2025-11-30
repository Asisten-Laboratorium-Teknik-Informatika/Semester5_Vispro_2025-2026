using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTix.Models
{
    public class KursiDetail
    {
        public int KursiID { get; set; }
        public string Baris { get; set; }
        public int Nomor { get; set; }
        public string StatusKursi { get; set; } // 'Tersedia', 'Terisi'
        public bool IsSelected { get; set; } // Status untuk aplikasi (user sedang memilih)
    }
}