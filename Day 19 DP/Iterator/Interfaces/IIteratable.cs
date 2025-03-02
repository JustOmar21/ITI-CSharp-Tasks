using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Interfaces
{
    internal interface IIteratable<T>
    {
        public IIterator<T> GetIterator();
    }
}
