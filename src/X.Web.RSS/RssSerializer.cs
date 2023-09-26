using System;
using System.IO;
using System.Text;

namespace X.Web.RSS;

public interface IRssSerializer
{
    public string Serialize(IRssDocument rss);

    public IRssDocument Deserialize(string xml);
}

public class RssSerializer : IRssSerializer
{
    public string Serialize(IRssDocument rss)
    {
        var stream = new MemoryStream();
        var handler = new RssStreamHandler();

        handler.WriteToStream(rss, stream);

        var buffer = stream.GetBuffer();
        var xml = Encoding.UTF8.GetString(buffer).Trim('\0');
        
        return xml;
    }

    public IRssDocument Deserialize(string xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
        {
            throw new ArgumentException("Empty string");
        }

        var handler = new RssStreamHandler();
        var writer = new StreamWriter(new MemoryStream());
        
        writer.Write(xml);
        writer.Flush();

        writer.BaseStream.Position = 0;

        var instance = handler.ReadFromStream(writer.BaseStream);

        return instance;
    }
}