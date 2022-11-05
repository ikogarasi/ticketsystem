using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models.ViewModels
{
    public class RouteVM
    {
        public RouteModel Route { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> StationsList { get; set; }
        
    }
}
