using System;
using System.Linq;

namespace DaylightClassic.OptionsFramework
{
    internal class Util
    {
        public static Type FindTypeInCurrentAssembly(string className)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetTypes().Any(t => t == typeof(Util)));
            try
            {
                var types = assembly.GetTypes();
                foreach (var type in types.Where(type => type.Name == className))
                {
                    return type;
                }
            }
            catch(Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
            return null;
        }
    }
}