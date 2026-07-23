using System;
using System.Text.Json;
using WeatherApp.Models;
using WeatherApp.ViewModels;
namespace WeatherApp.Services;
using System.Globalization;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherResponse?> GetWeatherAsync(double latitude, double longitude)
    {
        string url = FormattableString.Invariant(
                         $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m");
        string json = await _httpClient.GetStringAsync(url);
        WeatherResponse? weather = JsonSerializer.Deserialize<WeatherResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return weather;
    }
}

