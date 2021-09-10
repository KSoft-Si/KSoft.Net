using System.Text.Json.Serialization;

namespace KSoftNet.Models.Bans {
  /// <summary>
  /// Ban check status
  /// </summary>
  public class BanCheck {
    /// <summary>
    /// If user is banned
    /// </summary>
    [JsonPropertyName("is_banned")]
    public bool IsBanned { get; set; }
  }
}