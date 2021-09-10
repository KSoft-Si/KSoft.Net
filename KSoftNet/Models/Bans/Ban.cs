using System.Text.Json.Serialization;

namespace KSoftNet.Models.Bans {
  /// <summary>
  /// Ban creation status
  /// </summary>
  public class Ban {
    /// <summary>
    /// Ban was successfully recorded.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
  }
}