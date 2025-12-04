using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamarKos.Koneksi
{
    internal class KoneksiDatabase
    {
        public MySqlConnection GetConn()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "server=localhost;user id=root;password=;database=db_kos;";
            return conn;
        }
    }
}
