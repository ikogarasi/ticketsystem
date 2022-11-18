using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models.ViewModels
{
    public class RouteSearchVM
    {
        public Guid OutgoingStationId { get; set; }
        [ForeignKey("OutgoingStationId")]
        public StationModel OutgoingStation { get; set; }
        public Guid DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public StationModel DestinationStation { get; set; }

        [ValidateNever]
        public Priorities Priority { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> StationsList { get; set; }
    }

    public enum Priorities
    { 
        DISTANCE,
        TIME,
        PRICE
    }
}
