using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BusinessLogic.Graph
{
    public static class ShortestPath<T> where T : class
    {
        public static List<T> GetPath(WeightedGraph<T> graph, T from, T to) 
        {
            Dijkstra(graph, from);
            List<T> path = GetShortestPath(graph.FindVertex(to));
            return path;
        }

        private static void Dijkstra<T>(WeightedGraph<T> graph, T src) where T : class
        {
            if (graph.Vertices.Count == 0)
                throw new Exception("Dijkstra: vertices is empty");

            ResetDistances(graph);

            Vertex<T> source = graph.FindVertex(src);
            if (source == null)
                throw new Exception("Dijkstra: source is not found");

            source.MinDistance = 0;
            SortedSet<Vertex<T>> priorityQueue = new SortedSet<Vertex<T>>();
            priorityQueue.Add(source);

            while (priorityQueue.Count > 0)
            {
                Vertex<T> u = priorityQueue.First();
                priorityQueue.Remove(u);

                foreach (var v in u.Outgoing)
                {
                    Edge<T> edge = graph.FindEdge(u, v);
                    if (edge == null)
                        throw new Exception("Dijkstra: imposter");

                    double totalDistance = u.MinDistance + edge.Weight;
                    if (totalDistance < v.MinDistance)
                    {
                        priorityQueue.Remove(v);
                        v.MinDistance = totalDistance;
                        v.Previous = u;
                        priorityQueue.Add(v);
                    }
                }
            }
        }

        private static List<T> GetShortestPath(Vertex<T> target)
        {
            List<T> result = new List<T>();

            if (target.MinDistance == double.MaxValue)
                throw new PathTooLongException();

            for (Vertex<T> v = target; v != null; v = v.Previous)
                result.Add(v.Value);

            result.Reverse();
            return result;
        }

        private static void ResetDistances<T>(WeightedGraph<T> graph) where T : class
        {
            foreach (Vertex<T> each in graph.Vertices)
            {
                each.MinDistance = Double.MaxValue;
                each.Previous = null;
            }
        }
    }
}
