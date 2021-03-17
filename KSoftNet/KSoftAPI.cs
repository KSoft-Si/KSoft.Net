using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using KSoftNet.KSoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KSoftNet {
    /// <summary>
    ///     KSoftAPI class
    /// </summary>
    public class KSoftAPI {
        /// <summary>
        ///     Base KSoft API url. Don't change unless you know what you're doing
        /// </summary>
        public const string BaseUrl = "https://api.ksoft.si/";

        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Advanced and powerful global ban list API
        /// </summary>
        public readonly BansAPI bansAPI;

        /// <summary>
        ///     Random hand-picked images, random memes from Reddit and other Reddit parsers.
        /// </summary>
        public readonly ImagesAPI imagesAPI;

        /// <summary>
        ///     This is advanced real-time information API for geo-spatial, weather and information gathering data
        /// </summary>
        public readonly KumoAPI kumoAPI;

        /// <summary>
        ///     This API provides deep and powerful tools for searching lyrics, artists or albums. Unlike other APIs, it can also
        ///     search by lyrics and does not need a separate artist and song name entries.
        /// </summary>
        public readonly MusicAPI musicAPI;

        /// <summary>
        ///     KSoftAPI class
        /// </summary>
        /// <param name="accountToken">KSoft api token located on your dashboard</param>
        public KSoftAPI(string accountToken) {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accountToken);

            imagesAPI = new ImagesAPI(this);
            kumoAPI = new KumoAPI(this);
            bansAPI = new BansAPI(this);
            musicAPI = new MusicAPI(this);
        }

        private async Task<T> DoShitAsync<T>(HttpMethod method, string endpoint, NameValueCollection queries = null,
            HttpContent jsonContent = null) where T : new() {
            var builder = new UriBuilder(BaseUrl) {Port = -1, Path = endpoint};

            var query = HttpUtility.ParseQueryString(builder.Query);

            if (queries != null) query.Add(queries);

            builder.Query = query.ToString();
            var url = builder.ToString();

            HttpResponseMessage response;

            if (jsonContent != null)
                response = await _httpClient.PostAsync(url, jsonContent);
            else
                response = await _httpClient.SendAsync(new HttpRequestMessage(method, url));

            if (!response.IsSuccessStatusCode) throw new HttpRequestException("401: Unauthorized. Is your token valid?");

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerSettings {
                    ContractResolver = new DefaultContractResolver {NamingStrategy = new SnakeCaseNamingStrategy()}
                });
        }

        /// <summary>
        ///     Get response from the specified KSoft endpoint
        /// </summary>
        /// <typeparam name="T">JSON deserialization response model</typeparam>
        /// <param name="method">HTTP Method</param>
        /// <param name="endpoint">Endpoint URL</param>
        /// <param name="queries">Name Value Collection of query names and values</param>
        /// <param name="jsonContent">JSON body</param>
        /// <returns>Deserialized JSON model</returns>
        public async Task<T> ExecuteAsync<T>(HttpMethod method, string endpoint, NameValueCollection queries,
            StringContent jsonContent) where T : new() {
            return await DoShitAsync<T>(method, endpoint, queries, jsonContent);
        }

        /// <summary>
        ///     Get response from the specified KSoft endpoint
        /// </summary>
        /// <typeparam name="T">JSON deserialization response model</typeparam>
        /// <param name="method">HTTP Method</param>
        /// <param name="endpoint">Endpoint URL</param>
        /// <param name="queries">Name Value Collection of query names and values</param>
        /// <returns>Deserialized JSON model</returns>
        public async Task<T> ExecuteAsync<T>(HttpMethod method, string endpoint, NameValueCollection queries)
            where T : new() {
            return await DoShitAsync<T>(method, endpoint, queries);
        }

        /// <summary>
        ///     Get response from the specified KSoft endpoint
        /// </summary>
        /// <typeparam name="T">JSON deserialization response model</typeparam>
        /// <param name="method">HTTP Method</param>
        /// <param name="endpoint">Endpoint URL</param>
        /// <param name="jsonContent">JSON body</param>
        /// <returns>Deserialized JSON model</returns>
        public async Task<T> ExecuteAsync<T>(HttpMethod method, string endpoint, StringContent jsonContent)
            where T : new() {
            return await DoShitAsync<T>(method, endpoint, null, jsonContent);
        }

        /// <summary>
        ///     Get response from the specified KSoft endpoint
        /// </summary>
        /// <typeparam name="T">JSON deserialization response model</typeparam>
        /// <param name="method">HTTP Method</param>
        /// <param name="endpoint">Endpoint URL</param>
        /// <returns>Deserialized JSON model</returns>
        public async Task<T> ExecuteAsync<T>(HttpMethod method, string endpoint) where T : new() {
            return await DoShitAsync<T>(method, endpoint);
        }
    }
}