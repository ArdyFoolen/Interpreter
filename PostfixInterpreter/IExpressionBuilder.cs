using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public interface IExpressionBuilder
    {
        ExpressionBuilder WithContext(string context);
        ExpressionBuilder WithNumber(int number);
        ExpressionBuilder WithOperator(string @operator);
        Expression Build();
    }
}
