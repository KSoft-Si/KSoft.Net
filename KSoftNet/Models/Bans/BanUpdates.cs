using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Bans {
  /// <summary>
  /// Minimal ban info
  /// </summary>
  public class SmallBanInfo {
    /// <summary>
    /// Banned user ID
    /// </summary>
    [JsonPropertyName("id")]
    public object Id { get; set; }

    /// <summary>
    /// Ban reason
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    /// <summary>
    /// Ban Proof
    /// </summary>
    [JsonPropertyName("proof")]
    public string Proof { get; set; }

    /// <summary>
    /// Mod who banned
    /// </summary>
    [JsonPropertyName("moderator_id")]
    public object ModeratorId { get; set; }

    /// <summary>
    /// If ban is active
    /// </summary>
    [JsonPropertyName("active")]
    public bool Active { get; set; }
  }

  /// <summary>
  /// Bans since last update
  /// </summary>
  public class BanUpdates {
    /// <summary>
    /// List of bans
    /// </summary>
    [JsonPropertyName("data")]
    public List<SmallBanInfo> Bans { get; set; }

    /// <summary>
    /// Timestamp of request
    /// </summary>
    [JsonPropertyName("current_timestamp")]
    public int CurrentTimestamp { get; set; }
  }

}