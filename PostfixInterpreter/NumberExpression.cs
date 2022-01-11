using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class NumberExpression : Expression
    {
        public int Context { get; private set; }
        public NumberExpression(int context) { this.Context = context; }

        public int Interpret()
            => Context;
    }
}
