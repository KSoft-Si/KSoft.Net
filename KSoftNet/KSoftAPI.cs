using System;
using System.Net.Http;
using System.Net.Http.Headers;
using KSoftNet.Endpoints;
using KSoftNet.Utils;
using Newtonsoft.Json;
using Refit;

namespace KSoftNet {
  /// <summary>
  ///   KSoftApi class
  /// </summary>
  public class KSoftApi {
    /// <summary>
    /// Random hand-picked images, random memes from Reddit and other Reddit parsers.
    /// </summary>
    public IImagesApi ImagesApi { get; private set; }

    /// <summary>
    /// This is advanced real-time information API for geo-spatial, weather and information gathering data
    /// </summary>
    public IKumoApi KumoApi { get; private set; }

    /// <summary>
    /// Advanced and powerful global ban list API
    /// </summary>
    public IBansApi BansApi { get; private set; }

    /// <summary>
    /// This API provides deep and powerful tools for searching lyrics, artists or albums. Unlike other APIs, it can also search by lyrics and does not need a separate artist and song name entries.
    /// </summary>
    public IMusicApi MusicApi { get; private set; }

    private const string BaseUrl = ("https://api.ksoft.si");
    // private const string BaseUrl = ("https://postman-echo.com");

    /// <summary>
    /// Constructor with token only
    /// </summary>
    /// <param name="token">KSoft api v1 token</param>
    public KSoftApi(string token) {
      var httpClient = new HttpClient() {
        BaseAddress = new Uri(BaseUrl),
        DefaultRequestHeaders = {
          Authorization = new AuthenticationHeaderValue("Bearer", token)
        }
      };

      Initialize(httpClient);
    }

    /// <summary>
    /// Constructor with custom HttpClient, must set BaseAddress and Authorization header manually
    /// </summary>
    /// <param name="httpClient">HttpClient instance</param>
    public KSoftApi(HttpClient httpClient) {
      Initialize(httpClient);
    }

    private void Initialize(HttpClient httpClient) {
      var refitSettings = new RefitSettings {
        UrlParameterFormatter = new ParameterFormatter()
      };

      ImagesApi = RestService.For<IImagesApi>(httpClient, refitSettings);
      BansApi = RestService.For<IBansApi>(httpClient, refitSettings);
      KumoApi = RestService.For<IKumoApi>(httpClient, refitSettings);
      MusicApi = RestService.For<IMusicApi>(httpClient, refitSettings);
    }
  }

}