using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication9
{
    public class WeatherComponent
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public WeatherComponent(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetCurrentWeather(string city)
        {
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q=Kyiv&appid=380672abf85517abb665471a858e0582&units=metric";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Розбір JSON і форматування відповіді за потребою
                return jsonResponse;
            }
            else
            {
                return "Failed to fetch weather data.";
            }
        }
    }
}
