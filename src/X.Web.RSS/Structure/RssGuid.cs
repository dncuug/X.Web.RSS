using System.Xml.Serialization;

namespace X.Web.RSS.Structure;

/// <summary>
/// guid stands for globally unique identifier. 
///   It's a string that uniquely identifies the item. 
///   When present, an aggregator may choose to use this string to 
///   determine if an item is new.
/// </summary>
public class RssGuid
{
    public RssGuid()
    {
        IsPermaLink = true;
    }

    /// <summary>
    ///   Gets or sets a value indicating whether if the guid element has an attribute named isPermaLink with a
    ///   value of true, the reader may assume that it is a permalink to
    ///   the item, that is, a url that can be opened in a Web browser,
    ///   that points to the full item described by the 'item' element
    /// </summary>
    /// <example>
    ///   true
    /// </example>
    [XmlAttribute("isPermaLink")]
    public bool IsPermaLink { get; set; }

    /// <summary>
    ///   Gets or sets there are no rules for the syntax of a guid. 
    ///   Aggregators must view them as a string. It's up to the source of 
    ///   the feed to establish the uniqueness of the string.
    /// </summary>
    /// <example>
    ///   http://some.server.com/weblogItem3207
    /// </example>
    [XmlText]
    public string Value { get; set; }
}