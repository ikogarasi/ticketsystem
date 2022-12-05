using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

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

        public bool isReturnWay { get; set; }

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
