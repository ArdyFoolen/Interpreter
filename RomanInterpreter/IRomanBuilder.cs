using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public interface IRomanBuilder
    {
        IRomanBuilder WithToken(char token);
        IRoman Build();
    }
}
