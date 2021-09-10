using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Music {

  /// <summary>
  /// Track info
  /// </summary>
  public class TrackInfo {
    /// <summary>
    /// Track Id
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Track name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Track artist
    /// </summary>
    [JsonPropertyName("artist")]
    public Artist Artist { get; set; }

    /// <summary>
    /// Track albums
    /// </summary>
    [JsonPropertyName("albums")]
    public List<Album> Albums { get; set; }

    /// <summary>
    /// Track lyrics
    /// </summary>
    [JsonPropertyName("lyrics")]
    public string Lyrics { get; set; }
  }
}