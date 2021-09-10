using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Kumo {
  /// <summary>
  /// Location data
  /// </summary>
  public class LocationData {
    /// <summary>
    /// Address
    /// </summary>
    [JsonPropertyName("address")] public string Address { get; set; }

    /// <summary>
    /// Latitude
    /// </summary>
    [JsonPropertyName("lat")] public double Latitude { get; set; }

    /// <summary>
    /// Longitude
    /// </summary>
    [JsonPropertyName("lon")] public double Longitude { get; set; }

    /// <summary>
    /// Bounding box coordinates
    /// </summary>
    [JsonPropertyName("bounding_box")] public List<string> BoundingBox { get; set; }

    /// <summary>
    /// Types
    /// </summary>
    [JsonPropertyName("type")] public List<string> Type { get; set; }
  }

  /// <summary>
  /// Location
  /// </summary>
  public class Location {
    /// <summary>
    /// If errored
    /// </summary>
    [JsonPropertyName("error")]
    public bool Error { get; set; }

    /// <summary>
    /// Error code
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Location data
    /// </summary>
    [JsonPropertyName("data")]
    public LocationData Data { get; set; }
  }
}