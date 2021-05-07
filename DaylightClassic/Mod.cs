﻿using System;
using System.Linq;
using ColossalFramework.UI;
using DaylightClassic.OptionsFramework.Extensions;
using DaylightClassic.TranslationFramework;
using ICities;

namespace DaylightClassic
{
    public class Mod : IUserMod
    {
        private const string Version = "1.12.2";
        
        private static UICheckBox[] _checkBoxes;
        private static readonly Translation translation = new Translation();

        public string Name => "Daylight Classic";
        public string Description => $"{translation.GetTranslation("DC_DESCRIPTION")}, version {Version}";

        public void OnSettingsUI(UIHelperBase helper)
        {
            var components =  helper.AddOptionsGroup<Options>(s => translation.GetTranslation(s));
            _checkBoxes = components.OfType<UICheckBox>().ToArray();
        }

        public static void AllToClassic()
        {
            foreach (var uiCheckBox in _checkBoxes)
            {
                uiCheckBox.isChecked = true;
            }
        }

        public static void AllToAfterDark()
        {
            foreach (var uiCheckBox in _checkBoxes)
            {
                uiCheckBox.isChecked = false;
            }
        }
    }
}
