using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BusinessLogic.Graph
{
    public static class Dijkstra
    {
        public static void Init<T>(WeightedGraph<T> graph, T src) where T : class
        {
            if (graph.Vertices.Count == 0)
                throw new Exception("Dijkstra: vertices is empty");

            Vertex<T> source = graph.FindVertex(src);
            if (source == null)
                throw new Exception("Dijkstra: source is not found");

            source.MinDistance = 0;
            PriorityQueue<Vertex<T>, int> priorityQueue = new PriorityQueue<Vertex<T>, int>();
            priorityQueue.Enqueue(source, 1);

            while (priorityQueue.Count > 0)
            {
                Vertex<T> u = priorityQueue.Dequeue();
                foreach (var v in u.Outgoing)
                {
                    Edge<T> edge = graph.FindEdge(u, v);
                    if (edge == null)
                        throw new Exception("Dijkstra: imposter");

                    double totalDistance = u.MinDistance + edge.Weight;
                    if (totalDistance < v.MinDistance)
                    {
                    }
                }
            }
        }
    }
}
