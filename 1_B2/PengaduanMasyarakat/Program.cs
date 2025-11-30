using System;
using System.Windows.Forms;
using PengaduanMasyarakat.Forms;
using PengaduanMasyarakat.Utils;

namespace PengaduanMasyarakat
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test koneksi database
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Tidak dapat terhubung ke database!\n\nPastikan:\n1. XAMPP sudah berjalan\n2. MySQL service aktif\n3. Database 'pengaduan_masyarakat' sudah dibuat",
                    "Error Koneksi Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FormLogin());
        }
    }
}