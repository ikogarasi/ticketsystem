using Microsoft.AspNetCore.Mvc;
using TicketSystem.DataAccess.Repository.IRepository;

namespace TicketSystemWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoutesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoutesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpGet]
        public IActionResult Upsert(Guid? id)
        {
            
        }

        #region API_CALL
        public IActionResult GetAll()
        {
            var routeList = _unitOfWork.Routes.GetAll();
            return Json(new { data = routeList });
        }
        #endregion
    }
}
