using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public static class Extensions
    {
        public static Spec ToSpec(this Color color)
            => new ColorSpec(color);

        public static Spec ToSpec(this ProductSize size)
            => new SizeSpec(size);

        public static Spec ToSpec(this Price price)
            => new PriceSpec(price);

        public static Spec Not(this Color color)
            => new NotSpec(color.ToSpec());

        public static Spec Not(this ProductSize size)
            => new NotSpec(size.ToSpec());

        public static Spec Not(this Price price)
            => new NotSpec(price.ToSpec());

        public static Spec And(this Color color, Spec spec)
            => new AndSpec(color.ToSpec(), spec);

        public static Spec And(this ProductSize size, Spec spec)
            => new AndSpec(size.ToSpec(), spec);

        public static Spec And(this Price price, Spec spec)
            => new AndSpec(price.ToSpec(), spec);

        public static Spec Or(this Color color, Spec spec)
            => new OrSpec(color.ToSpec(), spec);

        public static Spec Or(this ProductSize size, Spec spec)
            => new OrSpec(size.ToSpec(), spec);

        public static Spec Or(this Price price, Spec spec)
            => new OrSpec(price.ToSpec(), spec);

        public static Spec Below(this Price price)
            => new BelowPriceSpec(price);

        public static Spec And(this Spec spec, Spec other)
            => new AndSpec(spec, other);
    }
}
