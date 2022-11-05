using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models.ViewModels;

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

        [HttpGet]
        public IActionResult Upsert(Guid? id)
        {
            RouteVM routeVM = new()
            {
                Route = new(),
                StationsList = _unitOfWork.Stations.GetAll().Select(
                    i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
            };

            if (id == null || id == Guid.Empty)
            {
                return View(routeVM);
            }

            routeVM.Route = _unitOfWork.Routes.GetFirstOrDefault(i => i.Id == id);
            return View(routeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RouteVM obj)
        {
            if (obj.Route.DestinationStationId == obj.Route.OutgoingStationId)
                ModelState.AddModelError("DestinationStationId", "Destination Station cannot be the same as outgoing");
            
            if (ModelState.IsValid)
            {

                if (obj.Route.Id == Guid.Empty)
                {
                    obj.Route.Id = Guid.NewGuid();
                    _unitOfWork.Routes.Add(obj.Route);
                    TempData["success"] = "Route successfully added";
                }
                else
                {
                    _unitOfWork.Routes.Update(obj.Route);
                    TempData["success"] = "Route successfully updated";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }

        #region API_CALL
        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return Json(new { success = false, message = "Id cannot equal null" });

            var obj = _unitOfWork.Routes.GetFirstOrDefault(i => i.Id == id);
            if (obj == null)
                return Json(new { success = false, message = "Error while deleting" });

            _unitOfWork.Routes.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Route successfully deleted" });
        }

        public IActionResult GetAll()
        {
            var routeList = _unitOfWork.Routes.GetAll(includeProperties:"OutgoingStation,DestinationStation");
            return Json(new { data = routeList });
        }
        #endregion
    }
}
