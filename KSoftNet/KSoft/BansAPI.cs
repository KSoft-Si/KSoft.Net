using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using KSoftNet.Models;

namespace KSoftNet.KSoft {
    /// <summary>
    ///     Advanced and powerful global ban list API
    /// </summary>
    public class BansAPI {

        private readonly KSoftAPI _kSoftAPI;
        /// <summary>
        ///     Advanced and powerful global ban list API
        /// </summary>
        /// <param name="kSoftAPI">Base KSoftAPI class</param>
        public BansAPI(KSoftAPI kSoftAPI) {
            _kSoftAPI = kSoftAPI;
        }

        #region Bans API

        /// <summary>
        ///     This endpoint allows you to add bans to the list. If you don't have BAN_MANAGER permission your ban will be
        ///     automatically converted to a ban report and we will take a look and act accordingly.
        /// </summary>
        /// <param name="userID">Users Discord ID that you are banning/reporting</param>
        /// <param name="reason">Reason why user should be globally banned</param>
        /// <param name="proof">URL of the image showing the act</param>
        /// <param name="mod">Users Discord ID who posted/reported the ban</param>
        /// <param name="userName">Users Discord username</param>
        /// <param name="userDiscriminator">Users Discord discriminator</param>
        /// <param name="appealPossible">If appeal should be disabled for that user.</param>
        /// <returns>KSoftBan</returns>
        public async Task<KSoftBan> AddBan(string userID, string reason, string proof, long mod = 0, string userName = "0", string userDiscriminator = "0", bool appealPossible = false) {

            var queries = new NameValueCollection {
                {"user", userID},
                {"reason", reason},
                {"proof", proof},
                {"mod", mod.ToString()},
                {"user_name", userName},
                {"user_discriminator", userDiscriminator},
                {"appeal_possible", appealPossible.ToString()}
            };


            return await _kSoftAPI.ExecuteAsync<KSoftBan>(HttpMethod.Get, "bans/add", queries);
        }

        /// <summary>
        ///     Get more information about a ban
        /// </summary>
        /// <param name="userID">Users Discord ID who's ban you'd like to check</param>
        /// <returns>KSoftBanInfo</returns>
        public async Task<KSoftBanInfo> BanInfo(string userID) {
            var queries = new NameValueCollection {{"user", userID}};

            return await _kSoftAPI.ExecuteAsync<KSoftBanInfo>(HttpMethod.Get, "bans/info", queries);
        }

        /// <summary>
        ///     Simple way to check if the user is banned
        /// </summary>
        /// <param name="userID">Users Discord ID that you'd like to check</param>
        /// <returns>KSoftBanCheck</returns>
        public async Task<KSoftBanCheck> BanCheck(string userID) {
            var queries = new NameValueCollection {{"user", userID}};

            return await _kSoftAPI.ExecuteAsync<KSoftBanCheck>(HttpMethod.Get, "bans/check", queries);
        }

        /// <summary>
        ///     Delete a ban, only users with BAN_MANAGER permission can use this.
        /// </summary>
        /// <param name="userID">Users Discord ID</param>
        /// <param name="force">Default: false, if true it deletes the entry from the database instead of deactivating</param>
        /// <returns>KSoftBanDeletion</returns>
        public async Task<KSoftBanDeletion> DeleteBan(string userID, bool force = false) {
            var queries = new NameValueCollection {{"user", userID}, {"force", force.ToString()}};


            return await _kSoftAPI.ExecuteAsync<KSoftBanDeletion>(HttpMethod.Delete, "bans/delete", queries);
        }

        /// <summary>
        ///     Pagination of bans, you can request up to 1000 records per page, default is 20.
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="perPage">Number of bans per page (default: 20)</param>
        /// <returns>KSoftBanList</returns>
        public async Task<KSoftBanList> BanList(int page, int perPage) {
            var queries = new NameValueCollection {{"page", page.ToString()}, {"per_page", perPage.ToString()}};

            return await _kSoftAPI.ExecuteAsync<KSoftBanList>(HttpMethod.Get, "bans/list", queries);
        }

        /// <summary>
        ///     Gets updates from the previous update
        /// </summary>
        /// <param name="timestamp">Timestamp in seconds from 1.1.1970 (epoch time)</param>
        /// <returns>KSoftBanUpdates</returns>
        public async Task<KSoftBanUpdates> BanUpdates(DateTime timestamp) {
            var queries = new NameValueCollection {{"timestamp", ((DateTimeOffset)timestamp).ToUnixTimeSeconds().ToString()}};

            return await _kSoftAPI.ExecuteAsync<KSoftBanUpdates>(HttpMethod.Get, "bans/updates", queries);
        }

        #endregion
    }
}