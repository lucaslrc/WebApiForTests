using System;
using System.Linq;
using Air_BOT.Services.Helpers;

namespace WebApiForTests.Services.Methods
{
    public class GetDirectionWind
    {
        private ListWeather ListW = new ListWeather();
        public string GetWindDirection(string Metar)
        {
            var result = string.Empty;

            var variation = Metar.Substring(Metar.IndexOf("KT"), 9).Substring(3);

            var windDirection = Metar.Substring(32, 3);

            foreach (var item in ListW.Weather)
            {
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);
                    result = "Variante";
                }
                else if (!variation.Contains(item.WeatherTag) && variation.Contains("V"))
                {
                    if (variation.Substring(variation.IndexOf("V")).Any(c => char.IsNumber(c)))
                    {
                        var variation1 = Metar.Substring(Metar.IndexOf("KT")).Substring(3, 3);
                        var variation2 = Metar.Substring(Metar.IndexOf("KT")).Substring(7, 3);

                        result = $"{variation1} e {variation2}";
                    }
                }
                else
                {
                    result = $"{windDirection}";
                }
            }
            return result;
        }
    }
}