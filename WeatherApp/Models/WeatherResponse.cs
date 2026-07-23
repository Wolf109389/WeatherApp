using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class WeatherResponse
{
    [JsonPropertyName("current_weather")]
    public CurrentWeather? Current {  get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = "";

    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }
}
