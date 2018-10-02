using Newtonsoft.Json;

namespace KSoftDotNet.Model.Results
{
    public class KSoftBan
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("exists")]
        public bool Exists { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
