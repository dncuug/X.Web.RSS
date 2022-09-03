using System.Xml.Serialization;
using JetBrains.Annotations;
using X.Web.RSS.Structure.Validators;

namespace X.Web.RSS.Structure;

[PublicAPI]
public class RssEnclosure
{
    /// <summary>
    ///   Gets or sets length says how big it is in bytes
    /// </summary>
    /// <example>
    ///   12216320
    /// </example>
    [XmlAttribute("length")]
    public int Length { get; set; }

    /// <summary>
    ///   Gets or sets type says what its type is, a standard MIME type
    /// </summary>
    /// <example>
    ///   audio/mpeg
    /// </example>
    [XmlAttribute("type")]
    public string Type { get; set; }

    /// <summary>
    ///   Gets or sets url says where the enclosure is located
    /// </summary>
    /// <example>
    ///   http://www.scripting.com/mp3s/weatherReportSuite.mp3
    /// </example>
    [XmlIgnore]
    public RssUrl Url
    {
        get => new RssUrl(InternalUrl);
        set => InternalUrl = value.UrlString;
    }

    [XmlAttribute("url")]
    public string InternalUrl { get; set; }
}