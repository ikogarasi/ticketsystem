using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text.Json;
using TicketSystem.BusinessLogic;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models.ViewModels;

namespace TicketSystemWeb.Areas.User.Controllers
{
    [Area("user")]
    public class RouteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index(RouteSearchVM obj)
        {
            SearchResultVM searchResultVM = new()
            {
                RouteSearchVM = obj
            };

            searchResultVM.RouteSearchVM.OutgoingStation = _unitOfWork.Stations.GetFirstOrDefault(i => i.Id == obj.OutgoingStationId);
            searchResultVM.RouteSearchVM.DestinationStation = _unitOfWork.Stations.GetFirstOrDefault(i => i.Id == obj.DestinationStationId);

            ShortestPathHandler shortestPathLogic = new ShortestPathHandler(_unitOfWork);
            shortestPathLogic.FindShortestRoute(searchResultVM);

            return View(searchResultVM);
        }

        [HttpPost]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Booking");
        }
    }
}
