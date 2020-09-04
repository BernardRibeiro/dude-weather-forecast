using DWF.Core.Models;
using System.Threading.Tasks;

namespace DWF.IntegrationService.Interfaces
{
    public interface IWeatherForecastIntegrationService
    {
        Task<string> GetWeatherForecastAsync(CurrentPosition currentPosition);
    }
}