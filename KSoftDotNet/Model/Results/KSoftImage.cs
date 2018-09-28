using Newtonsoft.Json;

namespace KSoftDotNet.Model.Results
{
    public class KSoftImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("snowflake")]
        public string Snowflake { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
