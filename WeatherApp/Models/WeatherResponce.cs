using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class WeatherResponce
{
    public CurrentWeather current {  get; set; }
}

public class CurrentWeather
{
    public string Time { get; set; }

    public int Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public int Temperature { get; set; }
}
