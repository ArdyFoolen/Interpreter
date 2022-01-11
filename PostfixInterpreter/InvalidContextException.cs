using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class InvalidContextException : Exception
    {
        public InvalidContextException(string context) : base($"Context: {context} is invalid") { }
    }
}
