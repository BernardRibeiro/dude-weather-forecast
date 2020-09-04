using DWF.Site.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace DWF.Tests.Site.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexNotNull()
        {
            HomeController controller = new HomeController();
            
            ViewResult result = controller.Index() as ViewResult;
            
            Assert.IsNotNull(result);
        }
    }
}
