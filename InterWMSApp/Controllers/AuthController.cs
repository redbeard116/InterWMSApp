using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InterWMSApp.Models;
using InterWMSApp.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace InterWMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Fields
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        #endregion

        #region Constructor
        public AuthController(ILogger<AuthController> logger,
                              IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }
        #endregion

        #region Actions
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] UserAuth user)
        {
            _logger.LogInformation($"add api/auth");
            if (user == null)
                return BadRequest("");

            var errorList = new StringBuilder();
            if (string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
            {
                errorList.AppendLine("Логин или пароль не должен быть путым");
            }
            if (errorList.Length != 0)
            {
                return BadRequest(errorList.ToString());
            }

            var userResult = await GetIdentity(user);

            if (userResult != null)
            {
                var date = DateTime.Now;
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: date,
                        claims: userResult.Claims,
                        expires: date.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = userResult.Name,
                    role = userResult.RoleClaimType
                };

                return Ok(response);
            }
            return BadRequest("Ошибка при авторизации");
        }

        private async Task<ClaimsIdentity> GetIdentity(UserAuth user)
        {
            var userResult = await _authService.GetUserAuth(user);
            if (userResult != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userResult.FirstName),
                    new Claim(ClaimTypes.Role, userResult.Role.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userResult.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    userResult.Role.ToString());

                return claimsIdentity;
            }

            return null;
        }
        #endregion
    }
}
