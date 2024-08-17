using JetBrains.Annotations;

namespace X.Web.RSS;

[PublicAPI]
public interface IRssDocument<TRssChannel>
{
    /// <summary>
    ///   Gets or sets subordinate to the 'rss' element is a single 'channel' element, 
    ///   which contains information about the channel (metadata) and its contents.
    /// </summary>
    TRssChannel Channel { get; set; }

    /// <summary>
    ///   Gets or sets at the top level, a RSS document is a 'rss' element, 
    ///   with a mandatory attribute called version, that specifies 
    ///   the version of RSS that the document conforms to.
    /// </summary>
    string Version { get; set; }
}
