using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(string name, DateTime dateandtime) : base(name, dateandtime)
        {

        }
        public override void Show()
        {
            int num = 1;
            foreach(var question in questions)
            {
                Console.WriteLine($"Q{num++}: {question.ToExam()}\nAnswer: {question.CorrectChoice}");
            }
        }

        public void ShowAnswers()
        {
            int num = 1;
            foreach (var question in questions)
            {
                Console.WriteLine($"Q{num++}: {question.CorrectChoice}");
            }
        }
    }
}
