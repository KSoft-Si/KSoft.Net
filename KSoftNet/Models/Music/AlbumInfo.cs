using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Music {

  /// <summary>
  /// Album info
  /// </summary>
  public class AlbumInfo {
    /// <summary>
    /// Album ID
    /// </summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>
    /// Album name
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; }

    /// <summary>
    /// Album release year
    /// </summary>
    [JsonPropertyName("year")] public int Year { get; set; }

    /// <summary>
    /// Album artist
    /// </summary>
    [JsonPropertyName("artist")] public Artist Artist { get; set; }

    /// <summary>
    /// Album tracks
    /// </summary>
    [JsonPropertyName("tracks")] public List<Track> Tracks { get; set; }
  }
}