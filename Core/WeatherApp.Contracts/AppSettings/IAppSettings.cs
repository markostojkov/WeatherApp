using System;

namespace WeatherApp.Contracts.AppSettings
{
    public interface IAppSettings
    {
        public string AppOpenWeatherAPISecretKey { get; }

        public Uri AppOpenWeatherAPIRoute { get; }

        public int AppGetTokenExpirationInHours { get; }

        public string AppDefaultClientUrl { get; }

        public string AppJwtValidAudience { get; }

        public string AppJwtSecret { get; }

        public string AppJwtValidIssuer { get; }
    }
}
