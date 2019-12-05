using System.Linq;
using Air_BOT.Services.Helpers;

namespace WebApiForTests.Services.Methods
{
    public class GetWindSpeedcs
    {
        private ListWeather ListW = new ListWeather();
        public string GetSpeedWind(string Metar)
        {
            var variation = Metar.Substring(Metar.IndexOf("KT"), 9).Substring(3);

            var windSpeed = Metar.Substring(35, 2);

            var result = string.Empty;

            foreach (var item in ListW.Weather)
            {
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);
                    result = $"{vrbSpeed}";
                }
                else if (!variation.Contains(item.WeatherTag) && variation.Contains("V"))
                {
                    if (variation.Substring(variation.IndexOf("V")).Any(c => char.IsNumber(c)))
                    {
                        result = $"{windSpeed}";
                    }
                    else
                    {
                        result = $"{windSpeed}";
                    }
                }
            }
            return result;
        }
    }
}