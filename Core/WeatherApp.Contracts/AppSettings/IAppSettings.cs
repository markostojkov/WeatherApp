using System;

namespace WeatherApp.Contracts.AppSettings
{
    public interface IAppSettings
    {
        public string AppOpenWeatherAPISecretKey { get; }

        public Uri AppOpenWeatherAPIRoute { get; }

        public int AppGetTokenExpirationInHours { get; }

        public string AppDefaultClientUrl { get; }
    }
}
