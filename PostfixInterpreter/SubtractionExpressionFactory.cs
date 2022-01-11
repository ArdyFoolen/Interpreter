using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class SubtractionExpressionFactory : IExpressionFactory
    {
        public Expression Create(Expression first, Expression second)
            => new SubtractionExpression(first, second);
    }
}
