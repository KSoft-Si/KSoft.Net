using System.Collections.Generic;

namespace KSoft.Net.Responses
{
    public class KSoftLocationData
    {
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public IList<string> BoundingBox { get; set; }
        public IList<string> Type { get; set; }
        public string Map { get; set; }
    }

    public class KSoftLocation
    {
        public bool Error { get; set; }
        public int Code { get; set; }
        public KSoftLocationData Data { get; set; }
        public string Message { get; set; }
    }
}