using System.Xml.Serialization;

namespace RSS.Enumerators
{
    public enum Protocol
    {
        [XmlEnum("soap")]
        Soap, // "soap",
        [XmlEnum("xmlrpc")]
        XmlRpc // "xml-rpc"
    }
}