using JetBrains.Annotations;

namespace X.Web.MRSS.Structure;

[PublicAPI]
public record MediaRating
{
    /// <summary>
    /// e.g., "urn:simple"
    /// </summary>
    public string? Scheme { get; set; }
    
    /// <summary>
    /// e.g., "adult", "nonadult"
    /// </summary>
    public string? Value { get; set; }
}