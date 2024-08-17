using System.Xml.Serialization;
using X.Web.MRSS.Structure;
using X.Web.RSS;

namespace X.Web.MRSS;

[XmlRoot("rss")]
public record MediaRssDocument : IRssDocument<MediaRssChannel>
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
    public MediaRssChannel Channel { get; set; }

    public string Version { get; set; }
}