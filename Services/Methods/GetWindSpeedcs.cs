using System.Linq;
using Air_BOT.Services.Helpers;
using System.Globalization;

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
            double speedConvertToDouble = double.Parse(windSpeed);
            double speedInKm = speedConvertToDouble * 1.852;

            var result = string.Empty;

            foreach (var item in ListW.Weather)
            {
                if (Metar.Contains("VRB"))
                {
                    var vrbSpeed = Metar.Substring(Metar.IndexOf("VRB"), 5).Substring(3);
                    double speedConvertToDoubleForVrb = double.Parse(vrbSpeed);
                    double speedInKmForVrb = speedConvertToDoubleForVrb * 1.852;
                    result = $"{vrbSpeed}kt = {speedInKmForVrb.ToString("F1", CultureInfo.InvariantCulture)}km/h";
                }
                else if (Metar.Substring(32, 9).Contains("G"))
                {
                    var gusts = gustsVerification.Substring(gustsVerification.IndexOf("G"), 3).Substring(1);
                    double speedConvertToDoubleForGusts = double.Parse(windSpeed);
                    double speedInKmForGusts = speedConvertToDoubleForGusts * 1.852;

                    result =  $"{windSpeed}kt = {speedInKm.ToString("F1", CultureInfo.InvariantCulture)}km/h com rajadas de"
                            + $"{gusts}kt = {speedInKmForGusts.ToString("F1", CultureInfo.InvariantCulture)}km/h";
                }
                else
                {
                    result = $"{windSpeed}kt = {speedInKm.ToString("F1", CultureInfo.InvariantCulture)}km/h";
                }
            }
            return result;
        }
    }
}