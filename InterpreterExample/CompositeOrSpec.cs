using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class CompositeOrSpec : Spec
    {
        public List<Spec> Specs { get; private set; }

        public CompositeOrSpec(List<Spec> specs)
        {
            this.Specs = specs;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            bool satisfiesOneSpecs = false;
            foreach (Spec spec in Specs)
                satisfiesOneSpecs |= spec.IsSatisfiedBy(product);
            return satisfiesOneSpecs;
        }
    }
}
