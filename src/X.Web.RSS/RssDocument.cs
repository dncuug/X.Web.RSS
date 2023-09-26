using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using X.Web.RSS.Structure;

namespace X.Web.RSS;

/// <summary>
/// RSS is a Web content syndication format.
/// Its name is an acronym for Really Simple Syndication.
/// RSS is a dialect of XML. All RSS files must conform to the XML 1.0 specification, 
/// as published on the World Wide Web Consortium (W3C) website.
/// http://www.w3.org/TR/REC-xml
/// </summary>
[XmlRoot("rss")]
public class RssDocument : IRssDocument
{
    public const string MimeType = "application/rss+xml";

    public RssDocument()
    {
        Channel = new RssChannel();
        Version = "2.0";
    }

    /// <summary>
    /// Gets or sets subordinate to the 'rss' element is a single 'channel' element, 
    /// which contains information about the channel (metadata) and its contents.
    /// </summary>
    [XmlElement("channel")]
    public RssChannel Channel { get; set; }
    
    /// <summary>
    /// Gets or sets subordinate to the 'rss' element is a single 'channel' element, 
    /// which contains information about the channel (metadata) and its contents.
    /// </summary>
    IRssChannel IRssDocument.Channel
    {
        get => Channel;
        set => Channel = (RssChannel)value;
    }

    /// <summary>
    /// Gets or sets at the top level, a RSS document is a 'rss' element, 
    /// with a mandatory attribute called version, that specifies 
    /// the version of RSS that the document conforms to.
    /// </summary>
    [XmlAttribute("version")]
    public string Version { get; set; }

    /// <summary>
    /// Render RSS to XML
    /// </summary>
    /// <returns></returns>
    [Obsolete("Use RssSerializer")]
    public string ToXml()
    {
        IRssSerializer serializer = new RssSerializer();
        
        return serializer.Serialize(this);
    }

    /// <summary>
    /// Loads RSS document from specified URL
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>RssDocument</returns>
    [Obsolete("Use RssStreamHandler")]
    public static async Task<RssDocument?> Load(Uri url)
    {
        var handler = new RssStreamHandler();
        
        return await handler.ReadFromUrlAsync(url) as RssDocument;
    }

    [Obsolete("Use RssStreamHandler")]
    public static RssDocument? Load(string xml)
    {
        IRssSerializer serializer = new RssSerializer();
        
        return serializer.Deserialize(xml) as RssDocument;
    }
}