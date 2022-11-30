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
        public IActionResult Index()
        {
            PassBookingVM passBookingVM = new()
            {
                RoutesId = JsonConvert.DeserializeObject<List<Guid>>(TempData["Routes"].ToString()),
                BoardPass = new(),
                SumPrice = Convert.ToDouble(TempData["SumPrice"])
            };
            TempData.Keep("SumPrice");
            TempData.Keep("Routes");

            passBookingVM.Routes = _unitOfWork.Routes.GetRoutesFromId(passBookingVM.RoutesId).ToList();

            return View(passBookingVM);
        }

        [HttpPost, ActionName("Index")]
        public IActionResult IndexPOST(PassBookingVM obj)
        {
            obj.RoutesId = JsonConvert.DeserializeObject<List<Guid>>(TempData["Routes"].ToString());
            obj.SumPrice = Convert.ToDouble(TempData["SumPrice"]);
            var user = _unitOfWork.Users.GetFirstOrDefault(i => User.Identity.Name == i.UserName);
            BoardingPassModel boardingPassModel = obj.BoardPass;
            boardingPassModel.UserId = user.Id;
            for (int i = 0; i < obj.RoutesId.Count; ++i)
            {
                boardingPassModel.RouteId = obj.RoutesId[i];
                _unitOfWork.BoardingPasses.Add(boardingPassModel);
                _unitOfWork.Save();
                boardingPassModel.Id = Guid.NewGuid();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
