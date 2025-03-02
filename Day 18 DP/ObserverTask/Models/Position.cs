using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTask.Models
{
    public class Position
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position(int x, int y, int z) => (X, Y, Z) = (x, y, z);
        public Position() { }

        public override string ToString()
            => $"({X} , {Y} , {Z})";
    }
}
