using Microsoft.AspNetCore.Mvc;
using WebApiForTests.Models;
using WebApiForTests.Services;

namespace WebApiForTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetarController : ControllerBase
    {
        [HttpPost("decoder")]
        public string Get([FromBody]IcaoModel model)
        {
            if (string.IsNullOrEmpty(model.Icao))
            {
                return "Metar vazio, por favor tente novamente.";
            }
            else
            {
                var ALW = new TranslateMetar();
                
                return ALW.Translate(model.Icao);
            }
        }
    }
}
