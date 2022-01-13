using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public class AddRoman : IRoman
    {
        public IRoman First { get; private set; }
        public IRoman Second { get; private set; }

        public AddRoman(IRoman first, IRoman second)
        {
            First = first;
            Second = second;
        }

        public bool IsSmaller(INumberRoman roman)
            => Second.IsSmaller(roman);

        public int Interpret()
            => First.Interpret() + Second.Interpret();
    }
}
