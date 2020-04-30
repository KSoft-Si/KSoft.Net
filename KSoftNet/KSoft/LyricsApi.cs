using KSoftNet.Responses;
using RestSharp;

namespace KSoftNet.KSoft {
    /// <summary>
    /// This API provides deep and powerful tools for searching lyrics, artists or albums. Unlike other APIs, it can also search by lyrics and does not need a separate artist and song name entries.
    /// </summary>
    public class LyricsAPI {

        private KSoftAPI _kSoftAPI;
        public LyricsAPI(KSoftAPI kSoftAPI) {
            _kSoftAPI = kSoftAPI;
        }
        #region Lyrics API

        /// <summary>
        /// Searches for lyrics and returns a list of results.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="textOnly">Default: false, if set to 'true' then it only searches inside the lyrics.</param>
        /// <param name="limit">Default: 10, how many results should the endpoint return.</param>
        /// <returns>KSoftLyrics</returns>
        public KSoftLyrics SearchLyrics(string query, bool textOnly, int limit) {
            RestRequest request = new RestRequest($"lyrics/search");

            request.AddQueryParameter(name: "q", value: query);
            request.AddQueryParameter(name: "text_only", value: textOnly.ToString());
            request.AddQueryParameter(name: "limit", value: limit.ToString());

            return _kSoftAPI.Execute<KSoftLyrics>(request);
        }

        /// <summary>
        /// Retrieves music recommendations based on tracks user inputs.
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="provider">Format in which you'll provide tracks. Can be: youtube, youtube_ids, spotify</param>
        /// <returns>KSoftRecommendations</returns>
        public KSoftRecommendations MusicRecommendations(string[] tracks, string provider) {
            var request = new RestRequest($"music/recommendations", Method.POST);

            request.AddJsonBody(tracks);
            request.AddJsonBody(provider);

            return _kSoftAPI.Execute<KSoftRecommendations>(request);
        }

        /// <summary>
        /// Retrieves all albums and songs by that artist.
        /// </summary>
        /// <param name="id">Artist ID, you can get it from the lyrics search</param>
        /// <returns>KSoftArtistInfo</returns>
        public KSoftArtistInfo ArtistByID(int id) {
            RestRequest request = new RestRequest($"lyrics/artist/{id}");

            return _kSoftAPI.Execute<KSoftArtistInfo>(request);
        }

        /// <summary>
        /// Retrieves artist name and all tracks in the album.
        /// </summary>
        /// <param name="id">Album ID, you can get it from the lyrics search</param>
        /// <returns>KSoftAlbumInfo</returns>
        public KSoftAlbumInfo AlbumByID(int id) {
            RestRequest request = new RestRequest($"lyrics/album/{id}");

            return _kSoftAPI.Execute<KSoftAlbumInfo>(request);
        }

        /// <summary>
        /// Get info about a song.
        /// </summary>
        /// <param name="id">Track ID, you can get it from artist by id, album by id or lyrics search endpoints</param>
        /// <returns>KSoftTrackInfo</returns>
        public KSoftTrackInfo TrackByID(int id) {
            RestRequest request = new RestRequest($"lyrics/track/{id}");

            return _kSoftAPI.Execute<KSoftTrackInfo>(request);
        }

        #endregion

    }
}