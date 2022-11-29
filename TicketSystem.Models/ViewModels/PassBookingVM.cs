using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models.ViewModels
{
    public class PassBookingVM
    {
        public BoardingPassModel BoardPass { get; set; }
        public List<Guid> RoutesId { get; set; }
        public List<RouteModel> Routes { get; set; }
        public double SumPrice { get; set; }
    }
}
