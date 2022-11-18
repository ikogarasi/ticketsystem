using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text.Json;
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
        public IActionResult Index(RouteSearchVM? obj)
        {
            RouteSearchVM searchVM = new()
            {
                StationsList = _unitOfWork.Stations.GetAll().Select(
                    i => new SelectListItem()
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
            };

            if (obj == null)
                return View(searchVM);

            searchVM.DestinationStationId = obj.DestinationStationId;
            searchVM.OutgoingStationId = obj.OutgoingStationId;
            searchVM.Priority = obj.Priority;

            return View(searchVM);
        } 
        

    }
}
