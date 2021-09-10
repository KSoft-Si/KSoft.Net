using System.Text.Json.Serialization;

namespace KSoftNet.Models.Images {
  /// <summary>
  /// Reddit post
  /// </summary>
  public class RedditPost {
    /// <summary>
    /// Post title
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// Post image URL
    /// </summary>
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    /// <summary>
    /// Post source URL
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; set; }

    /// <summary>
    /// Post source subreddit
    /// </summary>
    [JsonPropertyName("subreddit")]
    public string Subreddit { get; set; }

    /// <summary>
    /// Post upvote count
    /// </summary>
    [JsonPropertyName("upvotes")]
    public int Upvotes { get; set; }

    /// <summary>
    /// Post downvote count
    /// </summary>
    [JsonPropertyName("downvotes")]
    public int Downvotes { get; set; }

    /// <summary>
    /// Post comment count
    /// </summary>
    [JsonPropertyName("comments")]
    public int Comments { get; set; }

    /// <summary>
    /// Created at timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public double CreatedAt { get; set; }

    /// <summary>
    /// If post is NSFW
    /// </summary>
    [JsonPropertyName("nsfw")]
    public bool Nsfw { get; set; }

    /// <summary>
    /// Post author username
    /// </summary>
    [JsonPropertyName("author")]
    public string Author { get; set; }

    /// <summary>
    /// Post awards
    /// </summary>
    [JsonPropertyName("awards")]
    public int Awards { get; set; }

    /// <summary>
    /// If post is cached
    /// </summary>
    [JsonPropertyName("meta__cached")]
    public bool MetaCached { get; set; }

    /// <summary>
    /// If post is processed
    /// </summary>
    [JsonPropertyName("meta__processed")]
    public bool MetaProcessed { get; set; }
  }
}