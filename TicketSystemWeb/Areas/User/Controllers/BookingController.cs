using Microsoft.AspNetCore.Mvc;
using TicketSystem.DataAccess.Repository.IRepository;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}
