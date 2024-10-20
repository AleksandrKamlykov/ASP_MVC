using Microsoft.AspNetCore.Mvc;
using ASP_MVC.Interfaces;

namespace ASP_MVC.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly IWeatherService _weatherService;

        public WeatherViewComponent(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string location)
        {
            var weatherData = await _weatherService.GetWeatherAsync(location);
            return View(weatherData);
        }
    }
}
