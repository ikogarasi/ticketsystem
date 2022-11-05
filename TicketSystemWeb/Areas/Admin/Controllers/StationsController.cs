using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models;

namespace TicketSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API_CALL
        [HttpPost]

        public IActionResult Create(string stationName)
        {
            if (_unitOfWork.Stations.GetFirstOrDefault(i => i.Name == stationName) != null)
            {
                return Json(new { success = false, message = $"{stationName} station already exist" });
            }

            _unitOfWork.Stations.Add(new StationModel { Id = Guid.NewGuid(), Name = stationName }); ; ;
            _unitOfWork.Save();
            return Json(new { success = true, message = "Successfully created" });
        }


        [HttpPut]
        public IActionResult Edit(Guid id, string name)
        {
            if (_unitOfWork.Stations.Contains(name))
                return Json(new { success = false, message = $"{name} station already exist" });

            _unitOfWork.Stations.Update(new StationModel { Id = id, Name = name });
            _unitOfWork.Save();
            return Json(new { success = true, message = "Successfully updated" });
        }

        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            var stationFromDb = _unitOfWork.Stations.GetFirstOrDefault(i => i.Id == id);
            if (stationFromDb == null)
                return Json(new { success = false, message = "Not Found" });

            _unitOfWork.Stations.Remove(stationFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Successfully removed" });
            
        }
        
        [HttpGet]
        public IActionResult GetStation(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return Json(new { success = false, message = "Id cannot equal null" });

            var stationFromDb = _unitOfWork.Stations.GetFirstOrDefault(i => i.Id == id);

            if (stationFromDb == null)
                return Json(new { success = false, message = "Not found" });

            return Json(new {success = true, id = stationFromDb.Id, name = stationFromDb.Name});
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stationList = _unitOfWork.Stations.GetAll();
            return Json(new { data = stationList });
        }
        #endregion
    }
}
