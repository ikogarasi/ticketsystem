using TicketSystem.BusinessLogic.Graph;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models;
using TicketSystem.Models.ViewModels;

namespace TicketSystem.BusinessLogic
{
    /// <summary>
    /// Elthon john molodec
    /// </summary>
    public class ShortestPathHandler
    {
        private readonly IUnitOfWork _unitOfWork; 
        private WeightedGraph<StationModel> _graph;

        public ShortestPathHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _graph = new WeightedGraph<StationModel>();
        }
        
        public void FindShortestRoute(SearchResultVM obj)
        {
            switch (obj.RouteSearchVM.Priority)
            {
                case Priorities.DISTANCE:
                    UpdateGraph(distanceCoefficient: 1);
                    break;
                case Priorities.TIME:
                    UpdateGraph(durationCoefficient: 1);
                    break;
                case Priorities.PRICE:
                    UpdateGraph(priceCoefficient: 1);
                    break;
            }

            List<StationModel> stations = new();

            try
            {
                stations = ShortestPath<StationModel>.GetPath(_graph,
                    obj.RouteSearchVM.OutgoingStation, obj.RouteSearchVM.DestinationStation);
            }
            catch
            {
                obj.IsRouteFound = false;
                return;
            }
            
            List<RouteModel> routes = new List<RouteModel>();
            for (int i = 0; i < stations.Count - 1; ++i)
            {
                var route = _unitOfWork.Routes.GetFirstOrDefault(route => route.OutgoingStationId == stations[i].Id && route.DestinationStationId == stations[i + 1].Id);
                if (route != null)
                    routes.Add(route);
                else
                    throw new Exception("Route Not Found");
            }
            obj.Routes = routes;
            obj.Stations = stations;
            
            double sumDistance = 0;
            double sumPrice = 0;
            double sumMinutes = 0;
            
            foreach (var route in routes)
            {
                sumDistance += route.Distance;
                sumPrice += route.Price;
                sumMinutes += route.Duration.TotalMinutes;
            }
            
            obj.SummaryPrice = sumPrice;
            obj.SummaryDistance = sumDistance;
            obj.SummaryTime = TimeSpan.FromMinutes(sumMinutes);
        }

        private void UpdateGraph(double priceCoefficient = 0, double durationCoefficient = 0, double distanceCoefficient = 0)
        {
            foreach(var route in _unitOfWork.Routes.GetAll("OutgoingStation,DestinationStation"))
            {
                _graph.AddEdge(route.OutgoingStation, route.DestinationStation, SetWeight(route,
                    priceCoefficient, durationCoefficient, distanceCoefficient));
            }
        }

        private double SetWeight(RouteModel route, double priceCoefficient, double durationCoefficient,
            double distanceCoefficient) 
            => route.Distance * distanceCoefficient + route.Duration.TotalMinutes * durationCoefficient + route.Price * priceCoefficient;
    }
}