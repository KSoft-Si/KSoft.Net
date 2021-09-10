using System.Text.Json.Serialization;

namespace KSoftNet.Models.Music {
  /// <summary>
  /// Artist
  /// </summary>
  public class Artist {
    /// <summary>
    /// Artist ID
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Artist name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
  }
}