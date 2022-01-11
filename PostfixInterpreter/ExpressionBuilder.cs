using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class ExpressionBuilder : IExpressionBuilder
    {
        private IExpressionFactoryCreator creator;
        private Stack<Expression> stack = new Stack<Expression>();
        private int number;

        public ExpressionBuilder(IExpressionFactoryCreator creator)
        {
            this.creator = creator;
        }

        public ExpressionBuilder WithContext(string context)
        {
            if (isNumber(context))
                return WithNumber(number);

            return WithOperator(context);
        }

        public ExpressionBuilder WithNumber(int number)
        {
            stack.Push(new NumberExpression(number));
            return this;
        }

        public ExpressionBuilder WithOperator(string @operator)
        {
            GuardAgainstOperator(@operator);

            Expression second = stack.Pop();
            Expression first = stack.Pop();

            var factory = creator.Create(@operator);
            stack.Push(factory(first, second));

            return this;
        }

        public Expression Build()
        {
            if (stack.Count() != 1)
                throw new InvalidBuildException(stack.Count());

            return stack.Pop();
        }

        private void GuardAgainstOperator(string @operator)
        {
            if (stack.Count() < 2)
                throw new InvalidOperatorException(stack.Count());

            if (!creator.HasFactoryFor(@operator))
                throw new InvalidContextException(@operator);
        }

        private bool isNumber(string context)
            => int.TryParse(context, out number);
    }
}
