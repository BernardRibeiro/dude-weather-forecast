using System.Net;
using System.Web.Mvc;

namespace DMF.Site.Controllers
{
    public class BaseController : Controller
    {
        public JsonResult JsonResultBadRequest(string messageError)
        {
            ControllerContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var resultError = new { error = messageError };

            return Json(resultError);
        }
    }
}