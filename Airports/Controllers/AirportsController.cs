using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Airports.Domain.QueryServices;
using Airports.Models;

namespace Airports.Controllers
{
    public class AirportsController : Controller
    {
        private readonly IAirportQueryService _airportQueryService;
        private readonly ICountryQueryService _countryQueryService;

        public AirportsController(IAirportQueryService airportQueryService, ICountryQueryService countryQueryService)
        {
            _airportQueryService = airportQueryService;
            _countryQueryService = countryQueryService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var viewModel = new AirportsViewModel(await _countryQueryService.GetAllCountriesAsync());

            if (TempData["country"] is string country)
            {
                TempData["country"] = country;
                viewModel.Airports.AddRange(await _airportQueryService.GetAllEuropeanAirportsAsyncByCountry(country));
                var filter = viewModel.Countries.FirstOrDefault(c => c.Value.Equals(country));

                if (filter != null)
                {
                    filter.Selected = true;
                }
            }
            else
            {
                viewModel.Airports.AddRange(await _airportQueryService.GetAllEuropeanAirportsAsync());
            }

            return View(viewModel);
        }

        // 2.5h
        // DropdownFor
        [HttpPost]
        public ActionResult Filter(string country)
        {
            if (country.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                country = null;
            }

            TempData["country"] = country;

            return RedirectToAction("Index");
        }
    }
}