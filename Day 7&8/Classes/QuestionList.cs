using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class QuestionList : List<Question>
    {
        string fileName;
        public QuestionList(string fileName)
        {
            this.fileName = fileName.ToLower();
        }
        public new void Add(Question item)
        {
            string path = AppContext.BaseDirectory.Split(@"\bin")[0] + @$"\{fileName}.txt";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    // File is created, optionally write some initial data
                }
            }
            using (TextWriter text = new StreamWriter(path, append: true))
            {
                text.WriteLine(item);
            }
            base.Add(item);
        }
    }
}
