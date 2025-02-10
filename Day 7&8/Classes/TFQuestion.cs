using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class TFQuestion : Question
    {
        public TFQuestion(string body, double mark, string type, Choices correctChoice) : base(body, mark, type, correctChoice)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}|True|False";
        }
        public override string ToExam()
        {
            return $"True or False\n{Body}\nChoice 1: True\nChoice 2: False";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Body, Type, Mark,"True","False");
        }
    }
}
