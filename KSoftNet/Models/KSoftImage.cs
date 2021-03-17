namespace KSoftNet.Models {
    public class KSoftImage {
        public string Url { get; set; }
        public string Snowflake { get; set; }
        public bool Nsfw { get; set; }
        public string Tag { get; set; }

        // Error

        public int Code { get; set; }
        public string Message { get; set; }
        public bool Cache { get; set; }
    }
}