using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class FinalExam : Exam
    {
        public FinalExam(string name, DateTime dateandtime) : base(name, dateandtime)
        {

        }
        public override void Show()
        {
            int num = 1;
            foreach (var question in questions)
            {
                Console.WriteLine($"Q{num++}: {question.ToExam()}");
            }
        }
    }
}
