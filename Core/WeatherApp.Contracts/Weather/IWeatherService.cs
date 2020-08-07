using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Contracts.Utils.Result;
using WeatherApp.Contracts.Weather.Dto;

namespace WeatherApp.Contracts.Weather
{
    public interface IWeatherService
    {
        public Task<Result<WeatherDto>> GetCityWeather(string city);
    }
}
