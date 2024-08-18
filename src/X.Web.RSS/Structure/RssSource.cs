using System.Xml.Serialization;
using JetBrains.Annotations;
using X.Web.RSS.Validators;

namespace X.Web.RSS.Structure;

/// <summary>
/// Its value is the name of the RSS channel that the item came from, derived from its 'title'.
///   The purpose of this element is to propagate credit for links, to publicize the sources 
///   of news items. It can be used in the Post command of an aggregator. It should be generated
///   automatically when forwarding an item from an aggregator to a weblog authoring tool.
/// </summary>
[PublicAPI]
public record RssSource
{
    private string _internalUrl;

    public RssSource()
    {
        Url = "";
    }

    [XmlAttribute("url")]
    public string Url
    {
        get => _internalUrl;
        set
        {
            new UriValidator().Validate(value);
            
            _internalUrl = value;
        }
    }
}