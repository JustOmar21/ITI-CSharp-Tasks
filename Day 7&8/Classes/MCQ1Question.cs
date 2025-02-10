using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class MCQ1Question : Question
    {

        public MCQ1Question(string body, double mark, string type, Choices correctChoice,string choice1, string choice2, string choice3, string choice4) : base(body, mark, type, correctChoice)
        {
            Choice1 = choice1;
            Choice2 = choice2;
            Choice3 = choice3;
            Choice4 = choice4;
        }

        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}|{Choice1}|{Choice2}|{Choice3}|{Choice4}";
        }
        public override string ToExam()
        {
            return $"Choose The Correct Answer\n{Body}\nChoice 1: {Choice1}\nChoice 2: {Choice2}\nChoice 3: {Choice3}\nChoice 4: {Choice4}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Body, Type, Mark,Choice1,Choice2,Choice3,Choice4);
        }
    }
}
