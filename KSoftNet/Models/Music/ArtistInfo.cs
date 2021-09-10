using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Music {
  /// <summary>
  /// Artist info
  /// </summary>
  public class ArtistInfo {
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

    /// <summary>
    /// Artist albums
    /// </summary>
    [JsonPropertyName("albums")]
    public List<Album> Albums { get; set; }

    /// <summary>
    /// Artist tracks
    /// </summary>
    [JsonPropertyName("tracks")]
    public List<Track> Tracks { get; set; }
  }

}