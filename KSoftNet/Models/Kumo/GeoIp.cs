using System.Text.Json.Serialization;

namespace KSoftNet.Models.Kumo {
  /// <summary>
  /// GeoIP API links
  /// </summary>
  public class GeoIpApis {
    /// <summary>
    /// Kumo weather URL
    /// </summary>
    [JsonPropertyName("weather")]
    public string Weather { get; set; }

    /// <summary>
    /// Kumo gis URL
    /// </summary>
    [JsonPropertyName("gis")]
    public string Gis { get; set; }

    /// <summary>
    /// openstreetmap.org URL
    /// </summary>
    [JsonPropertyName("openstreetmap")]
    public string OpenStreetMap { get; set; }

    /// <summary>
    /// Google maps URL
    /// </summary>
    [JsonPropertyName("googlemaps")]
    public string GoogleMaps { get; set; }
  }

  /// <summary>
  /// GeoIP data
  /// </summary>
  public class GeoIpData {
    /// <summary>
    /// City
    /// </summary>
    [JsonPropertyName("city")] public string City { get; set; }

    /// <summary>
    /// Continent code (eg. NA)
    /// </summary>
    [JsonPropertyName("continent_code")] public string ContinentCode { get; set; }

    /// <summary>
    /// Continent name
    /// </summary>
    [JsonPropertyName("continent_name")] public string ContinentName { get; set; }

    /// <summary>
    /// Country code
    /// </summary>
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }

    /// <summary>
    /// Country name
    /// </summary>
    [JsonPropertyName("country_name")] public string CountryName { get; set; }

    /// <summary>
    /// Designated Market Area code
    /// </summary>
    [JsonPropertyName("dma_code")] public int? DmaCode { get; set; }

    /// <summary>
    /// yeah
    /// </summary>
    [JsonPropertyName("is_in_european_union")] public bool IsInEuropeanUnion { get; set; }

    /// <summary>
    /// Latitude
    /// </summary>
    [JsonPropertyName("latitude")] public double Latitude { get; set; }

    /// <summary>
    /// Longitude
    /// </summary>
    [JsonPropertyName("longitude")] public double Longitude { get; set; }

    /// <summary>
    /// Postal code
    /// </summary>
    [JsonPropertyName("postal_code")] public string PostalCode { get; set; }

    /// <summary>
    /// Region
    /// </summary>
    [JsonPropertyName("region")] public string Region { get; set; }

    /// <summary>
    /// Timezone
    /// </summary>
    [JsonPropertyName("time_zone")] public string TimeZone { get; set; }

    /// <summary>
    /// API URLs
    /// </summary>
    [JsonPropertyName("apis")]
    public GeoIpApis Apis { get; set; }
  }

  /// <summary>
  /// GeoIP
  /// </summary>
  public class GeoIp {
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
    /// GeoIP data
    /// </summary>
    [JsonPropertyName("data")]
    public GeoIpData Data { get; set; }
  }
}