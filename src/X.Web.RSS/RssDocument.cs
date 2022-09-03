using System;
using System.IO;
using System.Net;
using System.Text;
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
public class RssDocument
{
    public const string MimeType = "application/rss+xml";

    public RssDocument()
    {
        Channel = new RssChannel();
        Version = "2.0";
    }

    /// <summary>
    ///   Gets or sets subordinate to the 'rss' element is a single 'channel' element, 
    ///   which contains information about the channel (metadata) and its contents.
    /// </summary>
    [XmlElement("channel")]
    public RssChannel Channel { get; set; }

    /// <summary>
    ///   Gets or sets at the top level, a RSS document is a 'rss' element, 
    ///   with a mandatory attribute called version, that specifies 
    ///   the version of RSS that the document conforms to.
    /// </summary>
    [XmlAttribute("version")]
    public string Version { get; set; }

    /// <summary>
    /// Render RSS to XML
    /// </summary>
    /// <returns></returns>
    public string ToXml()
    {
        var ms = new MemoryStream();

        WriteRSS(this, ms);

        //var xml = Encoding.UTF8.GetString(ms.GetBuffer()).Trim('\0');
        var xml = String.Empty;

        if (ms.TryGetBuffer(out var buffer))
        {
            if (buffer.Array != null)
            {
                xml = Encoding.UTF8.GetString(buffer.Array).Trim('\0');
            }
        }

        return xml;
    }

    /// <summary>
    /// Loads the specified URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>RssDocument</returns>
    public static async Task<RssDocument?> Load(Uri url)
    {
        if (WebRequest.Create(url) is HttpWebRequest request)
        {
            var response = await request.GetResponseAsync();

            var encoding = Encoding.ASCII;
            var xml = String.Empty;

            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                using (var reader = new StreamReader(responseStream, encoding))
                {
                    xml = await reader.ReadToEndAsync();
                }
            }

            var rss = Load(xml);

            return rss;
        }

        return null;
    }

    public static RssDocument? Load(string xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
        {
            return null;
        }
        
        var writer = new StreamWriter(new MemoryStream());
        writer.Write(xml);
        writer.Flush();
        writer.BaseStream.Position = 0;

        var instance = Load(writer.BaseStream);
        return instance;
    }

    public static RssDocument Load(Stream source)
    {
        var xsn = new XmlSerializerNamespaces();
        xsn.Add("atom", "http://www.w3.org/2005/Atom");
        xsn.Add("dc", "http://purl.org/dc/elements/1.1/");
        xsn.Add("content", "http://purl.org/rss/1.0/modules/content/");

        var ser = new XmlSerializer(typeof(RssDocument));
        return (RssDocument)ser.Deserialize(source);
    }

    public static void WriteRSS(RssDocument value, Stream destination)
    {
        var xsn = new XmlSerializerNamespaces();
        xsn.Add("atom", "http://www.w3.org/2005/Atom");
        xsn.Add("dc", "http://purl.org/dc/elements/1.1/");
        xsn.Add("content", "http://purl.org/rss/1.0/modules/content/");

        var ser = new XmlSerializer(value.GetType());
        ser.Serialize(destination, value, xsn);
    }
}