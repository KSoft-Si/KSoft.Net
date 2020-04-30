namespace KSoftNet.Responses {
    public class KSoftImage {
        public string Url { get; set; }
        public string Snowflake { get; set; }
        public bool Nsfw { get; set; }
        public string Tag { get; set; }

        // Error

        /// <summary>
        /// Error code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public bool Cache { get; set; }
    }
}
