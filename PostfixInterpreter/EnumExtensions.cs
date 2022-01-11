using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public static class EnumExtensions
    {
        public static bool IsPartOf<TEnum>(this string name)
            where TEnum : struct, Enum
            => Enum.GetNames(typeof(TEnum)).Contains(name) ||
                Enum.GetValues<TEnum>().Any(a => a.HasAttributeName(name));

        public static bool HasAttributeName<TEnum>(this TEnum @enum, string name)
            where TEnum : struct, Enum
        {
            var attribute = @enum.GetAttribute<DisplayAttribute>();
            return name.Equals(attribute?.Name);
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }
}
