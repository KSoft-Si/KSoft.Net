namespace KSoftNet.Responses {
    public class KSoftCurrency {
        public double Value { get; set; }
        public string Pretty { get; set; }

        // Error
        public bool Error { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
