using ICities;

namespace DaylightClassic
{
    public class Mod : IUserMod
    {
        public string Name => "Daylight Classic";

        public string Description => "Brings back original daylight color from pre-After Dark days";

        public void OnSettingsUI(UIHelperBase helper)
        {
            Options.Util.AddOptionsGroup(helper, "Daylight Classic Options");
        }
    }
}
