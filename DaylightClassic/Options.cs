using System.Xml.Serialization;
using DaylightClassic.OptionsFramework;

namespace DaylightClassic
{
    public class Options : IModOptions
    {
        public Options()
        {
            stockLuts = true;
            sunlightColor = true;
            sunlightIntensity = true;
            sunPosition = true;
            fogColor = true;
            fogEffect = true;
        }

        [Checkbox("Classic stock LUTs", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLuts))]
        public bool stockLuts { set; get; }
        [Checkbox("Classic sunlight color", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightColor))]
        public bool sunlightColor { set; get; }
        [Checkbox("Classic sunlight intensity", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceSunlightIntensity))]
        public bool sunlightIntensity { set; get; }
        [Checkbox("Classic fog effect if day/night cycle is disabled", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogEffect))]
        public bool fogEffect { set; get; }
        [Checkbox("Classic sun position (N/A for Boreal when classic fog enabled)", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceLatLong))]
        public bool sunPosition { set; get; }
        [Checkbox("Classic fog color for post-AD fog effect", nameof(DaylightClassic), nameof(DaylightClassic.ReplaceFogColor))]
        public bool fogColor { set; get; }

        [XmlIgnore]
        public string FileName => "CSL-DaylightClassic.xml";
    }
}