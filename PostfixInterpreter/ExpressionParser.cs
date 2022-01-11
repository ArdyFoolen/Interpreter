using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class ExpressionParser
    {
        private IExpressionBuilder builder;
        public ExpressionParser(IExpressionBuilder builder)
        {
            this.builder = builder;
        }

        public Expression Parse(string context)
        {
            var tokens = context.Split(" ");
            foreach (var token in tokens)
                builder.WithContext(token);

            return builder.Build();
        }
    }
}
