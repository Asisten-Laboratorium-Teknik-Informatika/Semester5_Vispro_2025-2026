using MySql.Data.MySqlClient;

namespace Bioskop
{
    public class Koneksi
    {
        private MySqlConnection conn;

        public Koneksi()
        {
            conn = new MySqlConnection(
                "Server=localhost;" +
                "User ID=root;" +
                "Password=;" +
                "Database=db_bioskop;"
            );
        }

        public MySqlConnection GetConn()
        {
            return conn;
        }
    }
}
