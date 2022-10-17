using CartorioOnline.BL;
using CartorioOnline.Models;
using CartorioOnline.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CartorioOnline.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DeathController : BaseController
    {
        protected readonly IAppSettings _appSettings;
        protected readonly IHttpContextAccessor _contextAccessor;

        public DeathController(IHttpContextAccessor contextAccessor, IAppSettings appSettings) : base(contextAccessor , appSettings)
        {
            _appSettings = appSettings;
            _contextAccessor = contextAccessor;
        }


        [HttpGet("list-all")]
        public IActionResult GetAll(int page, int pageRows)
        {
            using (var bl = DeathBL.Create(_appSettings))
            {
                try
                {
                    if (page <= 0 || pageRows <= 0)
                    {
                        return BadRequest("Erro. Página ou Linha não pode ser zero ou negativa.");
                    }
                    return Ok(bl.GetPageDeath(page, pageRows));
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost]
        public IActionResult PostDeath(DeathPostModel request)
        {
            using (var bl = DeathBL.Create(_appSettings))
            {
                try
                {
                    return Ok(bl.PostDeath(request));
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
