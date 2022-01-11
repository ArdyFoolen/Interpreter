using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class ExpressionFactoryCreator : IExpressionFactoryCreator
    {
        public IExpressionFactory Create(string @operator)
        {
            switch (@operator)
            {
                case "+":
                    return new AdditionExpressionFactory();
                case "-":
                    return new SubtractionExpressionFactory();
                case "*":
                    return new MultiplicationExpressionFactory();
                default: throw new InvalidOperatorException(@operator);
            }
        }

        public bool HasFactoryFor(string @operator)
            => @operator.Equals("+") || @operator.Equals("-") || @operator.Equals("*");
    }
}
