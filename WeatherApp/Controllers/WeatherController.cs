using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Contracts.Utils.Result;
using WeatherApp.Contracts.Weather;
using WeatherApp.Contracts.Weather.Dto;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : BaseController
    {
        public WeatherController(IWeatherService weatherService)
        {
            WeatherService = weatherService;
        }

        public IWeatherService WeatherService { get; }

        [Authorize]
        [HttpGet("{city}")]
        public async Task<IActionResult> GetCityWeather([FromRoute]string city)
        {
            Result<WeatherDto> result = await WeatherService.GetCityWeather(city);

            return OkOrError(result);
        }
    }
}