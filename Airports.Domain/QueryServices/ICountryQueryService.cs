using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airports.Domain.QueryServices
{
    public interface ICountryQueryService
    {
        Task<IEnumerable<string>> GetAllCountriesAsync();
    }
}