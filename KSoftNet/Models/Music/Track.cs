using System.Text.Json.Serialization;

namespace KSoftNet.Models.Music {
  /// <summary>
  /// Track
  /// </summary>
  public class Track {
    /// <summary>
    /// Track ID
    /// </summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>
    /// Track name
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; }
  }
}