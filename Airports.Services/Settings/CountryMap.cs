using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Airports.Services.Settings
{
    internal static class CountryMap
    {
        private static IEnumerable<Country> _countriesList;

        public static string GetCountry(string countryCode)
        {
            if (_countriesList == null)
            {
                SetupList();
            }

            var country =
                _countriesList?.FirstOrDefault(c => c.Code.Equals(countryCode, StringComparison.OrdinalIgnoreCase));

            return country?.Name ?? countryCode;
        }

        public static string GetCountryCode(string country)
        {
            if (_countriesList == null)
            {
                SetupList();
            }

            var countryCode =
                _countriesList?.FirstOrDefault(c => c.Name.Equals(country, StringComparison.OrdinalIgnoreCase))?.Code;

            return countryCode;
        }

        private static void SetupList()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Airports.Services.Settings.countries.json";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    _countriesList = new List<Country>();
                }
                else
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var countriesJson = reader.ReadToEndAsync().Result;

                        _countriesList = JsonConvert.DeserializeObject<IEnumerable<Country>>(countriesJson);
                    }
                }
            }
        }

        private class Country
        {
            [JsonProperty("alpha-2")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}