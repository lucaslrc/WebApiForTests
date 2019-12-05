using System.Linq;
using Air_BOT.Services.Helpers;

namespace WebApiForTests.Services.Methods
{
    public class GetVariationsWind
    {
        private ListWeather ListW = new ListWeather();
        public string GetVariation(string Metar)
        {
            var result = string.Empty;

            foreach (var item in ListW.Weather)
            {
                var variation1 = Metar.Substring(Metar.IndexOf("KT")).Substring(3, 3);
                var variation2 = Metar.Substring(Metar.IndexOf("KT")).Substring(7, 3);

                result = $"{variation1} e {variation2}";
            }
            return result;
        }
    }
}