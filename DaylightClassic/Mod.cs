using DaylightClassic.Options;
using ICities;

namespace DaylightClassic
{
    public class Mod : IUserMod
    {
        private static bool _optionsLoaded;


        public string Name
        {
            get
            {
                if (!_optionsLoaded)
                {
                    OptionsLoader.LoadOptions();
                    _optionsLoaded = true;
                }
                return "Daylight Classic";
            }
        }

        public string Description => "Brings back original daylight color from pre-After Dark days";

        public void OnSettingsUI(UIHelperBase helper)
        {
            Options.Util.AddOptionsGroup(helper, "Daylight Classic Options");
        }
    }
}
