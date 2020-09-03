using DWF.Core.Models;
using DWF.IntegrationService;
using System.Threading.Tasks;

namespace DWF.Business
{
    public class WeatherForecastService
    {
        public async Task<string> GetWeatherForecastAsync(CurrentPosition currentPosition)
        {
            WeatherForecastIntegrationService integrationService = new WeatherForecastIntegrationService();

            return await integrationService.GetWeatherForecastAsync(currentPosition);
        }
    }
}
