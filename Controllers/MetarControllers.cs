using Air_BOT.Services;
using Microsoft.AspNetCore.Mvc;
using WebApiForTests.Models;

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
                var ALW = new TranslateMetar();
                
                return ALW.Translate(model.Metar);
            }
        }
    }
}
