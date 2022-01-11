using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException(int count) : base($"Operator count: {count} is invalid") { }
        public InvalidOperatorException(string @operator) : base($"Operator: {@operator} is invalid") { }
    }
}
