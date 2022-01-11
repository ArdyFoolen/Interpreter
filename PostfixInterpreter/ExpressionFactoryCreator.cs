using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public enum OperatorEnum
    {
        [Display(Name = "+")]
        Addition,
        [Display(Name = "-")]
        Subtraction,
        [Display(Name = "*")]
        Multiplication
    }

    public class ExpressionFactoryCreator : IExpressionFactoryCreator
    {
        private static readonly Func<Expression, Expression, Expression> AdditionExpressionFactory =
            (first, second) => new AdditionExpression(first, second);
        private static readonly Func<Expression, Expression, Expression> SubtractionExpressionFactory =
            (first, second) => new SubtractionExpression(first, second);
        private static readonly Func<Expression, Expression, Expression> MultiplicationExpressionFactory =
            (first, second) => new MultiplicationExpression(first, second);

        public Func<Expression, Expression, Expression> Create(string @operator)
        {
            switch (@operator)
            {
                case "+":
                    return AdditionExpressionFactory;
                case "-":
                    return SubtractionExpressionFactory;
                case "*":
                    return MultiplicationExpressionFactory;
                default: throw new InvalidOperatorException(@operator);
            }
        }

        public bool HasFactoryFor(string @operator)
            => @operator.IsPartOf<OperatorEnum>();
    }
}
