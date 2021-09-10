using System;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Bans {
  /// <summary>
  /// Ban information
  /// </summary>
  public class BanInfo {
    /// <summary>
    /// Banned user ID
    /// </summary>
    [JsonPropertyName("id")] public string Id { get; set; }

    /// <summary>
    /// Banned user username
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; }

    /// <summary>
    /// Banned user discriminator
    /// </summary>
    [JsonPropertyName("discriminator")] public string Discriminator { get; set; }

    /// <summary>
    /// Discord ID of moderator who banned
    /// </summary>
    [JsonPropertyName("moderator_id")] public string ModeratorId { get; set; }

    /// <summary>
    /// Ban reason
    /// </summary>
    [JsonPropertyName("reason")] public string Reason { get; set; }

    /// <summary>
    /// Ban proof
    /// </summary>
    [JsonPropertyName("proof")] public string Proof { get; set; }

    /// <summary>
    /// If ban is active
    /// </summary>
    [JsonPropertyName("is_ban_active")] public bool IsBanActive { get; set; }

    /// <summary>
    /// If ban can be appealed
    /// </summary>
    [JsonPropertyName("can_be_appealed")] public bool CanBeAppealed { get; set; }

    /// <summary>
    /// Time of ban
    /// </summary>
    [JsonPropertyName("timestamp")] public DateTime Timestamp { get; set; }

    /// <summary>
    /// Appeal reason, if any
    /// </summary>
    [JsonPropertyName("appeal_reason")] public object AppealReason { get; set; }

    /// <summary>
    /// Appeal date
    /// </summary>
    [JsonPropertyName("appeal_date")] public object AppealDate { get; set; }

    /// <summary>
    /// Ban requester
    /// </summary>
    [JsonPropertyName("requested_by")] public string RequestedBy { get; set; }

    /// <summary>
    /// If ban exists
    /// </summary>
    [JsonPropertyName("exists")] public bool Exists { get; set; }
  }
}