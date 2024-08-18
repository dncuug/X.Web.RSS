using System;
using System.Xml.Serialization;
using X.Web.RSS.Validators;

namespace X.Web.RSS.Structure;

public class RssUrl
{
    private readonly UriValidator _validator;

    private string? _url;

    public RssUrl()
    {
        _url = null;
        _validator = new UriValidator();
    }

    public RssUrl(string newUrl)
        : this()
    {
        _validator.Validate(newUrl);
        _url = newUrl;
    }

    public RssUrl(Uri url)
        : this()
    {
        _url = url.ToString();
    }

    [XmlText]
    public string? Url
    {
        get { return _url; }
        set
        {
            _validator.Validate(value);

            _url = value;
        }
    }
}