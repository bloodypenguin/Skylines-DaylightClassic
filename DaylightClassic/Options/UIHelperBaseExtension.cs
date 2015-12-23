using System;
using ColossalFramework.UI;
using ICities;

namespace DaylightClassic.Options
{
    public static class UIHelperBaseExtension
    {
        public static void AddCheckbox(this UIHelperBase group, string text, string propertyName, Action<bool>  action)
        {
            var property = typeof (Options).GetProperty(propertyName);
            var checkBox = (UICheckBox) group.AddCheckbox(text, (bool)property.GetValue(OptionsHolder.Options, null),
                b =>
                {
                    property.SetValue(OptionsHolder.Options, b, null);
                    OptionsLoader.SaveOptions();
                });
            checkBox.eventCheckChanged += (a, b) =>
            {
                action.Invoke(b);
            };
        } 
    }
}