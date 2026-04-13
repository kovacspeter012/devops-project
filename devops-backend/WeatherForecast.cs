using System.Text.Json;

namespace devops_backend
{
    public class WeatherForecast
    {
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
        public string? City { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }

        public static List<WeatherForecast>? LoadForecastsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file at {filePath} was not found.");
            }

            string jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<WeatherForecast>? forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString, options);

            return forecasts;
        }
    }
}
