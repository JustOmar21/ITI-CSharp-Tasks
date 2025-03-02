using Iterator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Implementation
{
    internal class Names : IIteratable<string>
    {
        public List<string> NamesList { get; set; }

        private IIterator<string> iterator;

        public void setIterator(IIterator<string> iterator) => this.iterator = iterator;

        public Names(List<string> names)
        {
            this.NamesList = names;
        }

        public IIterator<string> GetIterator()
        {
            return iterator.CreateIterator(NamesList);
        }
    }
}
