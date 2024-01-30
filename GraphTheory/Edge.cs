using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    /// <summary>
    /// A none weighted graph is the same as a weighted graph where all weights are 1
    ///
    /// Not sure how to implement this yet
    /// </summary>
    public class Edge
    {
        private readonly (Vertice, Vertice) _definition;

        public (Vertice, Vertice) Definition => _definition;

        public Edge(Vertice v1, Vertice v2)
        {
            _definition = (v1, v2);
        }
    }
}