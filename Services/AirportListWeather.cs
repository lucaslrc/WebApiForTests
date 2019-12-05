using System.Linq;
using System;
using Air_BOT.Services.Methods;
using WebApiForTests.Services.Methods;

namespace Air_BOT.Services
{
    public class AirportListWeather
    {
        private GetDate Cdat = new GetDate();
        private GetTemperature Gtem = new GetTemperature();
        private GetVisibility Gvis = new GetVisibility();
        private GetWeather Gwea = new GetWeather();
        private GetWind Gwin = new GetWind();
        private GetPression Gpre = new GetPression();
        private SerializeMetar SM = new SerializeMetar();

        public string GetWeatherInfo(string Metar)
        {
            SM.GetJson();
            
            return "Ok";
        }
        
    }
}