namespace KSoftNet.Responses {
    public class KSoftBan {
        public bool Success { get; set; }
        public bool Exists { get; set; }

        // Error
        public int Code { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}