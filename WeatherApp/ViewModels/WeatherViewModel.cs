using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

public partial class WeatherViewModel : ObservableObject
{
    private readonly WeatherService _weatherService;
    private readonly LocationService _locationService;

    public WeatherViewModel(WeatherService weatherService, LocationService locationService)
    {
        _weatherService = weatherService;
        _locationService = locationService;
    }   

    [ObservableProperty]
    private string temperature = "Press Button";

    [ObservableProperty]
    private string cityName = "";

    [ObservableProperty]
    private bool isLoading = false;

    [ObservableProperty]
    private bool isNotLoading = true;

    [ObservableProperty]
    private string time = "";

    [ObservableProperty]
    private string place = "";

    [ObservableProperty]
    int setting = 1;

    [RelayCommand]
    private async Task SearchLocationShowWeatherAsync()
    {
        IsNotLoading = false;
        IsLoading = true;

        var location = await _locationService.GetLocationAsync(CityName);

        if (location == null)
        {
            Temperature = "Location not found";
            IsLoading = false;
            IsNotLoading = true;
            return;
        }

        var weather = await _weatherService.GetWeatherAsync(location.Latitude, location.Longitude);

        if (weather == null)
        {
            Temperature = "Error fetching weather";
        }
        else
        {
            Place = $"Place: {location.Name}";

            Temperature = $"Temperature: {weather.Current.Temperature} °C";

            if (Setting == 1)
                Time = "Time: " + weather.Current.Time.ToString("dd.MM.yyyy HH:mm");
            else
                Time = "Time: " + weather.Current.Time.ToString("dddd, dd MMMM HH:mm");
        }

        IsLoading = false;
        IsNotLoading = true;

        return;
    }

}
