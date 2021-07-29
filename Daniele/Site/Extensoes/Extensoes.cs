using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Site.Extensoes
{
    public static class Extensoes
    {
        public static string GetDefaultValue(this Enum enumerado)
        {
            DefaultValueAttribute[] attributes = (DefaultValueAttribute[])enumerado.GetType().GetCustomAttributes(typeof(DefaultValueAttribute), false);
            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Value.ToString();
            }
            else
            {
                return default;
            }
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}