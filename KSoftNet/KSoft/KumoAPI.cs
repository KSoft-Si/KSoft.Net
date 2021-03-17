using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using KSoftNet.Models;

namespace KSoftNet.KSoft {
    /// <summary>
    ///     This is advanced real-time information API for geo-spatial, weather and information gathering data
    /// </summary>
    public class KumoAPI {

        private readonly KSoftAPI _kSoftAPI;

        /// <summary>
        ///     This is advanced real-time information API for geo-spatial, weather and information gathering data
        /// </summary>
        /// <param name="kSoftAPI">Base KSoftAPI class</param>
        public KumoAPI(KSoftAPI kSoftAPI) {
            _kSoftAPI = kSoftAPI;
        }

        #region Kumo API

        /// <summary>
        ///     Gets weather by location.
        /// </summary>
        /// <param name="reportType">
        ///     Select weather report type. Can be one of: "currently", value: "minutely", value: "hourly",
        ///     value: "daily"
        /// </param>
        /// <param name="query">Location query</param>
        /// <param name="units">
        ///     Default: auto, select units, you can choose from: "si", value: "us", value: "uk2", value: "ca",
        ///     value: "auto"
        /// </param>
        /// <param name="language">
        ///     Default: en, select language, all available languages: 'ar', 'az', 'be', 'bg', 'bs', 'ca', 'cs',
        ///     'da', 'de', 'el', 'en', 'es', 'et', 'fi', 'fr', 'he', 'hr', 'hu', 'id', 'is', 'it', 'ja', 'ka', 'ko', 'kw', 'nb',
        ///     'nl', 'no', 'pl', 'pt', 'ro', 'ru', 'sk', 'sl', 'sr', 'sv', 'tet', 'tr', 'uk', 'x-pig-latin', 'zh', 'zh-tw'
        /// </param>
        /// <param name="icons">Default: original, select icon pack</param>
        /// <returns>KSoftWeather</returns>
        [Obsolete("Kumo weather endpoints are deprecated and not supported.")]
        public async Task<KSoftWeather> BasicWeather(string reportType, string query, string units = "auto", string language = "en", string icons = "original") {
            var queries = new NameValueCollection {{"q", query}, {"units", units}, {"lang", language}, {"icons", icons}};

            return await _kSoftAPI.ExecuteAsync<KSoftWeather>(HttpMethod.Get, $"kumo/weather/{reportType}", queries);
        }

        /// <summary>
        ///     Gets location data from the IP address.
        /// </summary>
        /// <param name="ip">IP address</param>
        /// <returns>KSoftGeoIP</returns>
        public async Task<KSoftGeoIP> GeoIP(string ip) {
            var queries = new NameValueCollection {{"ip", ip}};

            return await _kSoftAPI.ExecuteAsync<KSoftGeoIP>(HttpMethod.Get, "kumo/geoip", queries);
        }

        /// <summary>
        ///     Currency conversion.
        /// </summary>
        /// <param name="from">ISO Standard for 3 letter currency naming: https://en.wikipedia.org/wiki/ISO_4217#Active_codes</param>
        /// <param name="to">ISO Standard for 3 letter currency naming: https://en.wikipedia.org/wiki/ISO_4217#Active_codes</param>
        /// <param name="value">Float or Integer you want to convert</param>
        /// <returns>KSoftCurrency</returns>
        public async Task<KSoftCurrency> CurrencyConversion(string from, string to, float value) {
            var queries = new NameValueCollection {{"from", from}, {"to", to}, {"value", value.ToString(CultureInfo.InvariantCulture)}};

            return await _kSoftAPI.ExecuteAsync<KSoftCurrency>(HttpMethod.Get, "kumo/currency", queries);
        }

        #endregion
    }
}