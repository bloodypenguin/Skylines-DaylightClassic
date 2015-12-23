using DaylightClassic.Options;
using ICities;

namespace DaylightClassic
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            DaylightClassic.Reset();
            DaylightClassic.ReplaceFogEffect(OptionsHolder.Options.fogEffect);
            DaylightClassic.ReplaceSunlightColor(OptionsHolder.Options.sunlightColor);
            DaylightClassic.ReplaceSunlightIntensity(OptionsHolder.Options.sunlightIntensity);
            DaylightClassic.ReplaceLuts(OptionsHolder.Options.stockLuts);
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            DaylightClassic.ReplaceFogEffect(false);
            DaylightClassic.ReplaceSunlightColor(false);
            DaylightClassic.ReplaceSunlightIntensity(false);
            DaylightClassic.ReplaceLuts(false);
            DaylightClassic.Reset();
        }
    }
}