namespace TicketSystem.Models.ViewModels
{
    public class SearchResultVM
    {
        public bool IsRouteFound { get; set; } = true;
        public RouteSearchVM RouteSearchVM { get; set; }
        public List<StationModel> Stations { get; set; }
        public List<RouteModel> Routes { get; set; }
        public double SummaryPrice { get; set; }
        public double SummaryDistance { get; set; }
        public TimeSpan SummaryTime { get; set; }
    }
}
