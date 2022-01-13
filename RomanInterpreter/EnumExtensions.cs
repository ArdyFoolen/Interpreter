using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
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

        public static TEnum ToEnum<TEnum>(this string name)
            where TEnum : struct, Enum
        {
            if (Enum.TryParse(name, out TEnum value))
                return value;

            throw new EnumNotExistsException(typeof(TEnum), name);
        }

        public static TEnum ToEnum<TEnum>(this char token)
            where TEnum : struct, Enum
            => token.ToString().ToEnum<TEnum>();

        internal static RomanEnum ToEnum(this RomanFiveEnum @enum)
            => Enum.GetName(typeof(RomanFiveEnum), @enum).ToEnum<RomanEnum>();

        internal static bool IsSpecificRoman<TEnum>(this RomanEnum @enum)
            where TEnum: struct, Enum
            => Enum.GetNames(typeof(TEnum))
                .Any(a => a.Equals(Enum.GetName(typeof(TEnum), @enum)));

        internal static RomanEnum Minus(this RomanEnum @enum)
        {
            var index = @enum.GetIndex();
            var name = GetNameFor<RomanEnum>(index - 1);

            return name.ToEnum<RomanEnum>();
        }

        public static string GetNameFor<TEnum>(int index)
            where TEnum : struct, Enum
            => Enum.GetNames(typeof(TEnum))
                .Select((s, i) => new { name = s, index = i })
                .Where(w => w.index == (index))
                .Select(obj => obj.name)
                .FirstOrDefault();

        public static int GetIndex<TEnum>(this TEnum @enum)
            where TEnum : struct, Enum
            => Enum.GetNames(typeof(TEnum))
                .Select((s, i) => new { name = s, index = i })
                .Where(w => w.name.Equals(Enum.GetName<TEnum>(@enum)))
                .Select(obj => obj.index)
                .FirstOrDefault();
    }
}
