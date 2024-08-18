using JetBrains.Annotations;
using X.Web.RSS.Structure;

namespace X.Web.MRSS.Structure;

[PublicAPI]
public record MediaRssItem : RssItem
{
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// MIME type (e.g., "video/mp4")
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Type of object (e.g., "image", "audio", "video")
    /// </summary>
    public string Medium { get; set; } = string.Empty;

    /// <summary>
    /// If this is the default object
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// "sample", "full", "nonstop"
    /// </summary>
    public string Expression { get; set; } = string.Empty;

    /// <summary>
    /// Kilobits per second
    /// </summary>
    public double Bitrate { get; set; }

    /// <summary>
    /// Frames per second
    /// </summary>
    public double Framerate { get; set; }

    /// <summary>
    /// Samples per second in kHz
    /// </summary>
    public double SamplingRate { get; set; }

    /// <summary>
    /// Number of audio channels
    /// </summary>
    public int Channels { get; set; }

    /// <summary>
    /// In seconds
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Height in pixels
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Width in pixels
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Language code (RFC 3066)
    /// </summary>
    public string Lang { get; set; } = string.Empty;

    
    public MediaRating? Rating { get; set; }

    public List<string> Keywords { get; set; } = new();

    public List<MediaThumbnail> Thumbnails { get; set; } = new();

    public List<MediaCategory> Categories { get; set; } = new();

    public List<MediaCredit> Credits { get; set; } = new();
}