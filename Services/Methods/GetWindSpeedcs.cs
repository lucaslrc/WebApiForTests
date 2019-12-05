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
            var gustsVerification = Metar.Substring(32, 10);

            var result = string.Empty;

            foreach (var item in ListW.Weather)
            {
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);
                    result = $"{vrbSpeed}kt";
                }
                else if (Metar.Substring(32, 9).Contains("G"))
                {
                    var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);
                    result =$"{windSpeed}kt com rajadas de {gusts}kt";
                }
                else
                {
                    result = $"{windSpeed}kt";
                }
            }
            return result;
        }
    }
}