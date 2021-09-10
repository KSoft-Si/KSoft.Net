using System.Threading.Tasks;
using KSoftNet.Models.Bans;
using KSoftNet.Requests;
using Refit;

namespace KSoftNet.Endpoints {
  /// <summary>
  /// Advanced and powerful global ban list API
  /// </summary>
  public interface IBansApi {
    /// <summary>
    /// This endpoint allows you to add bans to the list. If you don't have <c>BAN_MANAGER</c> permission your ban will be automatically converted to a ban report and we will take a look and act accordingly.
    /// </summary>
    /// <param name="banRequest">Ban information</param>
    /// <returns>Ban status</returns>
    [Post("/bans/add")]
    Task<Ban> AddBan([Body] BanRequest banRequest);

    /// <summary>
    /// Get more information about a ban
    /// </summary>
    /// <param name="user">User ID to check</param>
    /// <returns>Ban Info</returns>
    [Get("/bans/info")]
    Task<BanInfo> GetBanInfo(ulong user);

    /// <summary>
    /// Get more information about a ban
    /// </summary>
    /// <param name="user">User ID to check</param>
    /// <returns>Ban Info</returns>
    [Get("/bans/info")]
    Task<BanInfo> GetBanInfo(string user);

    /// <summary>
    /// Simple way to check if the user is banned
    /// </summary>
    /// <param name="user">User ID to check</param>
    /// <returns>Ban status</returns>
    [Get("/bans/check")]
    Task<BanCheck> CheckBan(ulong user);

    /// <summary>
    /// Simple way to check if the user is banned
    /// </summary>
    /// <param name="user">User ID to check</param>
    /// <returns>Ban status</returns>
    [Get("/bans/check")]
    Task<BanCheck> CheckBan(string user);

    /// <summary>
    /// Delete a ban, only users with <c>BAN_MANAGER</c> permission can use this.
    /// </summary>
    /// <param name="user">Users Discord ID</param>
    /// <param name="force">Default: false, if true it deletes the entry from the database instead of deactivating</param>
    /// <returns>Ban deletion status</returns>
    [Delete("/bans/delete")]
    Task<BanDeletion> DeleteBan(ulong user, bool force = false);

    /// <summary>
    /// Delete a ban, only users with <c>BAN_MANAGER</c> permission can use this.
    /// </summary>
    /// <param name="user">Users Discord ID</param>
    /// <param name="force">Default: false, if true it deletes the entry from the database instead of deactivating</param>
    /// <returns>Ban deletion status</returns>
    [Delete("/bans/delete")]
    Task<BanDeletion> DeleteBan(string user, bool force = false);

    /// <summary>
    /// Pagination of bans, you can request up to 1000 records per page, default is 20.
    /// </summary>
    /// <param name="page">Page number (default: 1)</param>
    /// <param name="perPage">Number of bans per page (default: 20)</param>
    /// <returns>Paginated ban list</returns>
    [Get("/bans/list")]
    Task<BanList> ListBans(int page = 1, [AliasAs("per_page")] int perPage = 20);

    /// <summary>
    /// Gets bans since timestamp
    /// </summary>
    /// <param name="timestamp">Timestamp in seconds from epoch</param>
    /// <returns>Ban list</returns>
    [Get("/bans/updates")]
    Task<BanUpdates> GetBanUpdates(long timestamp);
  }
}