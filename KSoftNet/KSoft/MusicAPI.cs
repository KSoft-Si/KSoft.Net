using KSoftNet.Models;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KSoftNet.KSoft {
    /// <summary>
    /// This API provides deep and powerful tools for searching lyrics, artists or albums. Unlike other APIs, it can also search by lyrics and does not need a separate artist and song name entries.
    /// </summary>
    public class MusicAPI {

        private readonly KSoftAPI _kSoftAPI;
        /// <summary>
        /// This API provides deep and powerful tools for searching lyrics, artists or albums. Unlike other APIs, it can also search by lyrics and does not need a separate artist and song name entries.
        /// </summary>
        /// <param name="kSoftAPI">Base KSoftAPI class</param>
        public MusicAPI(KSoftAPI kSoftAPI) {
            _kSoftAPI = kSoftAPI;
        }
        #region Music API

        /// <summary>
        /// Searches for lyrics and returns a list of results.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="textOnly">Default: false, if set to 'true' then it only searches inside the lyrics.</param>
        /// <param name="limit">Default: 10, how many results should the endpoint return.</param>
        /// <returns>KSoftLyrics</returns>
        public async Task<KSoftLyrics> SearchLyrics(string query, bool textOnly, int limit) {
            NameValueCollection queries = new NameValueCollection();

            queries.Add(name: "q", value: query);
            queries.Add(name: "text_only", value: textOnly.ToString());
            queries.Add(name: "limit", value: limit.ToString());

            return await _kSoftAPI.ExecuteAsync<KSoftLyrics>(HttpMethod.Get, $"lyrics/search", queries);
        }

        /// <summary>
        /// Retrieves music recommendations based on tracks user inputs.    
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="provider">Format in which you'll provide tracks. Can be: youtube, youtube_ids, spotify</param>
        /// <returns>KSoftRecommendations</returns>
        public async Task<KSoftRecommendations> MusicRecommendations(string[] tracks, string provider) {
            StringContent json = new StringContent(JsonConvert.SerializeObject(new { tracks, provider }), Encoding.UTF8, "application/json");

            return await _kSoftAPI.ExecuteAsync<KSoftRecommendations>(HttpMethod.Post, $"music/recommendations", json);
        }

        /// <summary>
        /// Retrieves all albums and songs by that artist.
        /// </summary>
        /// <param name="id">Artist ID, you can get it from the lyrics search</param>
        /// <returns>KSoftArtistInfo</returns>
        public async Task<KSoftArtistInfo> ArtistByID(int id) {
            return await _kSoftAPI.ExecuteAsync<KSoftArtistInfo>(HttpMethod.Get, $"lyrics/artist/{id}");
        }

        /// <summary>
        /// Retrieves artist name and all tracks in the album.
        /// </summary>
        /// <param name="id">Album ID, you can get it from the lyrics search</param>
        /// <returns>KSoftAlbumInfo</returns>
        public async Task<KSoftAlbumInfo> AlbumByID(int id) {
            return await _kSoftAPI.ExecuteAsync<KSoftAlbumInfo>(HttpMethod.Get, $"lyrics/album/{id}");
        }

        /// <summary>
        /// Get info about a song.
        /// </summary>
        /// <param name="id">Track ID, you can get it from artist by id, album by id or lyrics search endpoints</param>
        /// <returns>KSoftTrackInfo</returns>
        public async Task<KSoftTrackInfo> TrackByID(int id) {
            return await _kSoftAPI.ExecuteAsync<KSoftTrackInfo>(HttpMethod.Get, $"lyrics/track/{id}");
        }

        #endregion

    }
}