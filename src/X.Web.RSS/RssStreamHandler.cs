using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace X.Web.RSS;

public interface IRssStreamHandler
{
    Task<IRssDocument> ReadFromUrlAsync(Uri url);
    
    IRssDocument ReadFromStream(Stream stream);
    
    void WriteToStream(IRssDocument rss, Stream stream);
}

public class RssStreamHandler : IRssStreamHandler
{
    public async Task<IRssDocument> ReadFromUrlAsync(Uri url)
    {
        if (WebRequest.Create(url) is HttpWebRequest request)
        {
            var response = await request.GetResponseAsync();
            var responseStream = response.GetResponseStream();
            
            using (var reader = new StreamReader(responseStream, Encoding.ASCII))
            {
                var rss = ReadFromStream(reader);
                
                return rss;
            }
        }

        return null;
    }
    
    public IRssDocument ReadFromStream(Stream stream) => ReadFromStream(new StreamReader(stream));
    
    private IRssDocument ReadFromStream(StreamReader reader)
    {
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("atom", "http://www.w3.org/2005/Atom");
        namespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
        namespaces.Add("content", "http://purl.org/rss/1.0/modules/content/");

        var xmlSerializer = new XmlSerializer(typeof(RssDocument));
        var obj = xmlSerializer.Deserialize(reader);
        var result = obj as RssDocument;

        return result;
    }
    
    public void WriteToStream(IRssDocument rss, Stream stream)
    {
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("atom", "http://www.w3.org/2005/Atom");
        namespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
        namespaces.Add("content", "http://purl.org/rss/1.0/modules/content/");

        var xmlSerializer = new XmlSerializer(rss.GetType());
        xmlSerializer.Serialize(stream, rss, namespaces);
    }
}