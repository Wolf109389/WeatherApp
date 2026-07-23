using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class WeatherResponse
{
    [JsonPropertyName("current")]
    public CurrentWeather? Current {  get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("time")]
    public DateTime Time { get; set; } = DateTime.MinValue;

    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }
}
