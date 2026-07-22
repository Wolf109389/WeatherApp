namespace WeatherApp.Models
{
    public class LocationResponse
    {
        public List<CityLocation> Results { get; set; }
    }

    public class CityLocation
    {   
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }   
    }
}

