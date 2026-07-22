using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

public partial class WeatherViewModel : ObservableObject
{
    private readonly WeatherService _weatherService;

    public WeatherViewModel(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [ObservableProperty]
    private string temperature = "Press Button";

    [RelayCommand]
    async Task SearchLocationShowWeatherAsync()
    {
        var location = await _weatherService.GetLocationAsync(cityName);

        var weather = await _weatherService.GetWeatherAsync(location.Latitude, location.Longitude);

        if (weather != null)
        {
            Temperature = $"{weather.current.Temperature} °C";
        }
        else
            Temperature = "Error fetching weather";
    }

    [ObservableProperty]
    public string cityName = "";
}
