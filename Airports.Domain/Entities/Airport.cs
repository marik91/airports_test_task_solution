using Airports.Domain.ValueObjects;

namespace Airports.Domain.Entities
{
    public class Airport
    {
        public Coordinates Coordinates { get; set; }

        public string Country { get; set; }

        public string Iata { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public int Status { get; set; }
    }
}