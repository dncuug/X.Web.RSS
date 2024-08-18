using JetBrains.Annotations;

namespace X.Web.MRSS.Structure;

[PublicAPI]
public record MediaThumbnail
{
    /// <summary>
    /// 
    /// </summary>
    public string? Url { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int Width { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int Height { get; set; }
    
    /// <summary>
    /// Format "H:M:S.h" or "S.h"
    /// </summary>
    public string Time { get; set; }
}