using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Air_BOT.Services.Methods;
using WebApiForTests.Models;

namespace WebApiForTests.Services.Methods
{
    public class SerializeMetar
    {
        private GetDirectionWind gdw = new GetDirectionWind();
        private GetWindSpeedcs gws = new GetWindSpeedcs();
        private GetVisibility gtv = new GetVisibility();
        private GetWeather gtw = new GetWeather();

        public string GetJson()
        {
            string M = "2019112217 - METAR SBCG 221700Z 03017KT 9999 VCSH VCTS BKN045 FEW050CB SCT100 32/20 Q1010=";

            string WindDirection, WindSpeed, Visibility;

            WindDirection = gdw.GetWindDirection(M);
            WindSpeed = gws.GetSpeedWind(M);
            Visibility = gtv.GetVisibilityMetar(M);
            string[] Weather = gtw.GetWeatherMetar(M);
            

            var obj = new JsonModel()
            {
                WindDirection = WindDirection,
                WindSpeed = WindSpeed,
                Visibility = Visibility,
                Weather = Weather
            };

            string jsonString = JsonSerializer.Serialize(obj);

            return jsonString;
        }
    }
}