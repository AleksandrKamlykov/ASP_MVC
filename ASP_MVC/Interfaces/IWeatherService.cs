using ASP_MVC.Services;

namespace ASP_MVC.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string location);
    }
}
