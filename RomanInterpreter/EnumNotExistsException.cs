using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public class EnumNotExistsException : Exception
    {
        public EnumNotExistsException(Type enumType, string name) : base($"Name {name} not a valid {enumType.Name}") { }
    }
}
