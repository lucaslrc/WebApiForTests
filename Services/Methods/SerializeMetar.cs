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
            string date, hour, windDirection, windSpeed, visibility, temperature, dewPoint, pression;
            string[] weather;

            date = Gdate.ConvertDateMetar(Metar);
            hour = Ghour.ConvertHourMetar(Metar);
            windDirection = Gdirection.GetWindDirection(Metar);
            windSpeed = Gspeed.GetSpeedWind(Metar);
            visibility = Gvisibility.GetVisibilityMetar(Metar);
            weather = Gweather.GetWeatherMetar(Metar);
            temperature = Gtemperature.GetTemperatureMetar(Metar);
            dewPoint = GdewPoint.GetDewPointMetar(Metar);
            pression = Gpression.GetPressionMetar(Metar);

            var obj = new JsonModel()
            {
                Date = date,
                Hour = hour,
                WindDirection = windDirection,
                WindSpeed = windSpeed,
                Visibility = visibility,
                Weather = weather,
                Temperature = temperature,
                DewPoint = dewPoint,
                Pression = pression
            };

            string jsonString = JsonSerializer.Serialize(obj);

            return jsonString;
        }
    }
}