namespace KSoft.Net.Responses
{
    public class KSoftGeoIPApis
    {
        public string Weather { get; set; }
        public string Gis { get; set; }
        public string Openstreetmap { get; set; }
        public string Googlemaps { get; set; }
    }

    public class KSoftGeoIPData
    {
        public string City { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public object DmaCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string TimeZone { get; set; }
        public KSoftGeoIPApis Apis { get; set; }
    }

    public class KSoftGeoIP
    {
        public bool Error { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public KSoftGeoIPData Data { get; set; }
    }
}