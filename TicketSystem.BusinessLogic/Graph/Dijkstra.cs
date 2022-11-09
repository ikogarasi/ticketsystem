using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BusinessLogic.Graph
{
    public static class Dijkstra
    {
        public static void Init<T>(WeightedGraph<T> graph, T start) where T : class
        {
            Dictionary<T, double> distance = new Dictionary<T, double>();
            foreach (var item in graph.adjencyMatrix)
            {
                distance.Add(item.Key, double.MaxValue);
            }

            SortedSet<Edge<T>> pq = new SortedSet<Edge<T>>();
            pq.Add(new Edge<T>(start, 0));

            while (pq.Count > 0)
            {
                Edge<T> current = pq.First();
                pq.Remove(current);
            }
        }
    }
}
