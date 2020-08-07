using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Contracts.Results
{
    public static class ResultErrorCodes
    {
        public const string UserAlreadyExists = "USER_ALREADY_EXISTS";
        public const string UserDoesNotExist = "USER_DOES_NOT_EXIST";
        public const string UserIncorrectPassword = "USER_INCORRECT_PASSWORD";

        public const string WeatherForecastNotFound = "WEATHER_FORECAST_NOT_FOUND";
    }
}
