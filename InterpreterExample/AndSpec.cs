using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class AndSpec : Spec
    {
        public Spec Augend { get; private set; }
        public Spec Addend { get; private set; }

        public AndSpec(Spec augend, Spec addend)
        {
            this.Augend = augend;
            this.Addend = addend;
        }

        public override bool IsSatisfiedBy(Product product)
            => Augend.IsSatisfiedBy(product) &&
                   Addend.IsSatisfiedBy(product);
    }
}
