using System;
using System.IO;
using System.Xml.Serialization;
using Debug = UnityEngine.Debug;

namespace DaylightClassic.Options
{
    public class Options
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

        [Checkbox("Classic stock LUTs", "DaylightClassic", "ReplaceLuts")]
        public bool stockLuts { set; get; }
        [Checkbox("Classic sunlight color", "DaylightClassic", "ReplaceSunlightColor")]
        public bool sunlightColor { set; get; }
        [Checkbox("Classic sunlight intensity", "DaylightClassic", "ReplaceSunlightIntensity")]
        public bool sunlightIntensity { set; get; }
        [Checkbox("Classic fog effect if day/night cycle is disabled", "DaylightClassic", "ReplaceFogEffect")]
        public bool fogEffect { set; get; }
        [Checkbox("Classic sun position (not applicable to Boreal biome yet)", "DaylightClassic", "ReplaceLatLong")]
        public bool sunPosition { set; get; }
        [Checkbox("[Not implemented yet] Classic fog color for AD fog & lighting effect")]
        public bool fogColor { set; get; }
    }

    public static class OptionsHolder
    {
        public static Options Options = new Options();
    }

    public static class OptionsLoader
    {
        private const string FileName = "CSL-DaylightClassic.xml";

        public static void LoadOptions()
        {
            try
            {
                try
                {
                    var xmlSerializer = new XmlSerializer(typeof(Options));
                    using (var streamReader = new StreamReader(FileName))
                    {
                        OptionsHolder.Options = (Options)xmlSerializer.Deserialize(streamReader);
                    }
                }
                catch (FileNotFoundException)
                {
                    // No options file yet
                }
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Unexpected {0} while loading options: {1}\n{2}",
                    e.GetType().Name, e.Message, e.StackTrace);
            }
        }

        public static void SaveOptions()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(Options));
                using (var streamWriter = new StreamWriter(FileName))
                {
                    xmlSerializer.Serialize(streamWriter, OptionsHolder.Options);
                }
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Unexpected {0} while saving options: {1}\n{2}",
                    e.GetType().Name, e.Message, e.StackTrace);
            }
        }
    }
}