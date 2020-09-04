using DWF.Core.Models;
using DWF.IntegrationService.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWF.IntegrationService
{
    public class WeatherForecastIntegrationService : IWeatherForecastIntegrationService
    {
        private static HttpClient client = new HttpClient();

        const string API_URL = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=f08c959e32826b13063ca9c40de48759";

        public async Task<string> GetWeatherForecastAsync(CurrentPosition currentPosition)
        {
            string url = string.Format(API_URL, currentPosition.Latitude, currentPosition.Longitude);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }
    }
}
