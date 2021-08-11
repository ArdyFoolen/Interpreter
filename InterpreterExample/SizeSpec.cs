using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class SizeSpec : Spec
    {
        public ProductSize Size { get; private set; }
        public SizeSpec(ProductSize size)
        {
            this.Size = size;
        }

        public override bool IsSatisfiedBy(Product product)
            => product.Size == Size;
    }
}
