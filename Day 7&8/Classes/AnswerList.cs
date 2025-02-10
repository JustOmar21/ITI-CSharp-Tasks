using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class AnswerList : List<Answer>
    {
        public AnswerList(int num):base(num)
        {
            for(int i = 0; i < num; i++)
            {
                this.Add(new Answer());
            }
        }
    }
}
