using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class Question : IComparable<Question> , ICloneable
    {
        public Question(string body, double mark, string type, Choices correctChoice)
        {
            Body = body;
            Mark = mark;
            Type = type;
            CorrectChoice = correctChoice;
        }
        public Question(Question question)
        {
            Body = question.Body;
            Mark = question.Mark;
            Type = question.Type;
            CorrectChoice = question.CorrectChoice;
            answers =  question.answers; 
        }

        public string Body { get; set; }
        public double Mark { get; set; }
        public string Type { get; set; }
        public Choices CorrectChoice { get; set; }

        public AnswerList answers { get; set; }

        public override string ToString()
        {
            return $"{Body}|{Mark}|{Type}|{CorrectChoice}";
        }
        public virtual string ToExam()
        {
            return $"Body: {Body}\nCorrect Choice = {CorrectChoice}";
        }
        public static Question FromString(string line)
        {
            string[] parts = line.Split('|');
            if (parts[2] == "TF")
            {
                return new TFQuestion
                (
                    parts[0],
                    double.Parse(parts[1]),
                    parts[2],
                    Enum.Parse<Choices>(parts[3])
                );
            }
            else if (parts[2] == "MCQ1")
            {
                return new MCQ1Question
                (
                    parts[0],
                    double.Parse(parts[1]),
                    parts[2],
                    Enum.Parse<Choices>(parts[3]),
                    parts[4],
                    parts[5],
                    parts[6],
                    parts[7]
                );
            }
            else if (parts[2] == "MCQA")
            {
                return new MCQAllQuestion
                (
                    parts[0],
                    double.Parse(parts[1]),
                    parts[2],
                    Enum.Parse<Choices>(parts[3]),
                    parts[4],
                    parts[5],
                    parts[6],
                    parts[7]
                );
            }
            else
            {
                return new Question
                (
                    parts[0],
                    double.Parse(parts[1]),
                    parts[2],
                    Enum.Parse<Choices>(parts[3])
                );
            }
            
        }

        public int CompareTo(Question? other)
        {
            return other?.Body.CompareTo(this.Body) ?? -1;
        }

        public object Clone()
        {
            return new Question(this);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Body,Type,Mark);
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }
}
