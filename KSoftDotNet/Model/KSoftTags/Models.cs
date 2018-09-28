using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace KSoftDotNet.Model.KSoftTags
{
    public class Model
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }
    }
}
