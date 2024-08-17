using System.Xml.Serialization;
using X.Web.RSS.Structure;

namespace X.Web.MRSS;

public class MediaRssChannel : RssChannel
{
    public MediaRssChannel()
    {
        Items = new List<MediaRssItem>();
    }
    
    /// <summary>
    ///   Gets or sets a channel may contain any number of 'item's. An item may represent 
    ///   a "story" -- much like a story in a newspaper or magazine; if so its
    ///   description is a synopsis of the story, and the link points to the full 
    ///   story. An item may also be complete in itself, if so, the description 
    ///   contains the text (entity-encoded HTML is allowed; see examples
    ///   http://www.rssboard.org/rss-encoding-examples), and the link and title may 
    ///   be omitted. All elements of an item are optional, however at least one of 
    ///   title or description must be present.
    /// </summary>
    [XmlElement("Items", Type = typeof(MediaRssItem))]
    public new List<MediaRssItem> Items { get; set; }
}