using System.Text.Json.Serialization;

namespace KSoftNet.Models.Images {
  /// <summary>
  /// WikiHow post
  /// </summary>
  public class WikihowPost {
    /// <summary>
    /// Post image URL
    /// </summary>
    [JsonPropertyName("url")] public string ImageUrl { get; set; }

    /// <summary>
    /// Post title
    /// </summary>
    [JsonPropertyName("title")] public string Title { get; set; }

    /// <summary>
    /// If post is NSFW
    /// </summary>
    [JsonPropertyName("nsfw")] public bool Nsfw { get; set; }

    /// <summary>
    /// Post source URL
    /// </summary>
    [JsonPropertyName("article_url")] public string ArticleUrl { get; set; }
  }
}