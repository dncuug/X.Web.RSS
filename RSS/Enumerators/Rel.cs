using System.Xml.Serialization;

namespace RSS.Enumerators
{
    public enum Rel
    {
        [XmlEnum("self")]
        Self,
        [XmlEnum("alternate")]
        Alternate
    }
}