using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class MultiplicationExpression : Expression
    {
        public Expression First { get; private set; }
        public Expression Second { get; private set; }
        public MultiplicationExpression(Expression first, Expression second)
        {
            First = first;
            Second = second;
        }

        public int Interpret()
            => First.Interpret() * Second.Interpret();
    }
}
