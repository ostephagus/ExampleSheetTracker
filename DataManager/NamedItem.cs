using System.Xml.Serialization;

namespace DataManager
{
    public abstract class NamedItem
    {
        [XmlIgnore]
        public abstract string Name { get; set; }
    }
}
