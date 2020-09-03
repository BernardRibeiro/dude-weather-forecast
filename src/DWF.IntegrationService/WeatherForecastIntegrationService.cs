using DWF.Core.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWF.IntegrationService
{
    public class WeatherForecastIntegrationService
    {
        private static HttpClient client = new HttpClient();

        public async Task<string> GetWeatherForecastAsync(CurrentPosition currentPosition)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?lat={currentPosition.Latitude}&lon={currentPosition.Longitude}&appid=f08c959e32826b13063ca9c40de48759";

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }
    }
}
