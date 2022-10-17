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
    public class MarriageController : BaseController
    {
        protected readonly IAppSettings _appSettings;
        protected readonly IHttpContextAccessor _contextAccessor;

        public MarriageController(IHttpContextAccessor contextAccessor, IAppSettings appSettings) : base(contextAccessor , appSettings)
        {
            _appSettings = appSettings;
            _contextAccessor = contextAccessor;
        }


        [HttpGet("list-all")]
        public IActionResult GetAll(int page, int pageRows)
        {
            using (var bl = MarriageBL.Create(_appSettings))
            {
                try
                {
                    if (page <= 0 || pageRows <= 0)
                    {
                        return BadRequest("Erro. Página ou Linha não pode ser zero ou negativa.");
                    }
                    return Ok(bl.GetPageMarriage(page, pageRows));
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost]
        public IActionResult PostMarriage(MarriageModel request)
        {
            using (var bl = MarriageBL.Create(_appSettings))
            {
                try
                {
                    return Ok(bl.PostMarriage(request));
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
