using DaylightClassic.OptionsFramework;
using DaylightClassic.TranslationFramework;
using ICities;
using UnityEngine;

namespace DaylightClassic
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            DaylightClassic.SetUp();
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            DaylightClassic.CleanUp();
        }
    }
}