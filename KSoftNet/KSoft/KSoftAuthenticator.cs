using RestSharp;
using RestSharp.Authenticators;
namespace KSoftNet.KSoft {
    class KSoftAuthenticator : IAuthenticator {

        private string _token;
        public KSoftAuthenticator(string token) {
            _token = token;
        }

        public void Authenticate(IRestClient client, IRestRequest request) {
            request.AddHeader("Authorization", "Bearer " + _token);
        }
    }
}
