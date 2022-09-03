using System.Xml.Serialization;
using X.Web.RSS.Enumerators;

namespace X.Web.RSS.Structure;

/// <summary>
/// It specifies a web service that supports the rssCloud interface
///   which can be implemented in HTTP-POST, XML-RPC or SOAP 1.1.
///   Its purpose is to allow processes to register with a cloud to be 
///   notified of updates to the channel, implementing a lightweight 
///   publish-subscribe protocol for RSS feeds.
/// </summary>
public class RssCloud
{
    /// <summary>
    ///   Gets or sets a list of URLs of RSS documents that the client seeks to monitor
    /// </summary>
    /// <example>
    ///   rpc.sys.com
    /// </example>
    [XmlAttribute("domain")]
    public string Domain { get; set; }

    /// <summary>
    ///   Gets or sets the client's remote procedure call path
    /// </summary>
    /// <example>
    ///   /RPC2
    /// </example>
    [XmlAttribute("path")]
    public string Path { get; set; }

    /// <summary>
    ///   Gets or sets the client's TCP port
    /// </summary>
    /// <example>
    ///   80
    /// </example>
    [XmlAttribute("port")]
    public int Port { get; set; }

    /// <summary>
    ///   Gets or sets the string "xml-rpc" if the client employs XML-RPC or "soap" for SOAP
    /// </summary>
    /// <example>
    ///   xml-rpc
    /// </example>
    /// <example>
    ///   soap
    /// </example>
    [XmlAttribute("protocol")]
    public Protocol Protocol { get; set; }

    /// <summary>
    ///   Gets or sets the name of the remote procedure the cloud should call on the client upon an update
    /// </summary>
    /// <example>
    ///   myCloud.rssPleaseNotify
    /// </example>
    [XmlAttribute("registerProcedure")]
    public string RegisterProcedure { get; set; }
}