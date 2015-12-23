using System;

namespace DaylightClassic.Options
{
    public static class Util
    {
        public static string GetPropertyDescription<T>(this T value, string propertyName)
        {
            var fi = value.GetType().GetProperty(propertyName);
            var attributes =
         (CheckboxAttribute[])fi.GetCustomAttributes(typeof(CheckboxAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            return propertyName;
        }

        public static Action<bool> GetPropertyAction<T>(this T value, string propertyName)
        {
            var fi = value.GetType().GetProperty(propertyName);
            var attributes =
         (CheckboxAttribute[])fi.GetCustomAttributes(typeof(CheckboxAttribute), false);

            if (attributes == null || attributes.Length != 1 || attributes[0].method == null)
                return b => { };

            var method = attributes[0].method;
            return b =>
            {
                method.Invoke(null, new object[] {b});
            };
                

        }
    }
}