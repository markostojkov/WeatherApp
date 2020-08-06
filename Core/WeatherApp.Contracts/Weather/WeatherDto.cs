using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Contracts.Weather
{
    public class WeatherCoordDto
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class WeatherInfoDto
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class WeatherMainDto
    {
        public double Temp { get; set; }

        public int Pressure { get; set; }

        public int Gumidity { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
    }

    public class WeatherWindDto
    {
        public double Speed { get; set; }

        public int Deg { get; set; }
    }

    public class WeatherCloudsDto
    {
        public int All { get; set; }
    }

    public class WeatherSysDto
    {
        public int Type { get; set; }

        public int Id { get; set; }

        public double Message { get; set; }

        public string Country { get; set; }

        public int Sunrise { get; set; }

        public int Sunset { get; set; }
    }

    public class WeatherDto
    {
        public WeatherCoordDto Coord { get; set; }

        public List<WeatherInfoDto> Weather { get; set; }

        public WeatherMainDto Main { get; set; }

        public int Visibility { get; set; }

        public WeatherWindDto Wind { get; set; }

        public WeatherCloudsDto Clouds { get; set; }

        public int Dt { get; set; }

        public WeatherSysDto Sys { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }
    }
}
