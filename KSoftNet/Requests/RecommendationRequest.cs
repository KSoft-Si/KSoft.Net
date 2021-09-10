using System.Text.Json.Serialization;

namespace KSoftNet.Requests {
  /// <summary>
  /// Music recommendation request
  /// </summary>
  public class RecommendationRequest {
    /// <summary>
    /// JSON List or comma-separated list of input tracks. Content of the list depends on selected provider.
    /// </summary>
    [JsonPropertyName("tracks")]
    public object[] Tracks { get; set; }

    /// <summary>
    /// Recommended. YouTube v3 API token.
    /// </summary>
    [JsonPropertyName("youtube_token")]
    public string YoutubeToken { get; set; }

    /// <summary>
    /// How many tracks to return. Defaults to 5. Valid range: 1-5
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 5;

    /// <summary>
    /// Which data type to return.
    /// <p> <c>track</c> - returns a list of track objects</p>
    /// <p> <c>youtube_link</c> - returns a list of youtube links</p>
    /// <p> <c>youtube_id</c> - returns a list of YouTube IDs</p>
    /// </summary>
    [JsonPropertyName("recommend_type")]
    public string RecommendationType { get; set; }

    /// <summary>
    /// Format in which you'll provide tracks. Can be:
    /// <p><c>youtube</c> - For list of YouTube links</p>
    /// <p><c>youtube_ids</c> - For list of YouTube video IDs</p>
    /// <p><c>youtube_titles</c> - For list of YouTube titles (faster)</p>
    /// <p><c>spotify</c> - For list of Spotify IDs (fastest)</p>
    /// </summary>
    [JsonPropertyName("provider")]
    public string Provider { get; set; }
  }
}