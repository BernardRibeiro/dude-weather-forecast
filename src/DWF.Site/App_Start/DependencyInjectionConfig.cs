using DWF.Business;
using DWF.Business.Interfaces;
using DWF.IntegrationService;
using DWF.IntegrationService.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace DMF.Site
{
    public class DependencyInjectionConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IWeatherForecastService, WeatherForecastService>();
            container.RegisterType<IWeatherForecastIntegrationService, WeatherForecastIntegrationService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}