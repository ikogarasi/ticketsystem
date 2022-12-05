using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models.ViewModels
{
    public class PassBookingVM
    {
        public BoardingPassModel BoardPass { get; set; }
        public Guid RouteId { get; set; }
        [ForeignKey("RouteId")]
        public RouteModel Route { get; set; }
    }
}
