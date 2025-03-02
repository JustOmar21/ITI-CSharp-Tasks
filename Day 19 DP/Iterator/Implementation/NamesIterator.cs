using Iterator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Implementation
{
    internal class NamesIterator : IIterator<string>
    {
        List<string> names;

        int currentIndex = 0;

        public NamesIterator(List<string> names)
        {
            this.names = names;
        }

        public NamesIterator() { }

        public IIterator<string> CreateIterator(List<string> items)
        {
            return new NamesIterator(items);
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
