using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class Subject
    {
        public Subject(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }

        public string Name { get; set; }
        public int Hours { get; set; }
    }
}
