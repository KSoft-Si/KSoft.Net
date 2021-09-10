using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Music {
  /// <summary>
  /// Youtube track
  /// </summary>
  public class Youtube {
    /// <summary>
    /// Track ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Link to track on youtube
    /// </summary>
    [JsonPropertyName("link")]
    public string Link { get; set; }

    /// <summary>
    /// Track title
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// Thumbnail URL
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }

    /// <summary>
    /// Track description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }
  }

  /// <summary>
  /// Recommended album
  /// </summary>
  public class RecommendedAlbum {
    /// <summary>
    /// Album name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Album art URL
    /// </summary>
    [JsonPropertyName("album_art")]
    public string AlbumArt { get; set; }

    /// <summary>
    /// Link to album on Spotify
    /// </summary>
    [JsonPropertyName("link")]
    public string Link { get; set; }
  }

  /// <summary>
  /// Recommended artist
  /// </summary>
  public class RecommendedArtist {
    /// <summary>
    /// Artist name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Link to artist on Spotify
    /// </summary>
    [JsonPropertyName("link")]
    public string Link { get; set; }
  }

  /// <summary>
  /// Spotify track
  /// </summary>
  public class Spotify {
    /// <summary>
    /// Track ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Track album
    /// </summary>
    [JsonPropertyName("album")]
    public RecommendedAlbum Album { get; set; }

    /// <summary>
    /// Track artists
    /// </summary>
    [JsonPropertyName("artists")]
    public List<RecommendedArtist> Artists { get; set; }

    /// <summary>
    /// Track name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Link to track on spotify
    /// </summary>
    [JsonPropertyName("link")]
    public string Link { get; set; }
  }

  /// <summary>
  /// Recommended track
  /// </summary>
  public class RecommendedTrack {
    /// <summary>
    /// Youtube information for track
    /// </summary>
    [JsonPropertyName("youtube")]
    public Youtube Youtube { get; set; }

    /// <summary>
    /// Spotify information for track
    /// </summary>
    [JsonPropertyName("spotify")]
    public Spotify Spotify { get; set; }

    /// <summary>
    /// Track name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
  }

  /// <summary>
  /// Music recommendations
  /// </summary>
  public class Recommendations {
    /// <summary>
    /// Track provider
    /// </summary>
    [JsonPropertyName("provider")]
    public string Provider { get; set; }

    /// <summary>
    /// Total recommendations
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// Tracks recommended
    /// </summary>
    [JsonPropertyName("tracks")]
    public List<RecommendedTrack> Tracks { get; set; }
  }

}