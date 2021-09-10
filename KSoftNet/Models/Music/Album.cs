using System.Text.Json.Serialization;

namespace KSoftNet.Models.Music {
  /// <summary>
  /// Album
  /// </summary>
  public class Album {
    /// <summary>
    /// Album ID
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Album name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Album release year
    /// </summary>
    [JsonPropertyName("year")]
    public int Year { get; set; }
  }
}