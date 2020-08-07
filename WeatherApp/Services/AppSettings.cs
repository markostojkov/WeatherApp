using Microsoft.Extensions.Configuration;
using System;
using WeatherApp.Contracts.AppSettings;

namespace WeatherApp.Services
{
    public class AppSettings : IAppSettings
    {
        private IConfiguration Configuration { get; }

        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string AppOpenWeatherAPISecretKey => Configuration.GetValue<string>("OpenWeatherAPI:SecretKey");

        public Uri AppOpenWeatherAPIRoute => Configuration.GetValue<Uri>("OpenWeatherAPI:Route");

        public int AppGetTokenExpirationInHours => Configuration.GetValue<int>("App:TokenExpirationInHours");

        public string AppDefaultClientUrl => Configuration.GetValue<string>("App:DefaultClientUrl");

        public string AppJwtValidAudience => Configuration.GetValue<string>("JWT:ValidAudience");

        public string AppJwtSecret => Configuration.GetValue<string>("JWT:Secret");

        public string AppJwtValidIssuer => Configuration.GetValue<string>("JWT:ValidIssuer");
    }
}
