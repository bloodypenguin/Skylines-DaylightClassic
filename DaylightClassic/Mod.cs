using System.Collections.Generic;
using System.Linq;
using ColossalFramework.UI;
using DaylightClassic.OptionsFramework;
using ICities;

namespace DaylightClassic
{
    public class Mod : IUserMod
    {
        public string Name => "Daylight Classic";
        public string Description => "Brings back original daylight color from pre-After Dark days";

        public void OnSettingsUI(UIHelperBase helper)
        {
            var components =  helper.AddOptionsGroup<Options>();
            var checkBoxes = components.OfType<UICheckBox>().ToArray();
            var group = helper.AddGroup("Quick selection");

            group.AddButton("All to Classic", () =>
            {
                foreach (var uiCheckBox in checkBoxes)
                {
                    uiCheckBox.isChecked = true;
                }
            });
            group.AddButton("All to After Dark", () =>
            {
                foreach (var uiCheckBox in checkBoxes)
                {
                    uiCheckBox.isChecked = false;
                }
            });
        }
    }
}
