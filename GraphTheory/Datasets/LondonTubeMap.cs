using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.Datasets
{
    public class LondonTubeMap
    {
        private const string dataUrl = @"https://graphia.app/datasets/Simple_pairwise-London_tube_map.txt";

        private readonly Dictionary<string, int> _verticeMap;
        private readonly List<int> _vertices;
        private readonly List<(int, int)> _edges;

        private readonly Graph _graph;
        public Graph Graph => _graph;

        public LondonTubeMap()
        {
            List<List<string>>? Data = CleanData();
            _verticeMap = CreateVerticeMap(Data);
            _vertices = _verticeMap.Values.ToList();
            _edges = CreateEdges(Data);
            _graph = CreateGraph();
        }

        private Graph CreateGraph()
        {
            Graph graph = new Graph();

            foreach (var vertex in _verticeMap)
                graph.AddVertice(new Vertice(vertex.Value, vertex.Key));

            foreach (var edge in _edges)
            {
                Vertice vertice1 = graph.Vertices.First(x => x.Id == edge.Item1);
                Vertice vertice2 = graph.Vertices.First(x => x.Id == edge.Item2);
                graph.AddEdge(new Edge(vertice1, vertice2));
            }

            return graph;
        }

        private List<(int, int)> CreateEdges(List<List<string>> data)
        {
            List<(int, int)> result = [];
            foreach (var edge in data)
            {
                if (edge.Count == 2)
                    result.Add((_verticeMap[edge[0]], _verticeMap[edge[1]]));
            }
            return result;
        }

        private Dictionary<string, int> CreateVerticeMap(List<List<string>> data)
        {
            Dictionary<string, int> result = [];
            int indexRepresentation = 0;
            foreach (var item in data)
                foreach (var v in item)
                    if (!result.ContainsKey(v))
                    {
                        result[v] = indexRepresentation++;
                    }
            return result;
        }

        private List<List<string>> CleanData()
        {
            HttpClient client = new();
            Stream response = client.GetStreamAsync(dataUrl).Result;
            StreamReader reader = new(response);
            string test = reader.ReadToEnd();
            var str = test.Split('\n').Select(x => x.Trim().Split('\t').ToList()).ToList();
            return str;
        }
    }
}