using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Contracts.Authentication.Dto
{
    public class AuthTokenDto
    {
        public string Token { get; private set; }

        public AuthTokenDto(string token)
        {
            Token = token;
        }
    }
}
