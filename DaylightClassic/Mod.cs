using System.Linq;
using ColossalFramework.UI;
using DaylightClassic.OptionsFramework.Extensions;
using DaylightClassic.TranslationFramework;
using ICities;

namespace DaylightClassic
{
    public class Mod : IUserMod
    {
        public static Translation translation = new Translation();

        public string Name => "Daylight Classic";
        public string Description => translation.GetTranslation("DC_DESCRIPTION");

        public void OnSettingsUI(UIHelperBase helper)
        {
            var components =  helper.AddOptionsGroup<Options>(s => translation.GetTranslation(s));
            var checkBoxes = components.OfType<UICheckBox>().ToArray();
            var group = helper.AddGroup(translation.GetTranslation("DC_ACTIONS_SHORTCUTS"));

            group.AddButton(translation.GetTranslation("DC_ACTION_TO_CLASSIC"), () =>
            {
                foreach (var uiCheckBox in checkBoxes)
                {
                    uiCheckBox.isChecked = true;
                }
            });
            group.AddButton(translation.GetTranslation("DC_ACTION_TO_AD"), () =>
            {
                foreach (var uiCheckBox in checkBoxes)
                {
                    uiCheckBox.isChecked = false;
                }
            });
        }
    }
}
