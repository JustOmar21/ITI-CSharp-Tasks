using Iterator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Implementation
{
    internal class FourLettersOnlyIterator : IIterator<string>
    {
        List<string> names;

        int currentIndex = 0;

        public FourLettersOnlyIterator(List<string> names)
        {
            this.names = names.Where(n => n.Length == 4).ToList();
        }

        public FourLettersOnlyIterator() { }

        public IIterator<string> CreateIterator(List<string> items)
        {
            return new FourLettersOnlyIterator(items);
        }

        public bool HasNext()
        {
            return currentIndex < names.Count;
        }

        public string Next()
        {
            return names[currentIndex++];
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}
