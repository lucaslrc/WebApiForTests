using System;
using System.Linq;
using Air_BOT.Services.Helpers;

namespace WebApiForTests.Services.Methods
{
    public class GetDirectionWind
    {
        private GetVariationsWind getVariationsWind = new GetVariationsWind();
        private ListWeather ListW = new ListWeather();
        public string GetWindDirection(string Metar)
        {
            var variation = Metar.Substring(Metar.IndexOf("KT"), 9).Substring(3);

            var windDirection = Metar.Substring(32, 3);

            var result = string.Empty;

            foreach (var item in ListW.Weather)
            {
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);
                    result = "Incerta";
                }
                else if (!variation.Contains(item.WeatherTag) && variation.Contains("V"))
                {
                    if (variation.Substring(variation.IndexOf("V")).Any(c => char.IsNumber(c)))
                    {
                        result = getVariationsWind.GetVariation(Metar);
                    }
                    else
                    {
                        result = $"{windDirection}";
                    }
                }
            }
            return result;
        }
    }
}