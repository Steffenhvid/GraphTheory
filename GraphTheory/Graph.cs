using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Graph
    {
        public List<Vertice> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        private int[,] _adjecencyMatrix;

        public Graph()
        {
            Vertices = new List<Vertice>();
            Edges = new List<Edge>();
        }

        public void AddVertice(Vertice vertice)
        {
            Vertices.Add(vertice);
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public int[,] GetAdjencencyMatrix()
        {
            if (_adjecencyMatrix == null)
                CreateAdjencencyMatrix();
            return _adjecencyMatrix;
        }

        private void CreateAdjencencyMatrix()
        {
            _adjecencyMatrix = new int[Vertices.Count, Vertices.Count];
            foreach (Edge edge in Edges)
            {
                _adjecencyMatrix[edge.Definition.Item1.Id, edge.Definition.Item2.Id] = 1;
            }
        }
    }
}