using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airports.Domain.Entities;
using Airports.Domain.QueryServices;
using Airports.Services.Repositories;
using Airports.Services.Settings;
using AutoMapper;
using Mapper = Airports.Services.Settings.Mapper;

namespace Airports.Services.QueryServices
{
    public class AirportsQueryService : IAirportQueryService
    {
        private readonly AirportsFeedRepository _feedRepository;
        private readonly IMapper _mapper = Mapper.GetMapper();

        public AirportsQueryService(AirportsFeedRepository feedRepository)
        {
            _feedRepository = feedRepository;
        }

        public async Task<IEnumerable<Airport>> GetAllEuropeanAirportsAsync()
        {
            var airportFeedItems = await _feedRepository.GetEuropeanAirportsAsync();
            var airports = _mapper.Map<IEnumerable<Airport>>(airportFeedItems).ToList();
            SortAirports(airports);

            return airports;
        }

        public async Task<IEnumerable<Airport>> GetAllEuropeanAirportsAsyncByCountry(string country)
        {
            var airportFeedItems = await _feedRepository.GetEuropeanAirportsAsync();
            airportFeedItems = airportFeedItems.Where(
                c => c.CountryIsoCode.Equals(CountryMap.GetCountryCode(country), StringComparison.OrdinalIgnoreCase));

            var airports = _mapper.Map<IEnumerable<Airport>>(airportFeedItems).ToList();
            SortAirports(airports);

            return airports;
        }

        public async Task<Airport> GetAsync(string iata)
        {
            var airports = await _feedRepository.GetEuropeanAirportsAsync();
            var airport = airports.FirstOrDefault(a => a.Iata.Equals(iata, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<Airport>(airport);
        }

        private void SortAirports(List<Airport> airports)
        {
            airports.Sort((x, y) => string.Compare(x.Country, y.Country, StringComparison.OrdinalIgnoreCase));
        }
    }
}