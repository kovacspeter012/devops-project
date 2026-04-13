using Microsoft.AspNetCore.Mvc;

namespace devops_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("{city}")]
        public IActionResult GetWeatherByCity(string city)
        {
            string filePath = "data.json";

            try
            {
                var forecasts = WeatherForecast.LoadForecastsFromJson(filePath);

                if (forecasts == null || !forecasts.Any())
                {
                    return StatusCode(500, "Weather data could not be loaded.");
                }

                var cityWeather = forecasts.FirstOrDefault(f =>
                    f.City != null &&
                    f.City.Equals(city, StringComparison.OrdinalIgnoreCase));

                if (cityWeather == null)
                {
                    return NotFound(new { Message = $"No weather data found for '{city}'." });
                }

                return Ok(cityWeather);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
