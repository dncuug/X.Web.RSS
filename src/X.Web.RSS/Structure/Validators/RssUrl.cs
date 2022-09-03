using System;
using System.Xml.Serialization;
using X.Web.RSS.Exceptions;

namespace X.Web.RSS.Structure.Validators;

public class RssUrl
{
    private Uri _url;

    private string _urlString;

    public RssUrl()
    {
    }

    public RssUrl(string newUrl)
    {
        UrlString = newUrl;
    }

    public RssUrl(Uri newUrl)
    {
        Url = newUrl;
    }

    [XmlIgnore]
    public Uri Url
    {
        get
        {
            return _url;
        }
        set
        {
            _url = value;
            
            if (_url == null)
            {
                _urlString = null;
            }
            else
            {
                _urlString = _url.AbsoluteUri;
            }
        }
    }

    [XmlText]
    public string UrlString
    {
        get
        {
            return _urlString;
        }
        set
        {
            Uri parseUrl = null;
            
            if (value != null)
            {
                try
                {
                    parseUrl = new Uri(value, UriKind.Absolute);
                }
                catch (Exception ex)
                {
                    throw new RSSParameterException("url", value, ex);
                }
            }

            Url = parseUrl;
        }
    }
}