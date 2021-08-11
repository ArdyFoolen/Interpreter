using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public abstract class Spec
    {
        public abstract bool IsSatisfiedBy(Product product);
    }
}
