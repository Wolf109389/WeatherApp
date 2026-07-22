using System;
using System.Text.Json;
using WeatherApp.Models;
using WeatherApp.ViewModels;
namespace WeatherApp.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<CityLocation?> GetLocationAsync(string cityName)
    {
        string url = $"https://geocoding-api.open-meteo.com/v1/search?name={cityName}";
        string json = await _httpClient.GetStringAsync(url);
        LocationResponse? response = JsonSerializer.Deserialize<LocationResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        CityLocation? location = response?.Results?.FirstOrDefault();

        return location;
    }

    public async Task<WeatherResponce?> GetWeatherAsync(double latitude, double longitude)
    {
        string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m";
        string json = await _httpClient.GetStringAsync(url);
        WeatherResponce? weather = JsonSerializer.Deserialize<WeatherResponce>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return weather;
    }
}

