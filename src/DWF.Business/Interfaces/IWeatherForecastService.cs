using DWF.Core.Models;
using System.Threading.Tasks;

namespace DWF.Business.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<string> GetWeatherForecastAsync(CurrentPosition currentPosition);
    }
}