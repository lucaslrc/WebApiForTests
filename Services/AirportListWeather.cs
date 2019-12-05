using System.Linq;
using System;
using Air_BOT.Services.Methods;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApiForTests.Services.Methods;

namespace Air_BOT.Services
{
    public class AirportListWeather
    {
        private SerializeMetar SM = new SerializeMetar();

        public string GetWeatherInfo(string Metar)
        {
            return SM.GetJson();
        }
        
    }
}