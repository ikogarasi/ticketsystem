using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models;
using TicketSystem.Models.ViewModels;

namespace TicketSystemWeb.Areas.User.Controllers
{
    [Area("user")]
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index(Guid routeId)
        {
            PassBookingVM passBookingVM = new()
            {
                BoardPass = new(),
                RouteId = routeId,
                Route = _unitOfWork.Routes.GetFirstOrDefault(i => i.Id == routeId)
            };

            TempData["route"] = routeId;
            return View(passBookingVM);
        }

        [HttpPost, ActionName("Index")]
        public IActionResult IndexPOST(PassBookingVM obj)
        {
            var user = _unitOfWork.Users.GetFirstOrDefault(i => User.Identity.Name == i.UserName);
            BoardingPassModel boardingPassModel = obj.BoardPass;
            boardingPassModel.UserId = user.Id;
            boardingPassModel.RouteId = Guid.Parse(TempData["route"].ToString());
            _unitOfWork.BoardingPasses.Add(boardingPassModel);
            _unitOfWork.Save();
            List<Guid> routesGuids = JsonConvert.DeserializeObject<List<Guid>>(HttpContext.Session.GetString("Routes"));
            routesGuids.Remove(obj.RouteId);
            HttpContext.Session.SetString("Routes", JsonConvert.SerializeObject(routesGuids));
            
            if (routesGuids.Count > 0)
                return RedirectToAction("Index", "Route");

            return RedirectToAction("Index", "Home");
        }
    }
}
