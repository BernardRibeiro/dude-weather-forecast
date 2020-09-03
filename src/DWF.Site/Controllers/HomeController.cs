using DMF.Site.Controllers;
using System.Web.Mvc;

namespace DWF.Site.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}