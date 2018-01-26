namespace Airports.Domain.ValueObjects
{
    public class Distance
    {
        public double Kilometers => Meters / 1000;

        public double Meters { get; set; }
    }
}