using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public class NumberRoman : INumberRoman
    {
        public RomanEnum Roman { get; private set; }

        public NumberRoman(RomanEnum roman)
        {
            Roman = roman;
        }

        public bool IsSmaller(INumberRoman roman)
            => Roman < roman.Roman;

        public int Interpret()
            => (int)Roman;
    }
}
