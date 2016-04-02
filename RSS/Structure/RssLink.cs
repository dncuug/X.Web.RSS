namespace RSS.Structure
{
    #region Using Directives

    using System.Xml.Serialization;

    using RSS.Enumerators;
    using RSS.Structure.Validators;

    #endregion

    /// <summary>
    /// &lt;atom:link href = "http://bash.org.ru/rss/" rel = "self" type = "application/rss+xml" /&gt;
    /// </summary>
    public class RssLink
    {
        #region Constructors and Destructors

        public RssLink()
        {
            this.Type = "application/rss+xml";
            this.Rel = Rel.Self;
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public RssUrl Href
        {
            get
            {
                return new RssUrl(this.InternalHref);
            }

            set
            {
                this.InternalHref = value.UrlString;
            }
        }

        [XmlAttribute("rel")]
        public Rel Rel { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("href")]
        public string InternalHref { get; set; }

        #endregion
    }
}