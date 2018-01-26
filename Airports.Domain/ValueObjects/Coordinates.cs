using System;
using System.Device.Location;

namespace Airports.Domain.ValueObjects
{
    public class Coordinates
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public GeoCoordinate GetGeoCoordinate()
        {
            try
            {
                var latitude = Convert.ToDouble(Latitude.Replace('.', ','));
                var longitude = Convert.ToDouble(Longitude.Replace('.', ','));

                return new GeoCoordinate(latitude, longitude);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}