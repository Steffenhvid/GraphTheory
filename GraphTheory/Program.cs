using GraphTheory;
using GraphTheory.Datasets;

var LondonTupeData = new LondonTubeMap();
Graph graph = LondonTupeData.Graph;

Console.WriteLine(graph.GetAdjencencyMatrix());