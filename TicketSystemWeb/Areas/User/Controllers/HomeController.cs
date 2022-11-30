using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models.ViewModels;
using TicketSystemWeb.Models;

namespace TicketSystemWeb.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            RouteSearchVM searchVM = new()
            {
                StationsList = _unitOfWork.Stations.GetAll().Select(
                    i => new SelectListItem()
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
            }; 
                
            return View(searchVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RouteSearchVM obj)
        {
            if (obj.DestinationStationId == obj.OutgoingStationId)
                ModelState.AddModelError("DestinationStationId", "Destination Station cannot be the same as outgoing");
            
            return RedirectToAction("Index", controllerName: "Route", obj);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}