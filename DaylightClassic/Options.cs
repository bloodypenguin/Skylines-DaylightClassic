using System.Xml.Serialization;
using DaylightClassic.OptionsFramework;

namespace DaylightClassic
{
    public class Options : IModOptions
    {
        private const string BASIC = "Basic features (recommened for everyone)";
        private const string ADVANCED = "Advanced features (side effects possible)";

        public Options()
        {
            stockLuts = true;
            sunlightColor = true;
            sunlightIntensity = true;
            sunPosition = true;
            fogColor = false;
            fogEffect = false;
        }

        [Checkbox("Classic stock LUTs", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLuts), BASIC)]
        public bool stockLuts { set; get; }
        [Checkbox("Classic sunlight color", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightColor), BASIC)]
        public bool sunlightColor { set; get; }
        [Checkbox("Classic sunlight intensity", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightIntensity), BASIC)]
        public bool sunlightIntensity { set; get; }
        [Checkbox("Classic sun position (N/A for Boreal when classic fog effect enabled)", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLatLong), BASIC)]
        public bool sunPosition { set; get; }

        [Checkbox("Classic fog effect (works only if day/night cycle is disabled)", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogEffect), ADVANCED)]
        public bool fogEffect { set; get; }
        [Checkbox("Classic fog color for AD fog effect (side effect: makes sunsets less colorful)", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogColor), ADVANCED)]
        public bool fogColor { set; get; }


        [XmlIgnore]
        public string FileName => "CSL-DaylightClassic.xml";
    }
}