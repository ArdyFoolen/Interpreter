using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class CompositeAndSpec : Spec
    {
        public List<Spec> Specs { get; private set; }

        public CompositeAndSpec(List<Spec> specs)
        {
            this.Specs = specs;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            bool satisfiesAllSpecs = true;
            foreach (Spec spec in Specs)
                satisfiesAllSpecs &= spec.IsSatisfiedBy(product);
            return satisfiesAllSpecs;
        }
    }
}
