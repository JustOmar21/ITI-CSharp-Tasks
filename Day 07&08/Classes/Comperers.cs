using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Classes
{
    internal class Comperers
    {
    }
    public class QuestionComparer : IComparer<Question>
    {
        int IComparer<Question>.Compare(Question? x, Question? y)
        {
            return x?.CompareTo(y) ?? -1;
        }
    }
    public class QuestionEqualityComparer : IEqualityComparer<Question>
    {
        bool IEqualityComparer<Question>.Equals(Question? x, Question? y)
        {
            return x?.Equals(y) ?? false;
        }

        int IEqualityComparer<Question>.GetHashCode(Question obj)
        {
            return obj.GetHashCode();
        }
    }
}
