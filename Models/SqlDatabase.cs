using Microsoft.Data.Sqlite;

namespace InsecureWebsite.Models
{
    public static class SqlDatabase
    {
        private const string ConnectionString = "Data Source=users.db";

        public static void Initialize()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = """
                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY,
                    username TEXT NOT NULL,
                    password TEXT NOT NULL
                );
                INSET OR IGNORE INTO users (id, username, password)
                VALUES (1, 'admin', 'passwordpassword123');
            """;
            cmd.ExecuteNonQuery();
        }
        public static SqliteConnection GetConnection()
        {
        var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        return connection;        
        }
    }
}