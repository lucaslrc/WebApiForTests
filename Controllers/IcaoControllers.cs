using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiForTests.Models;

namespace WebApiForTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IcaoController : ControllerBase
    {
        [HttpPost("decoder")]
        public IActionResult Get([FromBody]ModelIcao Icao)
        {
            return "Hello, World";
        }
    }
}
