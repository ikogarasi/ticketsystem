using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models;
using TicketSystem.Models.ViewModels;

namespace TicketSystemWeb.Areas.User.Controllers
{
    [Area("user")]
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly UserManager<UserModel> _userManager;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_userManager = userManager;
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
            BoardingPassModel boardingPassModel = obj.BoardPass;
            boardingPassModel.UserId = User.FindFirstValue("");

            return RedirectToAction("Index", "Home");
        }
        
    }
}
