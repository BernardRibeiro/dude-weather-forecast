using DWF.Business.Interfaces;
using DWF.Core.Models;
using DWF.Site.Controllers;
using DWF.Site.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace DWF.Tests.Site.Controllers
{
    [TestClass]
    public class WeatherForecastControllerTest
    {
        private readonly Mock<IWeatherForecastService> _mockService;
        private readonly WeatherForecastController _controller;

        public WeatherForecastControllerTest()
        {
            _mockService = new Mock<IWeatherForecastService>();
            _controller = new WeatherForecastController(_mockService.Object);
        }

        [TestMethod]
        public void ShouldMatchParametersTest()
        {
            CurrentPositionViewModel currentPosition = new CurrentPositionViewModel
            {
                Latitude = "123",
                Longitude = "321"
            };

            _mockService
               .Setup(s => s.GetWeatherForecastAsync(It.IsAny<CurrentPosition>()))
               .Returns(It.IsAny<Task<string>>());

            _ = _controller.Index(currentPosition);
                        
            _mockService.Verify(s => s.GetWeatherForecastAsync(It.Is<CurrentPosition>(arg => arg.Latitude == currentPosition.Latitude && arg.Longitude == currentPosition.Longitude)));
        }

        [TestMethod]
        public async Task ShouldBeOkTest()
        {
            CurrentPositionViewModel currentPosition = new CurrentPositionViewModel
            {
                Latitude = "123",
                Longitude = "321"
            };

            var dataResult = "{temp:232}";

            _mockService
               .Setup(s => s.GetWeatherForecastAsync(It.IsAny<CurrentPosition>()))
               .Returns(Task.FromResult(dataResult));
               
            var result = await _controller.Index(currentPosition);

            Assert.AreEqual(dataResult, result.Data);

            _mockService.Verify(s => s.GetWeatherForecastAsync(It.IsAny<CurrentPosition>()), Times.Once);
        }

        //continue
    }
}
