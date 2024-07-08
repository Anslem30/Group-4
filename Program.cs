
// Models/Country.cs
using PopulationReports.Reports;
using PopulationReports.Services;

namespace PopulationReports.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=world;User ID=root;Password=yourpassword;";


            var countryService = new CountryService(connectionString);
            var reportGenerator = new ReportGenerator(countryService);

            // Generate the report for all countries
            reportGenerator.GenerateCountryReport();
        }
    }
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public int Population { get; set; }
        public string Capital { get; set; }
    }
}

// Models/City.cs
namespace PopulationReports.Models
{
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public int Population { get; set; }
    }
}

// Models/CapitalCity.cs
namespace PopulationReports.Models
{
    public class CapitalCity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
    }
}
