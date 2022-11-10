using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BusinessLogic.Graph
{
    public class Edge<T> 
    {
        public Vertex<T> From { get; }
        public Vertex<T> To { get; }
        public double Weight { get; set; }

        public Edge(T vertex1, T vertex2, double weight, List<Vertex<T>> vertices)
        {
            From = FindVertex(vertex1, vertices);
            if (From == null)
            {
                From = new Vertex<T>(vertex1);
                vertices.Add(From);
            }

            To = FindVertex(vertex2, vertices);
            if (To == null)
            {
                To = new Vertex<T>(vertex2);
                vertices.Add(To);
            }

            Weight = weight;
            From.AddOutgoing(To);
            To.AddIncoming(From);
        }

        private Vertex<T> FindVertex(T vertex, List<Vertex<T>> vertices)
        {
            foreach (var each in vertices)
            {
                if (each.Value.Equals(vertex))
                    return each;
            }

            return null;
        }
    }
}
