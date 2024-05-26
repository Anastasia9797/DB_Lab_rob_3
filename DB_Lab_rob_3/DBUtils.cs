using MySql.Data.MySqlClient;

namespace ConsoleApp4
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "lab_rob1";
            string username = "monty";
            string password = "some_password1";
            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
