using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models;
using TicketSystem.Utility;

namespace TicketSystemWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BoardingPassesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BoardingPassesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetAll()
        {
            var passesList = _unitOfWork.BoardingPasses.GetAll(includeProperties: "Route,UserModel");
            foreach (var each in passesList)
            {
                each.SeatString = Enum.GetName(typeof(SittingPlace), each.Seat);
                each.GenderString = Enum.GetName(typeof(Gender), each.PassengerGender);
            }
            return Json(new { data = passesList });
        }
    }
}
