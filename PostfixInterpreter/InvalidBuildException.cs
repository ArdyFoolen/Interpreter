using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public class InvalidBuildException : Exception
    {
        public InvalidBuildException(int count) : base($"Expression cannot be build, count: {count} is invalid") { }
    }
}
