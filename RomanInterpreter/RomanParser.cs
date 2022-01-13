using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public class RomanParser
    {
        private IRomanBuilder builder;
        public RomanParser(IRomanBuilder builder)
        {
            this.builder = builder;
        }

        public IRoman Parse(string context)
        {
            foreach (char c in context)
                builder.WithToken(c);

            return builder.Build();
        }
    }
}
