using System;
using System.Reflection;

namespace DaylightClassic.OptionsFramework.Attibutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class AbstractOptionsAttribute : Attribute
    {
        protected AbstractOptionsAttribute(string description, string group, string actionClass, string actionMethod)
        {
            Description = description;
            Group = group;
            ActionClass = actionClass;
            ActionMethod = actionMethod;
        }

        public string Description { get; }
        public string Group { get; }

        public Action<T> Action<T>()
        {
            if (ActionClass == null || ActionMethod == null)
            {
                return s => { };
            }
            var method = Util.FindTypeInCurrentAssembly(ActionClass).GetMethod(ActionMethod, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (method == null)
            {
                throw new Exception($"A static method {ActionMethod} of class {ActionClass} wasn't found!");
            }
            return s =>
            {
                method.Invoke(null, new object[] { s });
            };
        }

        public Action Action()
        {
            if (ActionClass == null || ActionMethod == null)
            {
                return () => { };
            }
            var method = Util.FindTypeInCurrentAssembly(ActionClass).GetMethod(ActionMethod, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (method == null)
            {
                throw new Exception($"A static method {ActionMethod} of class {ActionClass} wasn't found!");
            }
            return () =>
            {
                method.Invoke(null, new object[] { });
            };
        }

        private string ActionClass { get; }

        private string ActionMethod { get; }


    }
}