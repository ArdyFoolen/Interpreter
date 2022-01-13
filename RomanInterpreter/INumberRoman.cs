using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public interface INumberRoman : IRoman
    {
        RomanEnum Roman { get; }
    }
}
