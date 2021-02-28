using System.Collections.Generic;

namespace KSoftNet.Models {
    public class Model {
        public string Name { get; set; }
        public bool Nsfw { get; set; }
    }

    public class KSoftTags {
        public IList<Model> Models { get; set; }
        public IList<string> Tags { get; set; }
        public IList<string> NsfwTags { get; set; }
    }
}
