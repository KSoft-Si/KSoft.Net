using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KSoftNet.Models.Kumo {

  /// <summary>
  /// Location
  /// </summary>
  public class WeatherLocation {
    /// <summary>
    /// Latitude
    /// </summary>
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude
    /// </summary>
    [JsonPropertyName("lon")]
    public double Longitude { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    [JsonPropertyName("address")]
    public object Address { get; set; }
  }

  /// <summary>
  /// Weather data
  /// </summary>
  public class WeatherData {
    /// <summary>
    /// Time of data
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    /// <summary>
    /// Summary
    /// </summary>
    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    /// <summary>
    /// Icon
    /// </summary>
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    /// <summary>
    /// Distance to nearest storm
    /// </summary>
    [JsonPropertyName("nearestStormDistance")]
    public int NearestStormDistance { get; set; }

    /// <summary>
    /// Bearing of nearest storm
    /// </summary>
    [JsonPropertyName("nearestStormBearing")]
    public int NearestStormBearing { get; set; }

    /// <summary>
    /// Precipitation intensity
    /// </summary>
    [JsonPropertyName("precipIntensity")]
    public int PrecipitationIntensity { get; set; }

    /// <summary>
    /// Probability of precipitation
    /// </summary>
    [JsonPropertyName("precipProbability")]
    public int PrecipitationProbability { get; set; }

    /// <summary>
    /// Temperature
    /// </summary>
    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    /// <summary>
    /// Apparent temperature
    /// </summary>
    [JsonPropertyName("apparentTemperature")]
    public double ApparentTemperature { get; set; }

    /// <summary>
    /// Dew point
    /// </summary>
    [JsonPropertyName("dewPoint")]
    public double DewPoint { get; set; }

    /// <summary>
    /// Humidity
    /// </summary>
    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }

    /// <summary>
    /// Pressure
    /// </summary>
    [JsonPropertyName("pressure")]
    public double Pressure { get; set; }

    /// <summary>
    /// Wind speed
    /// </summary>
    [JsonPropertyName("windSpeed")]
    public double WindSpeed { get; set; }

    /// <summary>
    /// Wind gust
    /// </summary>
    [JsonPropertyName("windGust")]
    public double WindGust { get; set; }

    /// <summary>
    /// Wind bearing
    /// </summary>
    [JsonPropertyName("windBearing")]
    public int WindBearing { get; set; }

    /// <summary>
    /// Cloud cover percentage
    /// </summary>
    [JsonPropertyName("cloudCover")]
    public double CloudCover { get; set; }

    /// <summary>
    /// UV index
    /// </summary>
    [JsonPropertyName("uvIndex")]
    public int UvIndex { get; set; }

    /// <summary>
    /// Visibility
    /// </summary>
    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    /// <summary>
    /// Ozone
    /// </summary>
    [JsonPropertyName("ozone")]
    public double Ozone { get; set; }

    /// <summary>
    /// Sunrise time
    /// </summary>
    [JsonPropertyName("sunriseTime")]
    public object SunriseTime { get; set; }

    /// <summary>
    /// Sunset time
    /// </summary>
    [JsonPropertyName("sunsetTime")]
    public object SunsetTime { get; set; }

    /// <summary>
    /// Icon URL
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }

    /// <summary>
    /// Alerts
    /// </summary>
    [JsonPropertyName("alerts")]
    public List<object> Alerts { get; set; }

    /// <summary>
    /// Units
    /// </summary>
    [JsonPropertyName("units")]
    public string Units { get; set; }

    /// <summary>
    /// Location
    /// </summary>
    [JsonPropertyName("location")]
    public WeatherLocation Location { get; set; }
  }

  /// <summary>
  /// Weather response
  /// </summary>
  public class Weather {
    /// <summary>
    /// If errored
    /// </summary>
    [JsonPropertyName("error")]
    public bool Error { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// Weather data
    /// </summary>
    [JsonPropertyName("data")]
    public WeatherData Data { get; set; }
  }
}