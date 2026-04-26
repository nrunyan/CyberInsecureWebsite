using Microsoft.Data.Sqlite;

namespace InsecureWebsite.Models
{
    public static class SqlDatabase
    {
        private const string FactsDb = "Data Source = facts.db";
        private const string TimeDb = "Data Source = time.db";

        public static void Initialize()
        {
            // Database 1: The random fact database
            using var factsConn = new SqliteConnection(FactsDb);
            factsConn.Open();
            var factsCmd = factsConn.CreateCommand();
            factsCmd.CommandText = """
            CREATE TABLE IF NOT EXISTS movies (
                id INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                rating REAL NOT NULL,
                budget INTEGER NOT NULL,
                release INTEGER NOT NULL
            );
            CREATE TABLE IF NOT EXISTS countries (
                id INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                gdp INTEGER NOT NULL,
                year INTEGER NOT NULL
            );
            """;
            factsCmd.ExecuteNonQuery();
            MovieCsvUpload(factsConn, "movies.csv");
            
            // CountryCsvUpload(factsConn, "country.csv");

            // // Database 2: TERRORISM
            // using var timeConn = new SqliteConnection(TimeDb);
            // timeConn.Open();
            // var timeCmd = timeConn.CreateCommand();
            // timeCmd.CommandText = "";
            // timeCmd.ExecuteNonQuery();
        }

        public static SqliteConnection GetFactsConnection()
        {
            var connection = new SqliteConnection(FactsDb);
            connection.Open();
            return connection;        
        }

        public static SqliteConnection GetTimeConnection()
        {
            var connection = new SqliteConnection(TimeDb);
            connection.Open();
            return connection;
        }

        private static void MovieCsvUpload(SqliteConnection connection, string path)
        {
            foreach (var line in File.ReadAllLines(path).Skip(1))
            {
                var parts = line.Split(",");
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT OR IGNORE INTO movies (name, rating, budget, release) VALUES ($name, $rating, $budget, $release)";
                cmd.Parameters.AddWithValue("$name", parts[0].Trim());
                cmd.Parameters.AddWithValue("$rating", double.Parse(parts[1].Trim()));
                cmd.Parameters.AddWithValue("$budget", long.Parse(parts[2].Trim()));
                cmd.Parameters.AddWithValue("$release", int.Parse(parts[3].Trim()));
                cmd.ExecuteNonQuery();
            }
        }

        private static void CountryCsvUpload(SqliteConnection connection, string path)
        {
            foreach (var line in File.ReadAllLines(path).Skip(1))
            {
                var parts = line.Split(",");
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT OR IGNORE INTO countries (name, gdp, year) VALUES ($name, $gdp, $year)";
                cmd.Parameters.AddWithValue("$name", parts[0].Trim());
                cmd.Parameters.AddWithValue("$gdp", int.Parse(parts[1].Trim()));
                cmd.Parameters.AddWithValue("$year", int.Parse(parts[2].Trim()));
                cmd.ExecuteNonQuery();
            }
        }
    }
}