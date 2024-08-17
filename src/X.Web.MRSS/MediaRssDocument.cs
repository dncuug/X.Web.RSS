using System.Xml.Serialization;
using X.Web.RSS;

namespace X.Web.MRSS;

public class MediaRssDocument : RssDocument
{
    public MediaRssDocument()
    {
        Channel = new MediaRssChannel();
    }

    /// <summary>
    ///   Gets or sets subordinate to the 'rss' element is a single 'channel' element, 
    ///   which contains information about the channel (metadata) and its contents.
    /// </summary>
    [XmlElement("channel")]
    public new MediaRssChannel Channel { get; set; }
}