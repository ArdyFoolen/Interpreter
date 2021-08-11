using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class PriceSpec : Spec
    {
        public Price Price { get; private set; }

        public PriceSpec(Price price)
        {
            this.Price = price;
        }

        public override bool IsSatisfiedBy(Product product)
            => product.Price == Price;
    }
}
