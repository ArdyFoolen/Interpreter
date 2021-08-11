using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class BelowPriceSpec : Spec
    {
        public Price Price { get; private set; }

        public BelowPriceSpec(Price price)
        {
            this.Price = price;
        }

        public override bool IsSatisfiedBy(Product product)
            => product.Price < Price;
    }
}
