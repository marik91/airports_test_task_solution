using System.Device.Location;
using System.Threading.Tasks;
using Airports.Domain.Commands;
using Airports.Domain.QueryServices;
using Airports.Domain.ValueObjects;

namespace Airports.Domain.CommandHandler
{
    public class AirportsCommandHandler : IAirportsCommandHandler
    {
        private readonly IAirportQueryService _airportQueryService;

        public AirportsCommandHandler(IAirportQueryService airportQueryService)
        {
            _airportQueryService = airportQueryService;
        }

        public async Task<Distance> HandleAsync(CalculateDistanceCommand command)
        {
            var airportA = await _airportQueryService.GetAsync(command.IataA);
            var airportB = await _airportQueryService.GetAsync(command.IataB);

            var geoA = airportA.Coordinates.GetGeoCoordinate();
            var geoB = airportB.Coordinates.GetGeoCoordinate();

            if (OneOfCoordinatesMissing(geoA, geoB))
            {
                return null;
            }

            return new Distance { Meters = geoA.GetDistanceTo(geoB) };
        }

        private bool OneOfCoordinatesMissing(GeoCoordinate geoA, GeoCoordinate geoB)
        {
            return geoA == null || geoB == null;
        }
    }
}