using CartorioOnline.BL;
using CartorioOnline.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CartorioOnline.Controllers
{
    

    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly IAppSettings _appSettings;
        
        public AuthController(IHttpContextAccessor contextAccessor, IAppSettings appSettings) : base(contextAccessor, appSettings) 
        {
            _contextAccessor = contextAccessor;
            _appSettings = appSettings;
        }

        [HttpPost("")]
        public async Task<ActionResult> Login()
        {
            try
            {
                using (var bl = AuthBL.Create(_appSettings))
                {
                    return Ok(await bl.IsLoggedIn());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
