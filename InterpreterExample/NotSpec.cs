using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class NotSpec : Spec
    {
        public Spec Negate { get; private set; }

        public NotSpec(Spec negate)
        {
            this.Negate = negate;
        }

        public override bool IsSatisfiedBy(Product product)
            => !Negate.IsSatisfiedBy(product);
    }
}
