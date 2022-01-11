using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public interface IExpressionFactoryCreator
    {
        IExpressionFactory Create(string @operator);
        bool HasFactoryFor(string @operator);    }
}
