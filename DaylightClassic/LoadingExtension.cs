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
            DaylightClassic.ReplaceFogEffect(OptionsWrapper<Options>.Options.FogEffect);
            DaylightClassic.ReplaceSunlightColor(OptionsWrapper<Options>.Options.SunlightColor);
            DaylightClassic.ReplaceSunlightIntensity(OptionsWrapper<Options>.Options.SunlightIntensity);
            DaylightClassic.ReplaceLuts(OptionsWrapper<Options>.Options.StockLuts);
            DaylightClassic.ReplaceLatLong(OptionsWrapper<Options>.Options.SunPosition);
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            DaylightClassic.ReplaceFogEffect(false);
            DaylightClassic.ReplaceSunlightColor(false);
            DaylightClassic.ReplaceSunlightIntensity(false);
            DaylightClassic.ReplaceLuts(false);
            DaylightClassic.ReplaceLatLong(false);
            DaylightClassic.Reset();
        }
    }
}