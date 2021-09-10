using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Images {
  /// <summary>
  /// Tag info
  /// </summary>
  public class TagInfo {
    /// <summary>
    /// Tag name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Is NSFW
    /// </summary>
    [JsonPropertyName("nsfw")]
    public bool Nsfw { get; set; }
  }

  /// <summary>
  /// List of tags
  /// </summary>
  public class TagList {
    /// <summary>
    /// Tag info
    /// </summary>
    [JsonPropertyName("models")]
    public List<TagInfo> Models { get; set; }

    /// <summary>
    /// All tags
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    /// <summary>
    /// All NSFW tags
    /// </summary>
    [JsonPropertyName("nsfw_tags")]
    public List<string> NsfwTags { get; set; }
  }
}