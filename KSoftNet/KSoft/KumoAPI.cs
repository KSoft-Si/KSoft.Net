using KSoftNet.Responses;
using RestSharp;

namespace KSoftNet.KSoft {
    /// <summary>
    /// This is advanced real-time information API for geo-spatial, weather and information gathering data
    /// </summary>
    public class KumoAPI {

        private KSoftAPI _kSoftAPI;

        public KumoAPI(KSoftAPI kSoftAPI) {
            _kSoftAPI = kSoftAPI;
        }

        #region Kumo API

        /// <summary>
        /// You can get coordinates and more information about the searched location, if needed image of the area is generated.
        /// </summary>
        /// <param name="query">Your location query</param>
        /// <param name="fast">Default: fast, return location data faster, but with less information</param>
        /// <param name="more">Default: false, return more than one location</param>
        /// <param name="mapZoom">Default: 12, set your own zoom level, if fast is not set or false, then this setting will be ignored because map zoom is calculated</param>
        /// <param name="includeMap">Default: false, if to include an image of the area</param>
        /// <returns>KSoftLocation</returns>
        public KSoftLocation SearchLocation(string query, bool fast = false, bool more = false, int mapZoom = 12, bool includeMap = false) {
            RestRequest request = new RestRequest("kumo/gis");

            request.AddQueryParameter(name: "q", value: query);
            request.AddQueryParameter(name: "fast", value: fast.ToString());
            request.AddQueryParameter(name: "more", value: more.ToString());
            request.AddQueryParameter(name: "map_zoom", value: mapZoom.ToString());
            request.AddQueryParameter(name: "include_map", value: includeMap.ToString());

            return _kSoftAPI.Execute<KSoftLocation>(request);
        }

        /// <summary>
        /// Gets weather by location.
        /// </summary>
        /// <param name="reportType">Select weather report type. Can be one of: "currently", value: "minutely", value: "hourly", value: "daily"  </param>
        /// <param name="query">Location query</param>
        /// <param name="units">Default: auto, select units, you can choose from: "si", value: "us", value: "uk2", value: "ca", value: "auto"</param>
        /// <param name="language">Default: en, select language, all available languages: 'ar', 'az', 'be', 'bg', 'bs', 'ca', 'cs', 'da', 'de', 'el', 'en', 'es', 'et', 'fi', 'fr', 'he', 'hr', 'hu', 'id', 'is', 'it', 'ja', 'ka', 'ko', 'kw', 'nb', 'nl', 'no', 'pl', 'pt', 'ro', 'ru', 'sk', 'sl', 'sr', 'sv', 'tet', 'tr', 'uk', 'x-pig-latin', 'zh', 'zh-tw'</param>
        /// <param name="icons">Default: original, select icon pack</param>
        /// <returns>KSoftWeather</returns>
        public KSoftWeather BasicWeather(string reportType, string query, string units = "auto", string language = "en", string icons = "original") {
            RestRequest request = new RestRequest($"kumo/weather/{reportType}");

            request.AddQueryParameter(name: "q", value: query);
            request.AddQueryParameter(name: "units", value: units);
            request.AddQueryParameter(name: "lang", value: language);
            request.AddQueryParameter(name: "icons", value: icons);

            return _kSoftAPI.Execute<KSoftWeather>(request);
        }

        /// <summary>
        /// Gets weather by coordinates, this endpoint is faster than weather - easy, because it doesn't need to lookup the location.
        /// </summary>
        /// <param name="latitude">Latitude coordinate</param>
        /// <param name="longitude">Longitude coordinate</param>
        /// <param name="reportType">Select weather type. Can be one of: "currently", value: "minutely", value: "hourly", value: "daily"</param>
        /// <param name="units">Default: auto, select units, you can choose from: "si", value: "us", value: "uk2", value: "ca", value: "auto"</param>
        /// <param name="language">Default: en, select language, all available languages: 'ar', 'az', 'be', 'bg', 'bs', 'ca', 'cs', 'da', 'de', 'el', 'en', 'es', 'et', 'fi', 'fr', 'he', 'hr', 'hu', 'id', 'is', 'it', 'ja', 'ka', 'ko', 'kw', 'nb', 'nl', 'no', 'pl', 'pt', 'ro', 'ru', 'sk', 'sl', 'sr', 'sv', 'tet', 'tr', 'uk', 'x-pig-latin', 'zh', 'zh-tw'</param>
        /// <param name="icons">Default: original, select icon pack</param>
        /// <returns>KSoftWeather</returns>
        public KSoftWeather AdvancedWeather(float latitude, float longitude, string reportType, string units = "auto", string language = "en", string icons = "original") {
            RestRequest request = new RestRequest($"kumo/weather/{latitude},{longitude}/{reportType}");

            request.AddQueryParameter(name: "units", value: units);
            request.AddQueryParameter(name: "lang", value: language);
            request.AddQueryParameter(name: "icons", value: icons);

            return _kSoftAPI.Execute<KSoftWeather>(request);
        }

        /// <summary>
        /// Gets location data from the IP address.
        /// </summary>
        /// <param name="ip">IP address</param>
        /// <returns>KSoftGeoIP</returns>
        public KSoftGeoIP GeoIP(string ip) {
            RestRequest request = new RestRequest($"kumo/geoip");

            request.AddQueryParameter(name: "ip", value: ip);

            return _kSoftAPI.Execute<KSoftGeoIP>(request);
        }

        /// <summary>
        /// Currency conversion.
        /// </summary>
        /// <param name="from">ISO Standard for 3 letter currency naming: https://en.wikipedia.org/wiki/ISO_4217#Active_codes</param>
        /// <param name="to">ISO Standard for 3 letter currency naming: https://en.wikipedia.org/wiki/ISO_4217#Active_codes</param>
        /// <param name="value">Float or Integer you want to convert</param>
        /// <returns>KSoftCurrency</returns>
        public KSoftCurrency CurrencyConversion(string from, string to, float value) {
            RestRequest request = new RestRequest($"kumo/currency");

            request.AddQueryParameter(name: "from", value: from);
            request.AddQueryParameter(name: "to", value: to);
            request.AddQueryParameter(name: "value", value: value.ToString());

            return _kSoftAPI.Execute<KSoftCurrency>(request);
        }

        #endregion

    }
}