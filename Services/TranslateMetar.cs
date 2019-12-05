using System;
using System.Linq;

namespace Air_BOT.Services
{
    public class TranslateMetar
    {
        public string Translate(string Metar)
        {
            var a = new AirportListWeather();

            return a.GetWeatherInfo(Metar);
        }
    }
}