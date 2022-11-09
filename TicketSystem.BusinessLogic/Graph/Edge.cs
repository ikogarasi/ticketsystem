using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BusinessLogic.Graph
{
    public class Edge<T> where T : class
    {
        public T ConnectedVertex { get; }
        public double Weight { get; }

        public Edge(T connectedVertex, double weight)
        {
            ConnectedVertex = connectedVertex;
            Weight = weight;
        }
    }
}
