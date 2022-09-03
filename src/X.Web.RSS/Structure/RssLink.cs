using System.Xml.Serialization;
using JetBrains.Annotations;
using X.Web.RSS.Enumerators;
using X.Web.RSS.Structure.Validators;

namespace X.Web.RSS.Structure;

/// <summary>
/// &lt;atom:link href = "http://bash.org.ru/rss/" rel = "self" type = "application/rss+xml" /&gt;
/// </summary>
[PublicAPI]
public class RssLink
{
    public RssLink()
    {
        Type = "application/rss+xml";
        Rel = Rel.self;
    }

    public RssLink(string url)
        : this()
    {
        InternalHref = url;
    }

    [XmlIgnore]
    public RssUrl Href => new RssUrl(InternalHref);

    [XmlAttribute("rel")]
    public Rel Rel { get; set; }

    [XmlAttribute("type")]
    public string Type { get; set; }

    [XmlAttribute("href")]
    public string InternalHref { get; set; }
}