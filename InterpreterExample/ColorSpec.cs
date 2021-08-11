using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class ColorSpec : Spec
    {
        public Color Color { get; private set; }

        public ColorSpec(Color color)
        {
            this.Color = color;
        }

        public override bool IsSatisfiedBy(Product product)
            => product.Color.Equals(Color);
    }
}
