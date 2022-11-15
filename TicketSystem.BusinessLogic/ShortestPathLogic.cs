using TicketSystem.BusinessLogic.Graph;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models;

namespace TicketSystem.BusinessLogic
{
    public class ShortestPathLogic
    {
        /// <summary>
        /// Elthon john molodec
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        private WeightedGraph<StationModel> _graph;

        public ShortestPathLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UpdateGraph();
        }
        
        private void UpdateGraph(double priceCoefficient = 1, double durationCoefficient = 1, double distanceCoefficient = 1)
        {
            _graph = new WeightedGraph<StationModel>();
            foreach(var route in _unitOfWork.Routes.GetAll())
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