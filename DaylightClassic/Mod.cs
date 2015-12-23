using System.Linq;
using DaylightClassic.Options;
using ICities;

namespace DaylightClassic
{
    public class Mod : IUserMod
    {
        public string Name => "Daylight Classic";

        public string Description => "Brings back original daylight color from pre-After Dark days";

        public void OnSettingsUI(UIHelperBase helper)
        {
            var group = helper.AddGroup("Daylight Classic Options");
            var properties = typeof(Options.Options).GetProperties();
            foreach (var name in from property in properties select property.Name)
            {
                var description = OptionsHolder.Options.GetPropertyDescription(name);
                group.AddCheckbox(description, name, OptionsHolder.Options.GetPropertyAction(name));

            }
        }
    }
}
