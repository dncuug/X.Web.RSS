namespace RSS.Structure
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Serialization;

    using RSS.Enumerators;
    using RSS.Structure.Validators;

    #endregion

    /// <summary>
    /// Subordinate to the 'rss' element is a single 'channel' element, 
    ///   which contains information about the channel (metadata) and its contents.
    /// </summary>
    public class RssChannel
    {
        #region Constructors and Destructors

        public RssChannel()
        {
            this.Docs = "http://www.rssboard.org/rss-specification";
            this.Generator = "ApmeM RSS Generator";
            this.Item = new List<RssItem>();
            this.SkipDays = new List<Day>();
            this.SkipHours = new List<Hour>();
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets &lt;atom:link href = "http://bash.org.ru/rss/" rel = "self" type = "application/rss+xml" /&gt;
        /// </summary>
        [XmlElement("link", Namespace = "http://www.w3.org/2005/Atom")]
        public RssLink AtomLink { get; set; }

        /// <summary>
        ///   Gets or sets one or more categories that the channel belongs to. 
        ///   Follows the same rules as the 'item'-level category element.
        /// </summary>
        [XmlElement("category")]
        public string Category { get; set; }

        /// <summary>
        ///   Gets or sets processes to register with a cloud to be notified of 
        ///   updates to the channel, implementing a lightweight publish-subscribe 
        ///   protocol for RSS feeds.
        /// </summary>
        [XmlElement("cloud")]
        public RssCloud Cloud { get; set; }

        /// <summary>
        ///   Gets or sets copyright notice for content in the channel.
        /// </summary>
        /// <example>
        ///   Copyright 2002, Spartanburg Herald-Journal
        /// </example>
        [XmlElement("copyright")]
        public string Copyright { get; set; }

        /// <summary>
        ///   Gets or sets phrase or sentence describing the channel.
        /// </summary>
        /// <example>
        ///   The latest news from GoUpstate.com, a Spartanburg Herald-Journal Web site.
        /// </example>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        ///   Gets or sets URL that points to the documentation for the format used in the RSS file. 
        ///   It's probably a pointer to this page. It's for people who might stumble across 
        ///   an RSS file on a Web server 25 years from now and wonder what it is.
        /// </summary>
        /// <example>
        ///   http://www.rssboard.org/rss-specification
        /// </example>
        [XmlElement("docs")]
        public string Docs { get; set; }

        /// <summary>
        ///   Gets or sets a string indicating the program used to generate the channel.
        /// </summary>
        /// <example>
        ///   MightyInHouse Content System v2.3
        /// </example>
        [XmlElement("generator")]
        public string Generator { get; set; }

        /// <summary>
        ///   Gets or sets a GIF, JPEG or PNG image that can be displayed with the channel.
        /// </summary>
        [XmlElement("image")]
        public RssImage Image { get; set; }

        [XmlElement("language")]
        public string InternalLanguage { get; set; }

        [XmlElement("lastBuildDate")]
        public string InternalLastBuildDate { get; set; }

        [XmlElement("pubDate")]
        public string InternalPubDate { get; set; }

        [XmlElement("ttl")]
        public string InternalTTL { get; set; }
        
        /// <summary>
        ///   Gets or sets OPTIONAL the language the channel is written in. This allows aggregators to group all 
        ///   Italian language sites, for example, on a single page. A list of allowable 
        ///   values for this element, as provided by Netscape, is 
        ///   http://www.rssboard.org/rss-language-codes. You may also use values defined 
        ///   by the W3C http://www.w3.org/TR/REC-html40/struct/dirlang.html#langcodes.
        /// </summary>
        /// <example>
        ///   en-us
        /// </example>
        [XmlIgnore]
        public CultureInfo Language
        {
            get
            {
                return new CultureInfo(this.InternalLanguage);
            }

            set
            {
                this.InternalLanguage = value.Name;
            }
        }

        /// <summary>
        ///   Gets or sets the last time the content of the channel changed.
        /// </summary>
        /// <example>
        ///   Sat, 07 Sep 2002 09:42:31 GMT
        /// </example>
        [XmlIgnore]
        public DateTime? LastBuildDate
        {
            get
            {
                return new RssDate(this.InternalLastBuildDate).Date;
            }

            set
            {
                this.InternalLastBuildDate = new RssDate(value).DateString;
            }
        }

        /// <summary>
        ///   Gets or sets the URL to the HTML website corresponding to the channel.
        /// </summary>
        /// <example>
        ///   http://www.goupstate.com/
        /// </example>
        [XmlElement("link")]
        public RssUrl Link { get; set; }

        /// <summary>
        ///   Gets or sets email address for person responsible for editorial content.
        /// </summary>
        /// <example>
        ///   geo@herald.com (George Matesky)
        /// </example>
        [XmlElement("managingEditor")]
        public RssEmail ManagingEditor { get; set; }

        /// <summary>
        ///   Gets or sets the publication date for the content in the channel. 
        ///   For example, the New York Times publishes on a daily basis, 
        ///   the publication date flips once every 24 hours. That's when 
        ///   the pubDate of the channel changes. All date-times in RSS
        ///   conform to the Date and Time Specification of RFC 822
        ///   http://asg.web.cmu.edu/rfc/rfc822.html, with the exception that
        ///   the year may be expressed with two characters or four characters 
        ///   (four preferred).
        /// </summary>
        /// <example>
        ///   Sat, 07 Sep 2002 00:00:01 GMT
        /// </example>
        [XmlIgnore]
        public DateTime? PubDate
        {
            get
            {
                return new RssDate(this.InternalPubDate).Date;
            }

            set
            {
                this.InternalPubDate = new RssDate(value).DateString;
            }
        }

        /// <summary>
        ///   Gets or sets the PICS rating for the channel.
        /// </summary>
        [XmlElement("rating")]
        public string Rating { get; set; }

        /// <summary>
        ///   Gets or sets a hint for aggregators telling them which days they can skip. 
        ///   This element contains up to seven 'day' sub-elements whose value 
        ///   is Monday, Tuesday, Wednesday, Thursday, Friday, Saturday or 
        ///   Sunday. Aggregators may not read the channel during days listed 
        ///   in the 'skipDays' element.
        /// </summary>
        [XmlArrayItem("day")]
        [XmlArray("skipDays")]
        public List<Day> SkipDays { get; set; }

        /// <summary>
        ///   Gets or sets a hint for aggregators telling them which hours they can skip.
        ///   This element contains up to 24 'hour' sub-elements whose value is
        ///   a number between 0 and 23, representing a time in GMT, when aggregators, 
        ///   if they support the feature, may not read the channel on hours listed 
        ///   in the 'skipHours' element. The hour beginning at midnight is hour zero.
        /// </summary>
        [XmlArrayItem("hour")]
        [XmlArray("skipHours")]
        public List<Hour> SkipHours { get; set; }

        /// <summary>
        ///   Gets or sets ttl stands for time to live. It's a number of minutes that indicates how 
        ///   long a channel can be cached before refreshing from the source.
        /// </summary>
        [XmlIgnore]
        public int TTL
        {
            get
            {
                return new RssTtl(this.InternalTTL).TTL;
            }

            set
            {
                this.InternalTTL = new RssTtl(value).TTLString;
            }
        }

        /// <summary>
        ///   Gets or sets a text input box that can be displayed with the channel. OBSOLETE.
        /// </summary>
        [XmlElement("textInput")]
        /*        [Obsolete(
            @"The RSS specification actively discourages publishers from using the textInput element, calling its purpose ""something of a mystery"" and stating that ""most aggregators ignore it."" Fewer than one percent of surveyed RSS feeds included the element. The only aggregators known to support it are BottomFeeder and Liferea.
 For this reason, publishers should not expect it to be supported in most aggregators."
            )]*/
        public RssTextInput TextInput { get; set; }

        /// <summary>
        ///   Gets or sets the name of the channel. It's how people refer to your service. 
        ///   If you have an HTML website that contains the same information as 
        ///   your RSS file, the title of your channel should be the same as 
        ///   the title of your website.
        /// </summary>
        /// <example>
        ///   http://www.goupstate.com/
        /// </example>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        ///   Gets or sets email address for person responsible for technical issues relating to channel.
        /// </summary>
        /// <example>
        ///   betty@herald.com (Betty Guernsey)
        /// </example>
        [XmlElement("webMaster")]
        public RssEmail WebMaster { get; set; }

        /// <summary>
        ///   Gets or sets a channel may contain any number of 'item's. An item may represent 
        ///   a "story" -- much like a story in a newspaper or magazine; if so its
        ///   description is a synopsis of the story, and the link points to the full 
        ///   story. An item may also be complete in itself, if so, the description 
        ///   contains the text (entity-encoded HTML is allowed; see examples
        ///   http://www.rssboard.org/rss-encoding-examples), and the link and title may 
        ///   be omitted. All elements of an item are optional, however at least one of 
        ///   title or description must be present.
        /// </summary>
        [XmlElement("item")]
        public List<RssItem> Item { get; set; }

        #endregion
    }
}