using System;
using System.Collections.Generic;

namespace KSoft.Net.Responses
{


    public class KSoftWeatherAlert
    {
        public string Title { get; set; }
        public IList<string> Regions { get; set; }
        public string Severity { get; set; }
        public int Time { get; set; }
        public int Expires { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
    }

    public class KSoftWeatherLocation
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Address { get; set; }
    }

    public class KSoftWeatherData
    {
        public DateTime Time { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public int PrecipIntensity { get; set; }
        public int PrecipProbability { get; set; }
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public double WindGust { get; set; }
        public int WindBearing { get; set; }
        public double CloudCover { get; set; }
        public int UvIndex { get; set; }
        public double Visibility { get; set; }
        public double Ozone { get; set; }
        public object SunriseTime { get; set; }
        public object SunsetTime { get; set; }
        public string IconUrl { get; set; }
        public IList<KSoftWeatherAlert> Alerts { get; set; }
        public string Units { get; set; }
        public KSoftWeatherLocation Location { get; set; }
    }

    public class KSoftWeather
    {
        public bool Error { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public KSoftWeatherData Data { get; set; }
    }
}
