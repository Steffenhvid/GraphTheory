using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Vertice
    {
        private readonly int _id;
        public int Id => _id;
        public string? Name { get; set; }

        public Vertice(int id, string? name = null)
        {
            _id = id;
            Name = name;
        }
    }
}