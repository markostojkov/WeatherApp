using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Contracts.Authentication.Dto;
using WeatherApp.Contracts.Authentication.Models;
using WeatherApp.Contracts.Utils.Result;

namespace WeatherApp.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Result<AuthTokenDto>> Login(LoginModel model);

        public Task<Result> Register(RegisterModel model);
    }
}
