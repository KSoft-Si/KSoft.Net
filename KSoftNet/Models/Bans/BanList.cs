using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Bans {
  /// <summary>
  /// Paginated list of bans
  /// </summary>
  public class BanList {
    /// <summary>
    /// Total ban count
    /// </summary>
    [JsonPropertyName("ban_count")]
    public int BanCount { get; set; }

    /// <summary>
    /// Total page count
    /// </summary>
    [JsonPropertyName("page_count")]
    public int PageCount { get; set; }

    /// <summary>
    /// Bans displayed per page
    /// </summary>
    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    /// <summary>
    /// Current page
    /// </summary>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>
    /// Count of bans displayed
    /// </summary>
    [JsonPropertyName("on_page")]
    public int OnPage { get; set; }

    /// <summary>
    /// Next page number
    /// </summary>
    [JsonPropertyName("next_page")]
    public int NextPage { get; set; }

    /// <summary>
    /// Previous page number
    /// </summary>
    [JsonPropertyName("previous_page")]
    public object PreviousPage { get; set; }

    /// <summary>
    /// Ban data
    /// </summary>
    [JsonPropertyName("data")]
    public List<BanInfo> Bans { get; set; }
  }
}