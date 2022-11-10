using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.BusinessLogic.Graph
{
    public class WeightedGraph<T> where T : class
    {
        public List<Vertex<T>> Vertices;
        public List<Edge<T>> Edges;

        public WeightedGraph()
        {
            Vertices = new List<Vertex<T>>();
            Edges = new List<Edge<T>>();
        }

        public void AddEdge(T src, T dest, double weight)
        {
            Edge<T> temp = FindEdge(src, dest);
            if (temp != null)
            {
                temp.Weight = weight;
            }
            else
            {
                Edge<T> e = new Edge<T>(src, dest, weight, Vertices);
                Edges.Add(e);
            }
        }

        public Vertex<T> FindVertex(T vertex)
        {
            foreach (var each in Vertices)
            {
                if (each.Value.Equals(vertex))
                    return each;
            }

            return null;
        }

        public Edge<T> FindEdge(Vertex<T> vertex1, Vertex<T> vertex2)
        {
            foreach (var each in Edges)
            {
                if (each.From.Equals(vertex1) && each.To.Equals(vertex2))
                    return each;
            }

            return null;
        }

        public Edge<T> FindEdge(T from, T to)
        {
            foreach (var each in Edges)
            {
                if (each.From.Value.Equals(from) && each.To.Value.Equals(to))
                    return each;
            }

            return null;
        }
    }
}
