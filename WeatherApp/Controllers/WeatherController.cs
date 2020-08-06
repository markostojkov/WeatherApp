using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Contracts.AppSettings;
using WeatherApp.Contracts.Result;
using WeatherApp.Contracts.Weather;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public WeatherController(IAppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        public IAppSettings AppSettings { get; }

        [Authorize]
        [HttpGet("{city}")]
        public async Task<IActionResult> GetCityWeather([FromRoute]string city)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = string.Format(CultureInfo.InvariantCulture, AppSettings.AppOpenWeatherAPIRoute.ToString(), city, AppSettings.AppOpenWeatherAPISecretKey);
                HttpResponseMessage responseTask = await client.GetAsync(url);

                if (!responseTask.IsSuccessStatusCode)
                {
                    return NotFound(ResultErrorCodes.WeatherForecastNotFound);
                }

                var json = responseTask.Content.ReadAsStringAsync().Result;
                WeatherDto weatherDto = JsonConvert.DeserializeObject<WeatherDto>(json);

                return Ok(weatherDto);
            }
        }
    }
}