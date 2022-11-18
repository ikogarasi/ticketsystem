using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models.ViewModels
{
    public class SearchResultVM
    {
        public SortedSet<StationModel> Stations { get; set; }
        public SortedSet<RouteModel> Routes { get; set; }
        
        public double SummaryPrice { get; set; }
        public double SummaryDistance { get; set; }
        public TimeSpan SummaryTime { get; set; }
    }
}
