using DMF.Site.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DMF.Site.Controllers
{
    public class WeatherForecastController : Controller
    {
        private static HttpClient client = new HttpClient();

        [HttpPost]
        public async Task<JsonResult> Index(CurrentPositionModel currentPositionModel)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?lat={currentPositionModel.Latitude}&lon={currentPositionModel.Longitude}&appid=f08c959e32826b13063ca9c40de48759";

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Json(result);
            }

            return Json("");
        }
    }
}