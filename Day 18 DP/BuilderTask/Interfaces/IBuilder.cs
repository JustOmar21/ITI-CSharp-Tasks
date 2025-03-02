using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTask.Interfaces
{
    internal interface IBuilder
    {
        Models.Builder BuildPart(string part);
        string Create();

        void Reset();
    }
}
