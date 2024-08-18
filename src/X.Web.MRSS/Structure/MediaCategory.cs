using JetBrains.Annotations;

namespace X.Web.MRSS.Structure;

[PublicAPI]
public record MediaCategory
{
    /// <summary>
    /// 
    /// </summary>
    public string? Scheme { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Label { get; set; }
    
    /// <summary>
    /// e.g., "music/artist/album/song"
    /// </summary>
    public string? Value { get; set; }
}