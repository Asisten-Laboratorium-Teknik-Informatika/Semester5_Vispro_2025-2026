using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

// Pastikan file ini berada di namespace yang mudah diakses (misal: CinemaTix.DAL)
namespace CinemaTix.DAL
{
    public static class KoneksiDB
    {
        private static string GetConnectionString()
        {
            // Logika untuk membaca file appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return configuration.GetConnectionString("koneksiDB");
        }

        public static MySqlConnection GetConnection()
        {
            string connString = GetConnectionString();
            // Menggunakan MySqlConnection dari MySql.Data
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}