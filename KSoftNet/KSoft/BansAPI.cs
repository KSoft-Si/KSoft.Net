using KSoftNet.Responses;
using RestSharp;
using System;

namespace KSoftNet.KSoft {
    /// <summary>
    /// Advanced and powerful global ban list API
    /// </summary>
    public class BansAPI {

        private KSoftAPI _kSoftAPI;
        public BansAPI(KSoftAPI kSoftAPI) {
            _kSoftAPI = kSoftAPI;
        }

        #region Bans API

        /// <summary>
        /// This endpoint allows you to add bans to the list. If you don't have BAN_MANAGER permission your ban will be automatically converted to a ban report and we will take a look and act accordingly.
        /// </summary>
        /// <param name="userID">Users Discord ID that you are banning/reporting</param>
        /// <param name="reason">Reason why user should be globally banned</param>
        /// <param name="proof">URL of the image showing the act</param>
        /// <param name="mod">Users Discord ID who posted/reported the ban</param>
        /// <param name="userName">Users Discord username</param>
        /// <param name="userDiscriminator">Users Discord discriminator</param>
        /// <param name="appealPossible">If appeal should be disabled for that user.</param>
        /// <returns>KSoftBan</returns>
        public KSoftBan AddBan(long userID, string reason, string proof, long mod = 0, string userName = "0", string userDiscriminator = "0", bool appealPossible = false) {
            RestRequest request = new RestRequest("bans/add", Method.POST);

            request.AddQueryParameter(name: "user", value: userID.ToString());
            request.AddQueryParameter(name: "reason", value: reason);
            request.AddQueryParameter(name: "proof", value: proof);
            request.AddQueryParameter(name: "mod", value: mod.ToString());
            request.AddQueryParameter(name: "user_name", value: userName);
            request.AddQueryParameter(name: "user_discriminator", value: userDiscriminator);
            request.AddQueryParameter(name: "appeal_possible", value: appealPossible.ToString());

            return _kSoftAPI.Execute<KSoftBan>(request);
        }

        /// <summary>
        /// Get more information about a ban
        /// </summary>
        /// <param name="userID">Users Discord ID who's ban you'd like to check</param>
        /// <returns>KSoftBanInfo</returns>
        public KSoftBanInfo BanInfo(long userID) {
            RestRequest request = new RestRequest("bans/info");

            request.AddQueryParameter(name: "user", value: userID.ToString());

            return _kSoftAPI.Execute<KSoftBanInfo>(request);
        }

        /// <summary>
        /// Simple way to check if the user is banned
        /// </summary>
        /// <param name="userID">Users Discord ID that you'd like to check</param>
        /// <returns>KSoftBanCheck</returns>
        public KSoftBanCheck BanCheck(long userID) {
            RestRequest request = new RestRequest("bans/check");

            request.AddQueryParameter(name: "user", value: userID.ToString());

            return _kSoftAPI.Execute<KSoftBanCheck>(request);
        }

        /// <summary>
        /// Delete a ban, only users with BAN_MANAGER permission can use this.
        /// </summary>
        /// <param name="userID">Users Discord ID</param>
        /// <param name="force">Default: false, if true it deletes the entry from the database instead of deactivating</param>
        /// <returns>KSoftBanDeletion</returns>
        public KSoftBanDeletion DeleteBan(long userID, bool force = false) {
            RestRequest request = new RestRequest("bans/delete", Method.DELETE);

            request.AddQueryParameter(name: "user", value: userID.ToString());
            request.AddQueryParameter(name: "force", value: force.ToString());

            return _kSoftAPI.Execute<KSoftBanDeletion>(request);
        }

        /// <summary>
        /// Pagination of bans, you can request up to 1000 records per page, default is 20.
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="perPage">Number of bans per page (default: 20)</param>
        /// <returns>KSoftBanList</returns>
        public KSoftBanList BanList(int page, int perPage) {
            RestRequest request = new RestRequest("bans/list");

            request.AddQueryParameter(name: "page", value: page.ToString());
            request.AddQueryParameter(name: "per_page", value: perPage.ToString());

            return _kSoftAPI.Execute<KSoftBanList>(request);
        }

        /// <summary>
        /// Gets updates from the previous update
        /// </summary>
        /// <param name="timestamp">Timestamp in seconds from 1.1.1970 (epoch time)</param>
        /// <returns>KSoftBanUpdates</returns>
        public KSoftBanUpdates BanUpdates(DateTimeOffset timestamp) {
            RestRequest request = new RestRequest("bans/updates");

            request.AddQueryParameter(name: "timestamp", value: timestamp.ToUnixTimeSeconds().ToString());

            return _kSoftAPI.Execute<KSoftBanUpdates>(request);
        }

        #endregion

    }
}
