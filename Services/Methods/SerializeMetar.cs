using System;
using System.Collections.Generic;
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
        private GetDate Gdate = new GetDate();
        private GetHour Ghour = new GetHour();
        private GetDirectionWind Gdirection = new GetDirectionWind();
        private GetWindSpeedcs Gspeed = new GetWindSpeedcs();
        private GetVisibility Gvisibility = new GetVisibility();
        private GetWeather Gweather = new GetWeather();
        private GetTemperature Gtemperature = new GetTemperature();
        private GetDewPoint GdewPoint = new GetDewPoint();
        private GetPression Gpression = new GetPression();

        public string GetJson()
        {
            string M = "2019112217 - METAR SBCG 221700Z 03017KT 9999 VCSH VCTS BKN045 FEW050CB SCT100 32/20 Q1010=";

            string Date, Hour, WindDirection, WindSpeed, Visibility, Temperature, DewPoint, Pression;
            List<InfoWeather> Weather;

            Date = Gdate.ConvertDateMetar(M);
            Hour = Ghour.ConvertHourMetar(M);
            WindDirection = Gdirection.GetWindDirection(M);
            WindSpeed = Gspeed.GetSpeedWind(M);
            Visibility = Gvisibility.GetVisibilityMetar(M);
            Weather = Gweather.GetWeatherMetar(M);
            Temperature = Gtemperature.GetTemperatureMetar(M);
            DewPoint = GdewPoint.GetDewPointMetar(M);
            Pression = Gpression.GetPressionMetar(M);

            var obj = new JsonModel()
            {
                Date = Date,
                Hour = Hour,
                WindDirection = WindDirection,
                WindSpeed = WindSpeed,
                Visibility = Visibility,
                Weather = Weather,
                Temperature = Temperature,
                DewPoint = DewPoint,
                Pression = Pression
            };

            string jsonString = JsonSerializer.Serialize(obj);

            return jsonString;
        }
    }
}