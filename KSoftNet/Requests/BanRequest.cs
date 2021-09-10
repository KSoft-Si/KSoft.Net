using System.Text.Json.Serialization;

namespace KSoftNet.Requests {
  /// <summary>
  /// New ban request
  /// </summary>
  public class BanRequest {
    /// <summary>
    /// Users Discord ID that you are banning/reporting
    /// </summary>
    [JsonPropertyName("user")]
    public ulong User { get; set; }

    /// <summary>
    /// Users Discord ID who posted/reported the ban
    /// </summary>
    [JsonPropertyName("mod")]
    public ulong Mod { get; set; }

    /// <summary>
    /// Users Discord username
    /// </summary>
    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

    /// <summary>
    /// Users Discord discriminator
    /// </summary>
    [JsonPropertyName("user_discriminator")]
    public string UserDiscriminator { get; set; }

    /// <summary>
    /// Reason why user should be globally banned
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    /// <summary>
    /// URL of the image showing the act
    /// </summary>
    [JsonPropertyName("proof")]
    public string Proof { get; set; }

    /// <summary>
    /// If appeal should be disabled for that user.
    /// </summary>
    [JsonPropertyName("appeal_possible")]
    public bool AppealPossible { get; set; }
  }
}