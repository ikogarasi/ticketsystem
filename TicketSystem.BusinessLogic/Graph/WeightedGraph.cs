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
        public Dictionary<T, LinkedList<Edge<T>>> adjencyMatrix;        

        public WeightedGraph()
        {
            adjencyMatrix = new Dictionary<T, LinkedList<Edge<T>>>();
        }

        public void AddEdge(T vertex, T connectedVertex, double weight)
        {
            adjencyMatrix.Add(vertex, new LinkedList<Edge<T>>());
            adjencyMatrix.Add(connectedVertex, new LinkedList<Edge<T>>());
            Edge<T> tempEdge = new Edge<T>(connectedVertex, weight);
            adjencyMatrix[vertex].AddLast(tempEdge);
        }

        public void RemoveEdge(T vertex, T connectedVertex)
        {
            if (adjencyMatrix[vertex] == null)
                throw new KeyNotFoundException("Edge is not found");
            Edge<T> edge = FindEdgeByVertex(vertex, connectedVertex);
            adjencyMatrix[vertex].Remove(edge);
        }

        public bool HasNode(T key) => adjencyMatrix.ContainsKey(key);

        public bool HasEdge(T vertex, T connectedVertex)
        {
            Edge<T> edge = FindEdgeByVertex(vertex, connectedVertex);
            return edge != null;
        }
            

        public void RemoveNode(T vertex)
        {
            foreach (T key in adjencyMatrix.Keys)
            {
                Edge<T> edge = FindEdgeByVertex(key, vertex);
                if (edge != null)
                    adjencyMatrix[key].Remove(edge);
            }

            adjencyMatrix.Remove(vertex);
        }

        private Edge<T> FindEdgeByVertex(T vertex, T connectedVertex)
        {
            LinkedList<Edge<T>> edges = adjencyMatrix[vertex];
            foreach (var edge in edges)
                if (edge.ConnectedVertex.Equals(connectedVertex))
                    return edge;

            return null;
        }
    }
}
