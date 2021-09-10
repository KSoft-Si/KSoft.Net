using System.Threading.Tasks;
using KSoftNet.Models.Music;
using KSoftNet.Requests;
using Refit;

namespace KSoftNet.Endpoints {
  /// <summary>
  /// This API provides deep and powerful tools for searching lyrics, artists or albums.
  /// Unlike other APIs, it can also search by lyrics and does not need a separate artist and song name entries.
  /// </summary>
  public interface IMusicApi {
    /// <summary>
    /// Retrieves all albums and songs by that artist.
    /// </summary>
    /// <param name="id">Artist ID, you can get it from the lyrics search</param>
    /// <returns>Artist info</returns>
    [Get("/lyrics/artist/{id}")]
    Task<ArtistInfo> GetArtistById(string id);

    /// <summary>
    /// Retrieves all albums and songs by that artist.
    /// </summary>
    /// <param name="id">Artist ID, you can get it from the lyrics search</param>
    /// <returns>Artist info</returns>
    [Get("/lyrics/artist/{id}")]
    Task<ArtistInfo> GetArtistById(int id);

    /// <summary>
    /// Retrieves artist name and all tracks in the album.
    /// </summary>
    /// <param name="id">Album ID, you can get it from the lyrics search</param>
    /// <returns>Album info</returns>
    [Get("/lyrics/album/{id}")]
    Task<AlbumInfo> GetAlbumById(string id);

    /// <summary>
    /// Retrieves artist name and all tracks in the album.
    /// </summary>
    /// <param name="id">Album ID, you can get it from the lyrics search</param>
    /// <returns>Album info</returns>
    [Get("/lyrics/album/{id}")]
    Task<AlbumInfo> GetAlbumById(int id);

    /// <summary>
    /// Get info about a song.
    /// </summary>
    /// <param name="id">Track ID, you can get it from artist by id, album by id or lyrics search endpoints</param>
    /// <returns>Track info</returns>
    [Get("/lyrics/track/{id}")]
    Task<TrackInfo> GetTrackById(string id);

    /// <summary>
    /// Get info about a song.
    /// </summary>
    /// <param name="id">Track ID, you can get it from artist by id, album by id or lyrics search endpoints</param>
    /// <returns>Track info</returns>
    [Get("/lyrics/track/{id}")]
    Task<TrackInfo> GetTrackById(int id);

    /// <summary>
    /// Retrieves music recommendations based on tracks user inputs.
    /// </summary>
    /// <param name="request">Recommendation request</param>
    /// <returns>Recommendations</returns>
    [Get("/music/recommendations")]
    Task<Recommendations> MusicRecommendations(RecommendationRequest request);
  }
}