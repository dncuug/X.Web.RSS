namespace RSS.Structure.Validators
{
    #region Using Directives

    using System;
    using System.Xml.Serialization;

    using RSS.Exceptions;

    #endregion

    public class RssUrl
    {
        #region Constants and Fields

        private Uri _url;

        private string _urlString;

        #endregion

        #region Constructors and Destructors

        public RssUrl()
        {
        }

        public RssUrl(string newUrl)
        {
            this.UrlString = newUrl;
        }

        public RssUrl(Uri newUrl)
        {
            this.Url = newUrl;
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public Uri Url
        {
            get
            {
                return this._url;
            }

            set
            {
                this._url = value;
                if (this._url == null)
                {
                    this._urlString = null;
                }
                else
                {
                    this._urlString = this._url.AbsoluteUri;
                }
            }
        }

        [XmlText]
        public string UrlString
        {
            get
            {
                return this._urlString;
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

                this.Url = parseUrl;
            }
        }

        #endregion
    }
}