using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Contracts.AppSettings;
using WeatherApp.Contracts.Results;
using WeatherApp.Contracts.Utils.Result;
using WeatherApp.Contracts.Weather;
using WeatherApp.Contracts.Weather.Dto;

namespace WeatherApp.Domain.Weather
{
    public class WeatherService : IWeatherService
    {
        public WeatherService(IAppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        public IAppSettings AppSettings { get; }

        public async Task<Result<WeatherDto>> GetCityWeather(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = string.Format(CultureInfo.InvariantCulture, AppSettings.AppOpenWeatherAPIRoute.ToString(), city, AppSettings.AppOpenWeatherAPISecretKey);
                HttpResponseMessage responseTask = await client.GetAsync(url);

                if (!responseTask.IsSuccessStatusCode)
                {
                    return Result.NotFound<WeatherDto>(ResultErrorCodes.WeatherForecastNotFound);
                }

                var json = responseTask.Content.ReadAsStringAsync().Result;
                WeatherDto weatherDto = JsonConvert.DeserializeObject<WeatherDto>(json);

                return Result.Ok(weatherDto);
            }
        }
    }
}
