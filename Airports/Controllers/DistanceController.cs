using System.Collections.Generic;
using Airports.Domain.CommandHandler;
using Airports.Domain.Commands;
using Airports.Domain.QueryServices;
using Airports.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Airports.Domain.ValueObjects;

namespace Airports.Controllers
{
    public class DistanceController : Controller
    {
        private readonly IAirportQueryService _airportQueryService;
        private readonly IAirportsCommandHandler _airportsCommandHandler;

        public DistanceController(IAirportQueryService airportQueryService, IAirportsCommandHandler airportsCommandHandler)
        {
            _airportQueryService = airportQueryService;
            _airportsCommandHandler = airportsCommandHandler;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var airports = await _airportQueryService.GetAllEuropeanAirportsAsync();
            var iatas = airports.Select(a => a.Iata);
            var viewModel = new DistanceViewModel(iatas);

            if (TempData["error"] is string error)
            {
                SetSelectedAirports(viewModel);
                viewModel.Error = error;
            }
            else if (TempData["distance"] is Distance distance)
            {
                SetSelectedAirports(viewModel);
                viewModel.Distance = distance;
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Calculate(string airportA, string airportB)
        {
            var distance = await _airportsCommandHandler.HandleAsync(
                    new CalculateDistanceCommand { IataA = airportA, IataB = airportB });

            TempData["airportA"] = airportA;
            TempData["airportB"] = airportB;

            if (distance == null)
            {
                TempData["error"] = "Missing some of airport coordinates.";
            }
            else
            {
                TempData["distance"] = distance;
            }

            return RedirectToAction("Index");
        }

        private void SetSelectedAirports(DistanceViewModel viewModel)
        {
            var airportA = TempData["airportA"] as string;
            var airportB = TempData["airportB"] as string;

            SetSelectedValue(viewModel.IataListA, airportA);
            SetSelectedValue(viewModel.IataListB, airportB);
        }

        private void SetSelectedValue(List<SelectListItem> selectList, string value)
        {
            var filter = selectList.FirstOrDefault(c => c.Value.Equals(value));

            if (filter != null)
            {
                filter.Selected = true;
            }
        }
    }
}