using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Airports.Domain.ValueObjects;

namespace Airports.Models
{
    public class DistanceViewModel
    {
        public DistanceViewModel(IEnumerable<string> iataList)
        {
            IataListA.AddRange(iataList.Select(i => new SelectListItem { Text = i, Value = i }));
            IataListB.AddRange(iataList.Select(i => new SelectListItem { Text = i, Value = i }));
        }

        public List<SelectListItem> IataListA { get; } = new List<SelectListItem>();

        public List<SelectListItem> IataListB { get; } = new List<SelectListItem>();

        public Distance Distance { get; set; }

        public string Error { get; set; }
    }
}