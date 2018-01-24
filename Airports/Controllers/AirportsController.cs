using System.Threading.Tasks;
using System.Web.Mvc;
using Airports.Domain.QueryServices;
using Airports.Models;

namespace Airports.Controllers
{
    public class AirportsController : Controller
    {
        private readonly IAirportQueryService _queryService;

        public AirportsController(IAirportQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var viewModel = new AirportsViewModel(
                await _queryService.GetAllEuropeanAirportsAsync());

            return View(viewModel);
        }

        // 2.5h
        // DropdownFor
        [HttpPost]
        public ActionResult Filter(string country)
        {
            return RedirectToAction("Index");
        }
    }
}