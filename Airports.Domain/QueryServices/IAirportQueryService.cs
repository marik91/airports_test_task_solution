using System.Collections.Generic;
using System.Threading.Tasks;
using Airports.Domain.Entities;

namespace Airports.Domain.QueryServices
{
    public interface IAirportQueryService
    {
        Task<IEnumerable<Airport>> GetAllEuropeanAirportsAsync();

        Task<IEnumerable<Airport>> GetAirportsAsync(string country);

        Task<Airport> GetAsync(string iata);
    }
}