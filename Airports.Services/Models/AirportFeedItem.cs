using Newtonsoft.Json;

namespace Airports.Services.Models
{
    public class AirportFeedItem
    {
        [JsonProperty("continent")]
        public string ContinentCode { get; set; }

        [JsonProperty("iso")]
        public string CountryIsoCode { get; set; }

        [JsonProperty("iata")]
        public string Iata { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lon")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}