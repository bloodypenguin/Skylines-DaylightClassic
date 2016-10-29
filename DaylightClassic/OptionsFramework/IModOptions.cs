using System.Xml.Serialization;

namespace DaylightClassic.OptionsFramework
{
    public interface IModOptions
    {
        [XmlIgnore]
        string FileName
        {
            get;
        }
    }
}