using System.Xml.Serialization;
using X.Web.RSS.Exceptions;
using X.Web.RSS.Structure.Validators;

namespace X.Web.RSS.Structure;

/// <summary>
/// Specifies a GIF, JPEG or PNG image that can be displayed with the channel.
/// </summary>
public class RssImage
{
    private int _height = 31;
    private int _width = 88;

    /// <summary>
    ///   Gets or sets contains text that is included in the TITLE attribute of the link 
    ///   formed around the image in the HTML rendering.
    /// </summary>
    [XmlElement("description")]
    public string Description { get; set; }

    /// <summary>
    ///   Gets or sets optional elements include 'width', numbers, indicating the width of the image in pixels.
    /// </summary>
    [XmlElement("width")]
    public int Width
    {
        get { return _width; }
        set
        {
            if (_width > 144)
            {
                throw new RSSParameterException("width", _width);
            }

            _width = value;
        }
    }

    /// <summary>
    ///   Gets or sets optional elements include 'height', numbers, indicating the height of the image in pixels.
    /// </summary>
    [XmlElement("height")]
    public int Height
    {
        get { return _height; }
        set
        {
            if (_height > 400)
            {
                throw new RSSParameterException("height", _height);
            }

            _height = value;
        }
    }

    /// <summary>
    ///   Gets or sets is the URL of the site, when the channel is rendered,
    ///   the image is a link to the site.
    /// </summary>
    [XmlElement("link")]
    public RssUrl Link { get; set; }

    /// <summary>
    ///   Gets or sets describes the image, it's used in the ALT attribute of the HTML 'img'
    ///   tag when the channel is rendered in HTML.
    /// </summary>
    [XmlElement("title")]
    public string Title { get; set; }

    /// <summary>
    ///   Gets or sets is the URL of a GIF, JPEG or PNG image that represents the channel.
    /// </summary>
    [XmlElement("url")]
    public RssUrl Url { get; set; }
}