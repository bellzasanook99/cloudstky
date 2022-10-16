using cloudstky.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudstky.Controllers
{
    [Route("api/[controller]/[Action]/")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult xxxx()
        {
            return Ok();
        }
    }
}
