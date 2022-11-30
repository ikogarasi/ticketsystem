using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketSystem.Models.ViewModels
{
    public class RouteVM
    {
        public RouteModel Route { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> StationsList { get; set; }
        
    }
}
