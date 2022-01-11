using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class SubtractionExpression : Expression
    {
        public Expression First { get; private set; }
        public Expression Second { get; private set; }
        public SubtractionExpression(Expression first, Expression second)
        {
            First = first;
            Second = second;
        }

        public int Interpret()
            => First.Interpret() - Second.Interpret();
    }
}
