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
            DaylightClassic.Initialize();
            DaylightClassic.ReplaceFogEffect(OptionsWrapper<Options>.Options.fogEffect);
            DaylightClassic.ReplaceSunlightColor(OptionsWrapper<Options>.Options.sunlightColor);
            DaylightClassic.ReplaceSunlightIntensity(OptionsWrapper<Options>.Options.sunlightIntensity);
            DaylightClassic.ReplaceLuts(OptionsWrapper<Options>.Options.stockLuts);
            DaylightClassic.ReplaceLatLong(OptionsWrapper<Options>.Options.sunPosition);
            DaylightClassic.ReplaceFogColor(OptionsWrapper<Options>.Options.fogColor);
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            DaylightClassic.ReplaceFogEffect(false);
            DaylightClassic.ReplaceSunlightColor(false);
            DaylightClassic.ReplaceSunlightIntensity(false);
            DaylightClassic.ReplaceLuts(false);
            DaylightClassic.ReplaceLatLong(false);
            DaylightClassic.ReplaceFogColor(false);
            DaylightClassic.Reset();
        }
    }
}