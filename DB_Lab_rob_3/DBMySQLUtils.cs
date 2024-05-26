using MySql.Data.MySqlClient;

namespace ConsoleApp4
{
    class DBMySQLUtils
    {
        public static MySqlConnection
            GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server = " + host + ";Database = " + database +
                ";port = " + port + ";User id = " + username + ";password = " + password;
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
