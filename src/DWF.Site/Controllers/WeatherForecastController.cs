using DMF.Site.Controllers;
using DWF.Business.Interfaces;
using DWF.Core.Models;
using DWF.Site.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DWF.Site.Controllers
{
    public class WeatherForecastController : BaseController
    {
        readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpPost]
        public async Task<JsonResult> Index(CurrentPositionViewModel currentPositionViewModel)
        {
            try
            {
                var currentPosition = new CurrentPosition
                {
                    Latitude = currentPositionViewModel.Latitude,
                    Longitude = currentPositionViewModel.Longitude
                };

                var weatherForecastResult = await _weatherForecastService.GetWeatherForecastAsync(currentPosition);
                
                return Json(weatherForecastResult);
            }
            catch (Exception error)
            {
                return JsonResultBadRequest(error.Message);
            }            
        }
    }
}