using DWF.Business.Interfaces;
using DWF.Core.Models;
using DWF.IntegrationService.Interfaces;
using System.Threading.Tasks;

namespace DWF.Business
{
    public class WeatherForecastService : IWeatherForecastService
    {
        readonly IWeatherForecastIntegrationService _weatherForecastIntegrationService;
        public WeatherForecastService(IWeatherForecastIntegrationService weatherForecastIntegrationService)
        {
            _weatherForecastIntegrationService = weatherForecastIntegrationService;
        }

        public async Task<string> GetWeatherForecastAsync(CurrentPosition currentPosition)
        {
            return await _weatherForecastIntegrationService.GetWeatherForecastAsync(currentPosition);
        }
    }
}
