using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public class RomanNotAllowedException : Exception
    {
        public RomanNotAllowedException(RomanEnum roman) : base($"Roman {roman} not allowed") { }
    }
}
