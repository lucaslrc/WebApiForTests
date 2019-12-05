using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Air_BOT.Services.Methods;
using WebApiForTests.Models;

namespace WebApiForTests.Services.Methods
{
    public class SerializeMetar
    {
        private GetVariationsWind gvw = new GetVariationsWind();
        private GetDirectionWind gdw = new GetDirectionWind();
        private GetWindSpeedcs gds = new GetWindSpeedcs();
        public void GetJson()
        {
            var M = "2019112319 - METAR SBMG 231900Z 24023G41KT 240V320 9999 3000NW -RA SCT020TCU 27/19 Q1008=";

            string WindDirection, WindSpeed;

            WindDirection = gdw.GetWindDirection(M);
            WindSpeed = gds.GetSpeedWind(M);

            var obj = new JsonModel()
            {
                WindDirection = WindDirection,
                WindSpeed = WindSpeed 
            };

            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine("_____________________  " + json);
        }
    }
}