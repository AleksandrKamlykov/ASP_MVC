using System.Threading.Tasks;
using ASP_MVC.Interfaces;

namespace ASP_MVC.Services
{
  

    public class WeatherService : IWeatherService
    {
        public Task<WeatherData> GetWeatherAsync(string location)
        {
            var weatherData = new WeatherData
            {
                Location = location,
                Temperature = 25,
                Condition = "Sunny"
            };

            return Task.FromResult(weatherData);
        }
    }

    public class WeatherData
    {
        public string Location { get; set; }
        public int Temperature { get; set; }
        public string Condition { get; set; }
    }
}
