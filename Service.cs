using MySql.Data.MySqlClient;
using PopulationReports.Models;

namespace PopulationReports.Services
{
    public class CountryService
        {
            private readonly string _connectionString;

            public CountryService(string connectionString)
            {
                _connectionString = connectionString;
            }

            public List<Country> GetAllCountries()
            {
                List<Country> countries = new List<Country>();
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var cmd = new MySqlCommand("SELECT Code, Name, Continent, Region, Population, Capital FROM country ORDER BY Population DESC", connection);
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        countries.Add(new Country
                        {
                            Code = reader.GetString(0),
                            Name = reader.GetString(1),
                            Continent = reader.GetString(2),
                            Region = reader.GetString(3),
                            Population = reader.GetInt32(4),
                            Capital = reader.IsDBNull(5) ? null : reader.GetString(5)
                        });
                    }
                }
                return countries;
            }

        // Additional methods for other reports will be implemented similarly
        // Services/CountryService.cs (Add methods to get countries by continent, region, etc.)
        public List<Country> GetCountriesByContinent(string continent)
        {
            List<Country> countries = new List<Country>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                var cmd = new MySqlCommand($"SELECT Code, Name, Continent, Region, Population, Capital FROM country WHERE Continent = @continent ORDER BY Population DESC", connection);
                cmd.Parameters.AddWithValue("@continent", continent);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new Country
                    {
                        Code = reader.GetString(0),
                        Name = reader.GetString(1),
                        Continent = reader.GetString(2),
                        Region = reader.GetString(3),
                        Population = reader.GetInt32(4),
                        Capital = reader.IsDBNull(5) ? null : reader.GetString(5)
                    });
                }
            }
            return countries;
        }

        // Similar methods can be added for regions, cities, and other reports

    }
}

