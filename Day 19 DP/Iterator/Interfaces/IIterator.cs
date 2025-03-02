using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Interfaces
{
    internal interface IIterator<T>
    {
        public bool HasNext();
        public T Next();
        public void Reset();
        public IIterator<T> CreateIterator(List<T> items);
    }
}
