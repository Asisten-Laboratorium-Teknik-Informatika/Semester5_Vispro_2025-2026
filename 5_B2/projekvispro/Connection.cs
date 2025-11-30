using MySql.Data.MySqlClient;

public class Connection
{
    private string connectionString =
        "Server=localhost;Database=database_kasir;Uid=root;Pwd=;";

    public MySqlConnection GetConn()
    {
        // SELALU buat koneksi baru
        return new MySqlConnection(connectionString);
    }
}




