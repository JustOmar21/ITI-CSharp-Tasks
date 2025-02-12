using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class Exam
    {
        public Exam(string name, DateTime dateandtime)
        {
            Name = name;
            DateAndTime = dateandtime;
        }

        public string Name { get; set; }
        public DateTime DateAndTime { get; set; }
        public Subject Subject { get; set; }
        public QuestionList questions { get; set; }
        public Dictionary<int,AnswerList> Answers { get; set; } = new Dictionary<int,AnswerList>();

        public virtual void Show()
        {

        }
    }
}
