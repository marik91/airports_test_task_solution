using Airports.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Airports.Models
{
    public class AirportsViewModel
    {
       
        public AirportsViewModel(IEnumerable<Airport> airports)
        {
            Airports = airports;

            var distinctCountries = airports.Select(a => a.Country).Distinct();
            Countries = distinctCountries.Select(c => new SelectListItem { Text = c, Value = c });
        }

        public IEnumerable<Airport> Airports { get; }

        public IEnumerable<SelectListItem> Countries { get; }

        public string CountryFilterValue { get; set; }
    }
}