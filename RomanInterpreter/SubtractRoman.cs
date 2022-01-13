using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public class SubtractRoman : IRoman
    {
        public IRoman First { get; private set; }
        public IRoman Second { get; private set; }

        public SubtractRoman(IRoman first, IRoman second)
        {
            First = first;
            Second = second;
        }

        public bool IsSmaller(INumberRoman roman)
            => Second.IsSmaller(roman);

        public int Interpret()
            => Second.Interpret() - First.Interpret(); 
    }
}
