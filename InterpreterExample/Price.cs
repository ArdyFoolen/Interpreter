using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterExample
{
    public class Price
    {
        public float Value { get; private set; }
        public Price(float value)
        {
            this.Value = value;
        }

        public static explicit operator float(Price p) => p.Value;
        public static implicit operator Price(float f) => new Price(f);

        public static bool operator <(Price a, Price b)
            => a.Value < b.Value;
        public static bool operator >(Price a, Price b)
            => a.Value > b.Value;
        public static bool operator <=(Price a, Price b)
            => a.Value <= b.Value;
        public static bool operator >=(Price a, Price b)
            => a.Value >= b.Value;
        public static bool operator ==(Price a, Price b)
            => a.Value == b.Value;
        public static bool operator !=(Price a, Price b)
            => a.Value != b.Value;

        public override bool Equals(object obj)
            => Value.Equals(obj);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value.ToString();
    }
}
