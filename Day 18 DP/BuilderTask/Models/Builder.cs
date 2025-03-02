using BuilderTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTask.Models
{
    internal class Builder : IBuilder
    {
        List<string> parts;

        public Builder() { Reset(); }
        public Builder BuildPart(string part)
        {
            parts.Add(part);
            return this;
        }

        public string Create()
        {
            return string.Join(" , ",parts);
        }

        public void Reset() => parts = new List<string>();
    }
}
