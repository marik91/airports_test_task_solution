using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Airports.Services.Models;
using Newtonsoft.Json;

namespace Airports.Services.Repositories
{
    public class AirportsFeedRepository
    {
        private static IEnumerable<AirportFeedItem> _airports;
        private static DateTime _lastSyncDateTime = new DateTime(2018, 1, 26, 18, 47, 00);

        private readonly HttpResponseBase _response;

        public AirportsFeedRepository(HttpResponseBase response)
        {
            // feels like a bit hacky way to setup header, but it is most nice way I come up with
            _response = response;
        }

        private static string FeedUrl =>
            "https://raw.githubusercontent.com/jbrooksuk/JSON-Airports/master/airports.json";

        public async Task<IEnumerable<AirportFeedItem>> GetEuropeanAirportsAsync()
        {
            if (FiveMinutesPassedAfterLastSync())
            {
                await SyncFeed();
            }

            return _airports;
        }

        private static bool FiveMinutesPassedAfterLastSync()
        {
            return (DateTime.Now - _lastSyncDateTime).TotalMinutes > 5;
        }

        private static async Task<IEnumerable<AirportFeedItem>> GetAllAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(FeedUrl);

                if (!result.IsSuccessStatusCode)
                {
                    return null;
                }

                var responseContent = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<AirportFeedItem>>(responseContent);
            }
        }

        private async Task SyncFeed()
        {
            var airports = await GetAllAsync();
            _airports = airports.Where(
                c => c.ContinentCode.Equals("EU", StringComparison.OrdinalIgnoreCase)
                    && c.Type.Equals("Airport", StringComparison.OrdinalIgnoreCase));

            _response.Headers.Add("from-feed", "from-feed");

            _lastSyncDateTime = DateTime.Now;
        }
    }
}