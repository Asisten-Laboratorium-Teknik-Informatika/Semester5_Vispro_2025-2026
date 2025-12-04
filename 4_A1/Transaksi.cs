using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetplanner
{
    public class Transaksi
    {
        public string Jenis { get; set; }
        public string Jumlah { get; set; }
        public DateTime Tanggal { get; set; }
        public string Kategori { get; set; }     // khusus pengeluaran
        public string Deskripsi { get; set; }    // WAJIB ADA!
    }
}
