using Day_7.Classes;
using System.Runtime.InteropServices.Marshalling;

namespace Day_7
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            QuestionList q = new QuestionList("Exam 22");
            q.Add(new TFQuestion("q1", 2, "TF", Choices.Choice1));
            q.Add(new MCQ1Question("q2", 2, "MCQ1", Choices.Choice2, "A", "B", "C", "D"));


            FinalExam final = new FinalExam("ExamF",DateTime.Now);


            PracticeExam practice = new PracticeExam("ExamP", DateTime.Now);

            final.questions = q;
            practice.questions = q;

            double grade = 0;
            double questionsCount = practice.questions.Sum(pc => pc.Mark);
            for(int i = 0; i< practice.questions.Count; i++)
            {
                Console.Write($"Q{i+1}: {practice.questions[i].ToExam()}\nChoose an Answer: ");
                if (!practice.Answers.ContainsKey(1))
                {
                    practice.Answers.Add(1, new AnswerList(practice.questions.Count));
                }
                practice.Answers[1][i].Choice = Enum.Parse<Choices>(Console.ReadLine());
                if (practice.Answers[1][i].Choice == final.questions[i].CorrectChoice)
                {
                    grade += practice.questions[i].Mark;
                }
            }

            var finalGrade = grade / questionsCount;

            Console.WriteLine($"\n\npractice Grade: {finalGrade:P}\n\n");
            practice.Show();

            //final.Show();
            //Console.WriteLine("--------------------------");
            //practice.Show();
            //QuestionList questions = new QuestionList();
            //using (TextReader textReader = File.OpenText(path))
            //{
            //    string line;
            //    while ((line = textReader.ReadLine()) != null)
            //    {
            //        questions.Add(Question.FromString(line));
            //    }
            //}
            //foreach (Question question in questions)
            //{
            //    Console.WriteLine(question);
            //}
        }
    }
}
