using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airports.Domain.QueryServices;
using Airports.Services.Repositories;
using Airports.Services.Settings;

namespace Airports.Services.QueryServices
{
    public class CountryQueryService : ICountryQueryService
    {
        private readonly AirportsFeedRepository _feedRepository;

        public CountryQueryService(AirportsFeedRepository feedRepository)
        {
            _feedRepository = feedRepository;
        }

        public async Task<IEnumerable<string>> GetAllCountriesAsync()
        {
            var items = await _feedRepository.GetEuropeanAirportsAsync();
            var countryCodes = items.Select(c => c.CountryIsoCode).Distinct();
            var countries = countryCodes.Select(CountryMap.GetCountry).ToList();
            countries.Sort();

            return countries;
        }
    }
}