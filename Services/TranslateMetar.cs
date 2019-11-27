using System;
using System.Linq;

namespace WebApiForTests.Services
{
    public class TranslateMetar
    {
        public string Translate(string Metar)
        {
            var a = new AirportListWeather();

            return a.GetWeatherInfo(Metar);
        }

        public string ConvertIcaoForAirportName(string Icao)
        {
            if (Icao.Length == 0)
            {
                return "Não foi possível fazer a busca pelo aeroporto, digite um ICAO.";
            }
            else if (Icao.Contains("/"))
            {
                return $"https://www.aisweb.aer.mil.br/index.cfm?i=aerodromos&codigo={Icao.Substring(1)}";
            }
            else
            {
                return $"https://www.aisweb.aer.mil.br/index.cfm?i=aerodromos&codigo={Icao}";
            }  
        } 
    }
}