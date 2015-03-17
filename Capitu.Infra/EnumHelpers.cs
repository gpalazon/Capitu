using System;
using System.ComponentModel;

namespace Capitu.Infra
{
    public static class EnumHelpers
    {
        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static int GetValueByDescription<T>(this string obj)
        {
            var type = typeof(T);

            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute =
                    Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == obj)
                        return (int)field.GetValue(null);
                }
                else
                {
                    if (field.Name == obj)
                        return (int)field.GetValue(null);
                }
            }

            return 0;
        }
    }
}
