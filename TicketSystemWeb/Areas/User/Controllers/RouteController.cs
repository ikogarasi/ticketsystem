using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                RouteSearchVM = obj,
            };

            searchResultVM.RouteSearchVM.OutgoingStation = _unitOfWork.Stations.GetFirstOrDefault(i => i.Id == obj.OutgoingStationId);
            searchResultVM.RouteSearchVM.DestinationStation = _unitOfWork.Stations.GetFirstOrDefault(i => i.Id == obj.DestinationStationId);
            ShortestPathHandler shortestPathLogic = new ShortestPathHandler(_unitOfWork);
            shortestPathLogic.FindShortestRoute(searchResultVM);
            if (searchResultVM.IsRouteFound)
            {
                List<Guid> routeIds = new List<Guid>();
                searchResultVM.Routes.ForEach(route => routeIds.Add(route.Id));
                HttpContext.Session.SetString("Routes", JsonConvert.SerializeObject(routeIds));

            }
            return View(searchResultVM);
        }

        [HttpPost, ActionName("Index")]
        public IActionResult IndexPOST(Guid routeId)
        {
            return Json(new {redirectUrl = Url.Action("Index", "Booking", new { routeId = routeId })});
        }
    }
}
