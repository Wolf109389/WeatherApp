using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class LocationResponse
    {
        [JsonPropertyName("results")]
        public List<CityLocation> Results { get; set; } = [];
    }

    public class CityLocation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }   
    }
}

