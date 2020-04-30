using RestSharp;
using System;

namespace KSoftNet.KSoft {
    public class KSoftAPI {
        const string BaseUrl = "https://api.ksoft.si/";
        readonly IRestClient _client;

        /// <summary>
        /// KSoftApi
        /// </summary>
        /// <param name="accountToken">KSoft token located on your dashboard</param>
        public KSoftAPI(string accountToken) => _client = new RestClient(BaseUrl) {
            Authenticator = new KSoftAuthenticator(accountToken)
        };

        public T Execute<T>(RestRequest request) where T : new() {
            IRestResponse<T> response = _client.Execute<T>(request);

            if (response.ErrorException != null) {
                const string errorMessage = "Error retrieving response. Check inner details for more info.";
                throw new ApplicationException(errorMessage, response.ErrorException);
            }
            return response.Data;
        }
    }
}