using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(WeatherViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
