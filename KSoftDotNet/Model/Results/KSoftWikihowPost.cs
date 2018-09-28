using Newtonsoft.Json;

namespace KSoftDotNet.Model.Results
{
    public class KSoftWikihowPost
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("article_url")]
        public string ArticleUrl { get; set; }
    }
}
