using DaylightClassic.OptionsFramework.Attibutes;

namespace DaylightClassic
{
    [Options("CSL-DaylightClassic", "CSL-DaylightClassic")]
    public class Options
    {
        private const string BASIC = "DC_OPTIONS_BASIC";
        private const string ADVANCED = "DC_OPTIONS_ADVANCED";

        public Options()
        {
            stockLuts = true;
            sunlightColor = true;
            sunlightIntensity = true;
            sunPosition = true;
            fogColor = true;
            fogEffect = true;
        }

        [Checkbox("DC_OPTION_LUTS", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLuts))]
        public bool stockLuts { set; get; }
        [Checkbox("DC_OPTION_SUN_COLOR", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightColor))]
        public bool sunlightColor { set; get; }
        [Checkbox("DC_OPTION_SUN_INTENSITY", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightIntensity))]
        public bool sunlightIntensity { set; get; }
        [Checkbox("DC_OPTION_SUN_POSITION", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLatLong))]
        public bool sunPosition { set; get; }

        [Checkbox("DC_OPTION_FOG_EFFECT", ADVANCED, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogEffect))]
        public bool fogEffect { set; get; }
        [Checkbox("DC_OPTION_FOG_COLOR", ADVANCED, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogColor))]
        public bool fogColor { set; get; }
    }
}