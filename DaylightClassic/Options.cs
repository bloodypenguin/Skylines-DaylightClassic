using DaylightClassic.OptionsFramework.Attibutes;

namespace DaylightClassic
{
    [Options("CSL-DaylightClassic", "CSL-DaylightClassic")]
    public class Options
    {
        private const string BASIC = "Basic features (recommened for everyone)";
        private const string ADVANCED = "Advanced features (side effects possible)";

        public Options()
        {
            stockLuts = true;
            sunlightColor = true;
            sunlightIntensity = true;
            sunPosition = true;
            fogColor = true;
            fogEffect = true;
        }

        [Checkbox("Classic stock LUTs", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLuts))]
        public bool stockLuts { set; get; }
        [Checkbox("Classic sunlight color", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightColor))]
        public bool sunlightColor { set; get; }
        [Checkbox("Classic sunlight intensity", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightIntensity))]
        public bool sunlightIntensity { set; get; }
        [Checkbox("Classic sun position (N/A for Boreal when classic fog effect enabled)", BASIC, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLatLong))]
        public bool sunPosition { set; get; }

        [Checkbox("Classic fog effect (works only if day/night cycle is disabled)", ADVANCED, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogEffect))]
        public bool fogEffect { set; get; }
        [Checkbox("Classic fog color for AD fog effect (side effect: makes sunsets less colorful)", ADVANCED, nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogColor))]
        public bool fogColor { set; get; }
    }
}