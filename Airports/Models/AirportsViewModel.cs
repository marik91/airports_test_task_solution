using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Airports.Domain.Entities;

namespace Airports.Models
{
    public class AirportsViewModel
    {
        public AirportsViewModel(IEnumerable<string> cities)
        {
            Countries.Add(new SelectListItem { Text = "All", Value = "All" });
            Countries.AddRange(cities.Select(c => new SelectListItem { Text = c, Value = c }));
        }

        public List<Airport> Airports { get; } = new List<Airport>();

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>();
    }
}