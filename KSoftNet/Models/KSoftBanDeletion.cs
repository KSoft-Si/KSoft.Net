namespace KSoftNet.Responses {
    public class KSoftBanDeletion {
        public string Done { get; set; }

        // Error
        public int Code { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}