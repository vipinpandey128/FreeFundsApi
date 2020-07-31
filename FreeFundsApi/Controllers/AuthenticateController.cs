using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FreeFundsApi.Common;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using NWebsec.AspNetCore.Core.Web;
using System.Net.Http;

namespace FreeFundsApi.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUsers _users;
        private readonly ILoginStatus _loginService;

        public AuthenticateController(IOptions<AppSettings> appSettings, IUsers users, ILoginStatus loginService)
        {
            _users = users;
            _appSettings = appSettings.Value;
            _loginService = loginService;
        }

        // POST: api/Authenticate
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequestViewModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginstatus = await _users.AuthenticateUsersAsync(value.UserName, EncryptionLibrary.EncryptText(value.Password));

                    if (loginstatus)
                    {
                        var userdetails = await _users.GetUserDetailsbyCredentialsAsync(value.UserName);

                        if (userdetails != null)
                        {

                           await _loginService.InsertLoginStatusAsync(new LoginStatus
                            {
                                IpAddress = value.IpAddress,
                                IsActive = true,
                                LastLogin = DateTime.Now,
                                UserId = userdetails.UserId
                            });

                            var tokenHandler = new JwtSecurityTokenHandler();
                            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(new Claim[]
                                {
                                        new Claim(ClaimTypes.Name, userdetails.UserId.ToString())
                                }),
                                Expires = DateTime.UtcNow.AddDays(1),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha256Signature)
                            };
                            var token = tokenHandler.CreateToken(tokenDescriptor);
                            value.Token = tokenHandler.WriteToken(token);

                            // remove password before returning
                            value.Password = null;
                            value.Usertype = userdetails.RoleId;

                            return Ok(value);

                        }
                        else
                        {
                            value.Password = null;
                            value.Usertype = 0;
                            return Ok(value);
                        }
                    }
                    value.Password = null;
                    value.Usertype = 0;
                    return Ok(value);
                }
                value.Password = null;
                value.Usertype = 0;
                return Ok(value);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
