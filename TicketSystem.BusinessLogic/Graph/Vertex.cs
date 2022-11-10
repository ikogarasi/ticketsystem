using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BusinessLogic.Graph
{
    public class Vertex<T> : IComparable<Vertex<T>>
    {
        public List<Vertex<T>> Incoming;
        public List<Vertex<T>> Outgoing;
        
        public T Value { get; set; }
        public double MinDistance { get; set; }
        public Vertex<T> Parent { get; set; }
        public State St { get; set; }

        public Vertex(T obj)
        {
            Incoming = new List<Vertex<T>>();
            Outgoing = new List<Vertex<T>>();
            Value = obj;
            MinDistance = Double.MaxValue;
            St = State.UNVISITED;
        }

        public void AddIncoming(Vertex<T> vertex) => Incoming.Add(vertex);
        public void AddOutgoing(Vertex<T> vertex) => Outgoing.Add(vertex);

        public int CompareTo(Vertex<T> other)
        {
            return MinDistance > other.MinDistance ? 1 
                : Math.Abs(MinDistance - other.MinDistance) <= 1e-7 ? 0 : -1;
        }

        
    }
}
