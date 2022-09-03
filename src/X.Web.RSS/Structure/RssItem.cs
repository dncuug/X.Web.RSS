using System;
using System.Xml.Serialization;
using X.Web.RSS.Extensions;
using X.Web.RSS.Structure.Validators;

namespace X.Web.RSS.Structure;

/// <summary>
/// A channel may contain any number of 'item's. An item may represent 
///   a "story" -- much like a story in a newspaper or magazine; if so its
///   description is a synopsis of the story, and the link points to the full 
///   story. An item may also be complete in itself, if so, the description 
///   contains the text (entity-encoded HTML is allowed; see examples
///   http://www.rssboard.org/rss-encoding-examples), and the link and title may 
///   be omitted. All elements of an item are optional, however at least one of 
///   title or description must be present.
/// </summary>
public class RssItem
{
    /// <summary>
    ///   Gets or sets email address of the author of the item.
    /// </summary>
    [XmlElement("author")]
    public RssEmail Author { get; set; }

    /// <summary>
    ///   Gets or sets includes the item in one or more categories.
    /// </summary>
    [XmlElement("category")]
    public RssCategory Category { get; set; }

    /// <summary>
    ///   Gets or sets URL of a page for comments relating to the item.
    /// </summary>
    [XmlElement("comments")]
    public RssUrl Comments { get; set; }

    /// <summary>
    ///   Gets or sets the item synopsis.
    /// </summary>
    /// <example>
    ///   Some of the most heated chatter at the Venice Film Festival this 
    ///   week was about the way that the arrival of the stars at the Palazzo 
    ///   del Cinema was being staged.
    /// </example>
    [XmlElement("description")]
    public string Description { get; set; }

    /// <summary>
    ///   Gets or sets describes a media object that is attached to the item.
    /// </summary>
    [XmlElement("enclosure")]
    public RssEnclosure Enclosure { get; set; }

    /// <summary>
    ///   Gets or sets a string that uniquely identifies the item.
    /// </summary>
    [XmlElement("guid")]
    public RssGuid Guid { get; set; }

    /// <summary>
    ///   Gets or sets the URL of the item.
    /// </summary>
    /// <example>
    ///   http://nytimes.com/2004/12/07FEST.html
    /// </example>
    [XmlElement("link")]
    public RssUrl Link { get; set; }

    /// <summary>
    ///   Gets or sets indicates when the item was published.
    /// </summary>
    [XmlIgnore]
    public DateTime? PubDate { get; set; }

    /// <summary>
    ///   Gets or sets the RSS channel that the item came from
    /// </summary>
    [XmlElement("source")]
    public RssSource Source { get; set; }

    /// <summary>
    ///   Gets or sets the title of the item.
    /// </summary>
    /// <example>
    ///   Venice Film Festival Tries to Quit Sinking
    /// </example>
    [XmlElement("title")]
    public string Title { get; set; }

    [XmlElement("pubDate")]
    public string InternalPubDate
    {
        get => PubDate?.ToRFC822Date() ?? string.Empty;
        set => PubDate = value?.FromRFC822Date();
    }
}