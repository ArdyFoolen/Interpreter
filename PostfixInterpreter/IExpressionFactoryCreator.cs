using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public interface IExpressionFactoryCreator
    {
        Func<Expression, Expression, Expression> Create(string @operator);
        bool HasFactoryFor(string @operator);    }
}
