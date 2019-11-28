using System;
using System.IO;
using System.Linq;
using System.Net;

namespace WebApiForTests.Services
{
    public class TranslateMetar
    {
        public string Translate(string Icao)
        {
            var a = new AirportListWeather();

            return a.GetWeatherInfo(GetMetar(Icao));
        }

        public string GetMetar(string Icao)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://www.redemet.aer.mil.br/api/consulta_automatica/index.php?local={Icao}&msg=metar");
 
            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    
            var content = string.Empty;
    
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            if (content.Contains("não localizada na base de dados da REDEMET"))
            {
                return string.Empty + content;
            }
            else
            {
                return content;
            }
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