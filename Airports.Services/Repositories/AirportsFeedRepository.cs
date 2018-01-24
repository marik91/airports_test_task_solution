using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Airports.Services.Models;
using Newtonsoft.Json;

namespace Airports.Services.Repositories
{
    internal static class AirportsFeedRepository
    {
        private static string FeedUrl =>
            "https://raw.githubusercontent.com/jbrooksuk/JSON-Airports/master/airports.json";

        public static async Task<IEnumerable<AirportFeedItem>> GetAllAsync()
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
    }
}