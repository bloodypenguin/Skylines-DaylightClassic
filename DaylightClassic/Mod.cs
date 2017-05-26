using System.Linq;
using ColossalFramework.UI;
using DaylightClassic.OptionsFramework.Extensions;
using DaylightClassic.TranslationFramework;
using ICities;

namespace DaylightClassic
{
    public class Mod : IUserMod
    {
        private static UICheckBox[] checkBoxes;
        private static readonly Translation translation = new Translation();

        public string Name => "Daylight Classic";
        public string Description => translation.GetTranslation("DC_DESCRIPTION");

        public void OnSettingsUI(UIHelperBase helper)
        {
            var components =  helper.AddOptionsGroup<Options>(s => translation.GetTranslation(s));
            checkBoxes = components.OfType<UICheckBox>().ToArray();
        }

        public static void AllToClassic()
        {
            foreach (var uiCheckBox in checkBoxes)
            {
                uiCheckBox.isChecked = true;
            }
        }

        public static void AllToAfterDark()
        {
            foreach (var uiCheckBox in checkBoxes)
            {
                uiCheckBox.isChecked = false;
            }
        }
    }
}
