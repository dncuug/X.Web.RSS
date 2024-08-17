using X.Web.RSS.Structure;

namespace X.Web.MRSS;

public record MediaRssItem : RssItem
{
    public string Url { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // MIME type (e.g., "video/mp4")
    public string Medium { get; set; } = string.Empty; // Type of object (e.g., "image", "audio", "video")
    public bool IsDefault { get; set; } // If this is the default object
    public string Expression { get; set; } = string.Empty; // "sample", "full", "nonstop"
    public double Bitrate { get; set; } // Kilobits per second
    public double Framerate { get; set; } // Frames per second
    public double SamplingRate { get; set; } // Samples per second in kHz
    public int Channels { get; set; } // Number of audio channels
    public int Duration { get; set; } // In seconds
    public int Height { get; set; } // Height in pixels
    public int Width { get; set; } // Width in pixels
    public string Lang { get; set; } = string.Empty; // Language code (RFC 3066)

    // Optional Elements
    public MediaRating Rating { get; set; }

    public List<string> Keywords { get; set; }
    public List<MediaThumbnail> Thumbnails { get; set; }
    public List<MediaCategory> Categories { get; set; }
    public List<MediaCredit> Credits { get; set; }
}

public record MediaRating
{
    public string Scheme { get; set; } // e.g., "urn:simple"
    public string Value { get; set; } // e.g., "adult", "nonadult"
}

public record MediaTitle
{
    public string Type { get; set; } // "plain" or "html"
    public string Value { get; set; }
}

public record MediaDescription
{
    public string Type { get; set; } // "plain" or "html"
    public string Value { get; set; }
}

public record MediaThumbnail
{
    public string Url { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Time { get; set; } // Format "H:M:S.h" or "S.h"
}

public record MediaCategory
{
    public string Scheme { get; set; }
    public string Label { get; set; }
    public string Value { get; set; } // e.g., "music/artist/album/song"
}

public record MediaCredit
{
    public string Role { get; set; } // e.g., "producer", "owner"
    public string Scheme { get; set; } // e.g., "urn:ebu"
    public string Value { get; set; }
}