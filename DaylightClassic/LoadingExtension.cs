using DaylightClassic.Options;
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
            DaylightClassic.ReplaceFogEffect(OptionsHolder.Options.fogEffect);
            DaylightClassic.ReplaceSunlightColor(OptionsHolder.Options.sunlightColor);
            DaylightClassic.ReplaceSunlightIntensity(OptionsHolder.Options.sunlightIntensity);
            DaylightClassic.ReplaceLuts(OptionsHolder.Options.stockLuts);
            DaylightClassic.ReplaceLatLong(OptionsHolder.Options.sunPosition);
            DaylightClassic.ReplaceFogColor(OptionsHolder.Options.fogColor);
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