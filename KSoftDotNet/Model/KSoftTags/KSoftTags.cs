using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace KSoftDotNet.Model.KSoftTags
{
    public class KSoftTags
    {
        [JsonProperty("models")]
        public IList<Model> Models { get; set; }

        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        [JsonProperty("nsfw_tags")]
        public IList<string> Nsfw_tags { get; set; }
    }
}
