using System.Text.Json.Serialization;

namespace KSoftNet.Models.Bans {
  /// <summary>
  /// Ban deletion status
  /// </summary>
  public class BanDeletion {
    /// <summary>
    /// If successful
    /// </summary>
    [JsonPropertyName("done")]
    public bool Done { get; set; }
  }
}