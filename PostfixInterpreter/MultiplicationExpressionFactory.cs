using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class MultiplicationExpressionFactory : IExpressionFactory
    {
        public Expression Create(Expression first, Expression second)
            => new MultiplicationExpression(first, second);
    }
}
