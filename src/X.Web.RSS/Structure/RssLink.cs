using System.Xml.Serialization;
using JetBrains.Annotations;
using X.Web.RSS.Enumerators;
using X.Web.RSS.Validators;

namespace X.Web.RSS.Structure;

/// <summary>
/// &lt;atom:link href = "http://bash.org.ru/rss/" rel = "self" type = "application/rss+xml" /&gt;
/// </summary>
[PublicAPI]
public record RssLink
{
    private string _href;
    private UriValidator _uriValidator;

    public RssLink()
    {
        _uriValidator = new UriValidator();

        Type = "application/rss+xml";
        Rel = Rel.self;
        _href = "";
    }

    public RssLink(string url)
        : this()
    {
        _uriValidator.Validate(url);
        _href = url;
    }

    [XmlAttribute("rel")]
    public Rel Rel { get; set; }

    [XmlAttribute("type")]
    public string Type { get; set; }

    [XmlAttribute("href")]
    public string Href
    {
        get => _href;
        set
        {
            _uriValidator.Validate(value);
            
            _href = value;
        }
    }
}