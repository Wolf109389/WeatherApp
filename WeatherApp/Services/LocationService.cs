using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class LocationService
{
    private readonly HttpClient _httpClient;

    public LocationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CityLocation?> GetLocationAsync(string cityName)
    {
        string url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(cityName)}";
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
}

