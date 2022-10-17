using CartorioOnline.Services;
using CartorioOnline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CartorioOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IAppSettings _appSettings;
        private readonly Guid UserId;
        private readonly Guid UserAuthId;

        public Guid UserIdContext { get { return UserId; } } 
        public Guid UserAuthIdContext { get { return UserAuthId; } }


        public BaseController(IHttpContextAccessor contextAccessor, IAppSettings appSettings)
        {
            _appSettings = appSettings;

            ClaimsIdentity identity = (ClaimsIdentity)contextAccessor.HttpContext.User.Identity;

            if(identity != null)
            {
                Guid.TryParse(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value, out UserId);
                Guid.TryParse(identity.FindFirst("AuthUserId")?.Value, out UserAuthId);
            }
        }

        protected TokenModel CreateToken(LoginModel model)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, model.UserId.ToString()),
                new Claim("AuthUserId", model.AuthUserId.ToString())
            };

            var token = new JwtSecurityToken(
                    issuer: _appSettings.JwtIssuer,
                    audience: _appSettings.JwtAudience,
                    signingCredentials: credentials,
                    claims: claims
                );

            return new TokenModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
