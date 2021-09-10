using System.Text.Json.Serialization;

namespace KSoftNet.Models.Images {
  /// <summary>
  /// Image
  /// </summary>
  public class Image {
    /// <summary>
    /// Image URL
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// Image ID
    /// </summary>
    [JsonPropertyName("snowflake")]
    public string Snowflake { get; set; }

    /// <summary>
    /// If image is NSFW
    /// </summary>
    [JsonPropertyName("nsfw")]
    public bool Nsfw { get; set; }

    /// <summary>
    /// Image tag
    /// </summary>
    [JsonPropertyName("tag")]
    public string Tag { get; set; }
  }
}