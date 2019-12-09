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

        public string GetJson(string Metar)
        {
            string Date, Hour, WindDirection, WindSpeed, Visibility, Temperature, DewPoint, Pression;
            List<string> Weather;

            Date = Gdate.ConvertDateMetar(Metar);
            Hour = Ghour.ConvertHourMetar(Metar);
            WindDirection = Gdirection.GetWindDirection(Metar);
            WindSpeed = Gspeed.GetSpeedWind(Metar);
            Visibility = Gvisibility.GetVisibilityMetar(Metar);
            Weather = Gweather.GetWeatherMetar(Metar);
            Temperature = Gtemperature.GetTemperatureMetar(Metar);
            DewPoint = GdewPoint.GetDewPointMetar(Metar);
            Pression = Gpression.GetPressionMetar(Metar);

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