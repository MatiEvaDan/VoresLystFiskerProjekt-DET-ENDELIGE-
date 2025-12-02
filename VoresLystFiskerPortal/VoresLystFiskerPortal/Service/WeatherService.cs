using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VoresLystFiskerPortal.Models;

namespace VoresLystFiskerPortal.Service
{
    public class WeatherService
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenWeatherMap:ApiKey"];
        }

        public async Task<WeatherInfo> GetWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) 
            
            return null;

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var weatherInfo = JsonSerializer.Deserialize<WeatherInfo>(json, options);

            return weatherInfo;

        }

    }
}
