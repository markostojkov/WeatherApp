using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WeatherApp.Contracts.AppSettings;
using WeatherApp.Contracts.Authentication;
using WeatherApp.Contracts.Authentication.Dto;
using WeatherApp.Contracts.Authentication.Models;
using WeatherApp.Contracts.Utils.Result;
using WeatherApp.Persistence.Entities;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    {
        public AuthenticateController(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        public IAuthenticationService AuthenticationService { get; }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            Result<AuthTokenDto> result = await AuthenticationService.Login(model);

            return OkOrError(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            Result result = await AuthenticationService.Register(model);

            return OkOrError(result);
        }
    }
}