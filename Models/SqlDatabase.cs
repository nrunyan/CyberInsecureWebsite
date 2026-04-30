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
            CREATE TABLE IF NOT EXISTS unreleased (
                id INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                rating REAL NOT NULL,
                budget INTEGER NOT NULL,
                release INTEGER NOT NULL
            );
            """;
            factsCmd.ExecuteNonQuery();
            MovieCsvUpload(factsConn, "Data/movies.csv");
            SeedUnreleased(factsConn);

            // Database 2: TERRORISM
            using var timeConn = new SqliteConnection(TimeDb);
            timeConn.Open();
            var timeCmd = timeConn.CreateCommand();
            timeCmd.CommandText = """
            CREATE TABLE IF NOT EXISTS countries (
                id INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                code TEXT NOT NULL,
                future_gdp INTEGER NOT NULL,
                future_population INTEGER NOT NULL
            );
            CREATE TABLE IF NOT EXISTS extinct (
                id INTEGER PRIMARY KEY,
                name TEXT NOT NULL,
                cause TEXT NOT NULL
            );
            """;
            timeCmd.ExecuteNonQuery();
            CountryCsvUpload(timeConn, "Data/countries.csv");
            ExtinctCsvUpload(timeConn, "Data/extinct.csv");

            // Database 3: idk
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

        private static void SeedUnreleased(SqliteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT OR IGNORE INTO unreleased (id, name, rating, budget, release) VALUES (1, 'The Matrix 5-tastic and Furious', 9.9, 3500000000, 2036)";
            cmd.ExecuteNonQuery();
        }

        private static void CountryCsvUpload(SqliteConnection connection, string path)
        {
            foreach (var line in File.ReadAllLines(path).Skip(1))
            {
                var parts = line.Split(",");
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT OR IGNORE INTO countries (name, code, future_gdp, future_population) VALUES ($name, $code, $future_gdp, $future_population)";
                cmd.Parameters.AddWithValue("$name", parts[0].Trim());
                cmd.Parameters.AddWithValue("$code", parts[1].Trim());
                cmd.Parameters.AddWithValue("$future_gdp", long.Parse(parts[2].Trim()));
                cmd.Parameters.AddWithValue("$future_population", long.Parse(parts[3].Trim()));
                cmd.ExecuteNonQuery();
            }
        }

        private static void ExtinctCsvUpload(SqliteConnection connection, string path)
        {
            foreach (var line in File.ReadAllLines(path).Skip(1))
            {
                var parts = line.Split(",");
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT OR IGNORE INTO extinct (name, cause) VALUES ($name, $cause)";
                cmd.Parameters.AddWithValue("$name", parts[0].Trim());
                cmd.Parameters.AddWithValue("$cause", parts[1].Trim());
            }
        }
        
    }
}