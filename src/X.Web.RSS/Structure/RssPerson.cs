using System.Xml.Serialization;

namespace X.Web.RSS.Structure;

public class RssPerson
{
    public RssPerson()
    {
        Value = "";
    }

    public RssPerson(string name, string email)
    {
        Value = $"{email} ({name})";
    }

    [XmlText]
    public string Value { get; set; }
}