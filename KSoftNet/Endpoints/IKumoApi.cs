using System;
using System.Threading.Tasks;
using KSoftNet.Enums;
using KSoftNet.Models.Kumo;
using Refit;

namespace KSoftNet.Endpoints {
  /// <summary>
  /// This is advanced real-time information API for geo-spatial, weather and information gathering data
  /// </summary>
  public interface IKumoApi {
    /// <summary>
    /// You can get coordinates and more information about the searched location, if needed image of the area is generated.
    /// </summary>
    /// <param name="q">Your location query</param>
    /// <param name="fast">Default: fast, return location data faster, but with less information</param>
    /// <param name="more">Default: false, return more than one location</param>
    /// <param name="mapZoom">Default: 12, set your own zoom level, if fast is not set or false, then this setting will be ignored because map zoom is calculated</param>
    /// <param name="includeMap">Default: false, if to include an image of the area</param>
    /// <returns>Location</returns>
    [Get("/kumo/gis")]
    Task<Location> LocationSearch(string q, bool fast = true, bool more = false, int mapZoom = 12, bool includeMap = false);

    /// <summary>
    /// Gets weather by coordinates, this endpoint is faster than weather - easy, because it doesn't need to lookup the location.
    /// </summary>
    /// <param name="latitude">Latitude coordinate</param>
    /// <param name="longitude">Longitude coordinate</param>
    /// <param name="reportType">Select weather type. Can be one of: "currently", "minutely", "hourly", "daily"</param>
    /// <param name="units">Default: auto, select units, you can choose from: "si", "us", "uk2", "ca", "auto"</param>
    /// <param name="lang">Default: en, select language, all available languages: 'ar', 'az', 'be', 'bg', 'bs', 'ca', 'cs', 'da', 'de', 'el', 'en', 'es', 'et', 'fi', 'fr', 'he', 'hr', 'hu', 'id', 'is', 'it', 'ja', 'ka', 'ko', 'kw', 'nb', 'nl', 'no', 'pl', 'pt', 'ro', 'ru', 'sk', 'sl', 'sr', 'sv', 'tet', 'tr', 'uk', 'x-pig-latin', 'zh', 'zh-tw'</param>
    /// <param name="icons">Default: original, select icon pack</param>
    /// <returns>Weather</returns>
    [Obsolete("Weather endpoints are deprecated and no longer supported.")]
    [Get("/kumo/weather/{latitude},{longitude}/{report_type}")]
    Task<Weather> Weather(float latitude, float longitude, [AliasAs("report_type")] ReportType reportType, Unit units = Unit.Auto, Language lang = Language.En, IconPack icons = IconPack.Original);

    /// <summary>
    /// Gets location data from the IP address.
    /// </summary>
    /// <param name="ip">IP address</param>
    /// <returns>GeoIp response</returns>
    [Get("/kumo/geoip")]
    Task<GeoIp> GeoIp(string ip);

    /// <summary>
    /// Currency conversion
    /// </summary>
    /// <param name="from">Source currency</param>
    /// <param name="to">Destination currency</param>
    /// <param name="value">Value you want to convert</param>
    /// <returns>Currency response</returns>
    [Get("/kumo/currency")]
    Task<Currency> ConvertCurrency(CurrencyCode from, CurrencyCode to, float value);

    /// <summary>
    /// Currency conversion
    /// </summary>
    /// <param name="from">Source currency</param>
    /// <param name="to">Destination currency</param>
    /// <param name="value">Value you want to convert</param>
    /// <returns>Currency response</returns>
    [Get("/kumo/currency")]
    Task<Currency> ConvertCurrency(CurrencyCode from, CurrencyCode to, double value);
  }
}