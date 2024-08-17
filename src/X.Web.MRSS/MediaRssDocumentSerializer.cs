using System.Text;
using System.Xml.Serialization;
using JetBrains.Annotations;
using X.Web.RSS;

namespace X.Web.MRSS;

[PublicAPI]
public class MediaRssDocumentSerializer : IDocumentSerializer<MediaRssDocument>
{
    public MediaRssDocument? Deserialize(string xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
        {
            return null;
        }

        var writer = new StreamWriter(new MemoryStream());
        writer.Write(xml);
        writer.Flush();
        writer.BaseStream.Position = 0;

        var xsn = new XmlSerializerNamespaces();
        xsn.Add("atom", "http://www.w3.org/2005/Atom");
        xsn.Add("dc", "http://purl.org/dc/elements/1.1/");
        xsn.Add("content", "http://purl.org/rss/1.0/modules/content/");

        var serializer = new XmlSerializer(typeof(MediaRssDocument));
        var instance = (MediaRssDocument)serializer.Deserialize(writer.BaseStream);

        return instance;
    }


    public string Serialize(MediaRssDocument document)
    {
        var xsn = new XmlSerializerNamespaces();
        xsn.Add("atom", "http://www.w3.org/2005/Atom");
        xsn.Add("dc", "http://purl.org/dc/elements/1.1/");
        xsn.Add("content", "http://purl.org/rss/1.0/modules/content/");

        var serializer = new XmlSerializer(document.GetType());

        var memoryStream = new MemoryStream();
        serializer.Serialize(memoryStream, document, xsn);

        var xml = String.Empty;

        if (memoryStream.TryGetBuffer(out var buffer))
        {
            if (buffer.Array != null)
            {
                xml = Encoding.UTF8.GetString(buffer.Array).Trim('\0');
            }
        }

        return xml;
    }
}