using DMF.Site.Controllers;
using DWF.Business;
using DWF.Core.Models;
using DWF.Site.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DWF.Site.Controllers
{
    public class WeatherForecastController : BaseController
    {
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

                WeatherForecastService service = new WeatherForecastService();

                var weatherForecastResult = await service.GetWeatherForecastAsync(currentPosition);
                
                return Json(weatherForecastResult);
            }
            catch (Exception error)
            {
                return JsonResultBadRequest(error.Message);
            }            
        }
    }
}