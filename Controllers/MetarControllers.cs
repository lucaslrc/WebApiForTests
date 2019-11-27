using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiForTests.Models;
using WebApiForTests.Services;

namespace WebApiForTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetarController : ControllerBase
    {
        [HttpPost("decoder")]
        public string Get([FromBody]MetarModel model)
        {
            if (string.IsNullOrEmpty(model.Metar))
            {
                return "Metar vazio, por favor tente novamente.";
            }
            else
            {
                var ALW = new AirportListWeather();
                
                return ALW.GetWeatherInfo(model.Metar);
            }
        }
    }
}
