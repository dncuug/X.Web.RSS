using System.Xml;

namespace RSS
{
    #region Using Directives

    using System.IO;
    using System.Xml.Serialization;

    using RSS.Structure;

    #endregion

    public class RSSHelper
    {
        #region Public Methods

        public static void WriteRSS(Rss value, Stream destination)
        {
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("atom", "http://www.w3.org/2005/Atom");
            xsn.Add("dc", "http://purl.org/dc/elements/1.1/");
            xsn.Add("content", "http://purl.org/rss/1.0/modules/content/");

            XmlSerializer ser = new XmlSerializer(value.GetType());
            ser.Serialize(destination, value, xsn);
        }

        public static Rss ReadRSS(Stream source)
        {
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("atom", "http://www.w3.org/2005/Atom");
            xsn.Add("dc", "http://purl.org/dc/elements/1.1/");
            xsn.Add("content", "http://purl.org/rss/1.0/modules/content/");

            XmlSerializer ser = new XmlSerializer(typeof(Rss));
            return (Rss)ser.Deserialize(source);
        }

        public static MemoryStream RemoveEmptyElement(Stream stream)
        {
            MemoryStream newStream = new MemoryStream();
            stream.Position = 0;
            using (var reader = XmlReader.Create(stream))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                XmlNodeList nodes = doc.ChildNodes;
                RemoveEmptyNode(doc.FirstChild, nodes);
                doc.Save(newStream);
            }
            return newStream;
        }

        private static void RemoveEmptyNode(XmlNode parentNode, XmlNodeList childNodes)
        {
            foreach (XmlNode node in childNodes)
            {
                if (node.HasChildNodes)
                {
                    RemoveEmptyNode(node, node.ChildNodes);
                }
                else
                {
                    if (!node.HasChildNodes && node.Attributes?.Count <= 0 && string.IsNullOrEmpty(node.InnerText))
                    {
                        parentNode.RemoveChild(node);
                    }
                }
            }
        }

        #endregion
    }
}