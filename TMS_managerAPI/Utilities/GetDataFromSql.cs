using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace TMS_managerAPI.Utilities
{
    public static class GetDataFromSql
    {
        public static class SqlQueryExecutor<T>
        {
            private static readonly string _configFilePath = "sqlConfig.json";
            private static readonly Dictionary<string, string> _sqlQueries;

            static SqlQueryExecutor()
            {
                // Load SQL queries from the config file
                _sqlQueries = LoadSqlQueries();
            }

            private static Dictionary<string, string> LoadSqlQueries()
            {
                string jsonContent = File.ReadAllText(_configFilePath);
                return JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
            }

            public static List<T> ExecuteQuery(string queryKey, Func<IDataRecord, SharedData.Result.AverageTurnAroundTimePerDriverResult> mapToAverageTurnAroundTimePerDriverResult)
            {
                // Check if the query key exists
                if (!_sqlQueries.ContainsKey(queryKey))
                {
                    throw new ArgumentException($"Query key '{queryKey}' does not exist in the configuration.");
                }

                string queryString = _sqlQueries[queryKey];

                // Execute the SQL query and map the results
                return ExecuteAndMap(queryString);
            }

            private static List<T> ExecuteAndMap(string queryString)
            {
                List<T> results = new List<T>();

                string connString = "your_connection_string_here";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                T mappedResult = MapResult(reader);
                                results.Add(mappedResult);
                            }
                        }
                    }
                }

                return results;
            }

            private static T MapResult(SqlDataReader reader)
            {
                // Implement your mapping logic here
                // Example: return new T { Property1 = reader.GetString(0), Property2 = reader.GetInt32(1), ... };
                throw new NotImplementedException();
            }
        }
    }
}
