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

    [RelayCommand]
    private async Task SearchLocationShowWeatherAsync()
    {
        Temperature = DateTime.Now.ToLongTimeString();
        //Temperature = "Loading...";

        //var location = await _locationService.GetLocationAsync(CityName);

        //if (location == null) 
        //{
        //    Temperature = "Location not found";
        //    return;
        //}

        //var weather = await _weatherService.GetWeatherAsync(location.Latitude, location.Longitude);

        //if (weather != null)
        //    Temperature = $"{weather.Current.Temperature} °C";
        //else
        //    Temperature = "Error fetching weather";

        //return; 
    }

}
