using JetBrains.Annotations;

namespace X.Web.MRSS.Structure;

[PublicAPI]
public record MediaCredit
{
    /// <summary>
    /// e.g., "producer", "owner"
    /// </summary>
    public string? Role { get; set; }
    
    /// <summary>
    /// e.g., "urn:ebu"
    /// </summary>
    public string? Scheme { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Value { get; set; }
}