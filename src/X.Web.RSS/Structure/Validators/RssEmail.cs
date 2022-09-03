using System.Xml.Serialization;

namespace X.Web.RSS.Structure.Validators;

public class RssEmail
{
    public RssEmail()
    {
    }

    public RssEmail(string email)
    {
        Email = email;
    }

    [XmlText]
    public string Email { get; set; }
}