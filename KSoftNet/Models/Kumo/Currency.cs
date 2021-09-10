using System.Text.Json.Serialization;

namespace KSoftNet.Models.Kumo {
  /// <summary>
  /// Currency
  /// </summary>
  public class Currency {
    /// <summary>
    /// Value
    /// </summary>
    [JsonPropertyName("value")]
    public double Value { get; set; }

    /// <summary>
    /// String with currency code, eg <c>475.84 CNY</c>
    /// </summary>
    [JsonPropertyName("pretty")]
    public string Pretty { get; set; }
  }
}