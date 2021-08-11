using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class OrSpec : Spec
    {
        public Spec Augend { get; private set; }
        public Spec Orend { get; private set; }

        public OrSpec(Spec augend, Spec addend)
        {
            this.Augend = augend;
            this.Orend = addend;
        }

        public override bool IsSatisfiedBy(Product product)
            => Augend.IsSatisfiedBy(product) ||
               Orend.IsSatisfiedBy(product);
    }
}
