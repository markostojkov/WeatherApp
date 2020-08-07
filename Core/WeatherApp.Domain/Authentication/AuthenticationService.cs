using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Contracts.AppSettings;
using WeatherApp.Contracts.Authentication;
using WeatherApp.Contracts.Authentication.Dto;
using WeatherApp.Contracts.Authentication.Models;
using WeatherApp.Contracts.Results;
using WeatherApp.Contracts.Utils.Result;
using WeatherApp.Persistence.Entities;

namespace WeatherApp.Domain.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IAppSettings appSettings)
        {
            this.userManager = userManager;
            _configuration = configuration;
            AppSettings = appSettings;
        }

        private readonly UserManager<ApplicationUser> userManager;


        private readonly IConfiguration _configuration;

        public IAppSettings AppSettings { get; }

        public async Task<Result<AuthTokenDto>> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return Result.Unauthorized<AuthTokenDto>(ResultErrorCodes.UserDoesNotExist);
            }

            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                return Result.Unauthorized<AuthTokenDto>(ResultErrorCodes.UserIncorrectPassword);
            }
            
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.AppJwtSecret));

            var token = new JwtSecurityToken(
                issuer: AppSettings.AppJwtValidIssuer,
                audience: AppSettings.AppJwtValidAudience,
                expires: DateTime.Now.AddHours(AppSettings.AppGetTokenExpirationInHours),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return Result.Ok(new AuthTokenDto(new JwtSecurityTokenHandler().WriteToken(token)));
        }

        public async Task<Result> Register(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return Result.Conflicted(ResultErrorCodes.UserAlreadyExists);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return Result.Invalid(ResultErrorCodes.UserIncorrectPassword);
            }

            return Result.Ok();
        }
    }
}
