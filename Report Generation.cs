using PopulationReports.Services;
using System;

namespace PopulationReports.Reports
{
    public class ReportGenerator
    {
        private readonly CountryService _countryService;

        public ReportGenerator(CountryService countryService)
        {
            _countryService = countryService;
        }

        public void GenerateCountryReport()
        {
            var countries = _countryService.GetAllCountries();
            Console.WriteLine("Code\tName\tContinent\tRegion\tPopulation\tCapital");
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Code}\t{country.Name}\t{country.Continent}\t{country.Region}\t{country.Population}\t{country.Capital}");
            }
        }
        // Reports/ReportGenerator.cs (Add methods to generate reports by continent, region, etc.)
        public void GenerateCountryReportByContinent(string continent)
        {
            var countries = _countryService.GetCountriesByContinent(continent);
            Console.WriteLine("Code\tName\tContinent\tRegion\tPopulation\tCapital");
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Code}\t{country.Name}\t{country.Continent}\t{country.Region}\t{country.Population}\t{country.Capital}");
            }
        }

        // Similar methods can be added for regions, cities, and other reports

    }
}

