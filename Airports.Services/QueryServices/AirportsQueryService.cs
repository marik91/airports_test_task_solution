using Airports.Domain.Entities;
using Airports.Domain.QueryServices;
using Airports.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mapper = Airports.Services.Settings.Mapper;

namespace Airports.Services.QueryServices
{
    public class AirportsQueryService : IAirportQueryService
    {
        private readonly IMapper _mapper = Mapper.GetMapper();

        public async Task<IEnumerable<Airport>> GetAllEuropeanAirportsAsync()
        {
            var items = await AirportsFeedRepository.GetAllAsync();
            var europeanItems = items.Where(c => c.ContinentCode.Equals("EU", StringComparison.OrdinalIgnoreCase)
            && c.Type.Equals("Airport", StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<Airport>>(europeanItems);
        }

        public Task<IEnumerable<Airport>> GetAirportsAsync(string country)
        {
            throw new NotImplementedException();
        }

        public Task<Airport> GetAsync(string iata)
        {
            throw new NotImplementedException();
        }
    }
}