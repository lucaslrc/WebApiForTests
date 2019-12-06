using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Air_BOT.Services.Helpers;
using WebApiForTests.Models;

namespace Air_BOT.Services.Methods
{
    public class GetWeather
    {
        private ListWeather ListW = new ListWeather();
        private ListVariations ListV = new ListVariations();

        public List<InfoWeather> GetWeatherMetar(string Metar)
        {
            List<InfoWeather> resultWeather = new List<InfoWeather>();

            string[] resultVariation = {};

            foreach (var item in ListW.Weather)
            {
                if (Metar.Substring(Metar.IndexOf("KT")).Contains(item.WeatherTag))
                {
                    var weather = Metar.Substring(Metar.IndexOf("KT"));

                    string pattern = $@"\b{item.WeatherTag}+\w*?\b";

                    foreach (Match match in Regex.Matches(weather, pattern, RegexOptions.IgnoreCase))
                    {
                        resultWeather.Add( new InfoWeather { Info = item.WeatherInfo});
                    }
                }
            }

            foreach (var item in ListV.Variations)
            {
                if (Metar.Contains(item.WeatherTag))
                {   
                    var variation = Metar.Substring(Metar.IndexOf(item.WeatherTag));

                    string pattern = $@"\b{item.WeatherTag}+\w*?\b";

                    foreach (Match match in Regex.Matches(variation, pattern, RegexOptions.IgnoreCase))
                    {
                        for (int i = 0; i < resultVariation.Length; i++)
                        {
                            if (String.IsNullOrWhiteSpace(match.Value.Substring(3)))
                            {
                                resultVariation[i] += $"{item.WeatherInfo} - altitude desconhecida";
                            }
                            else
                            {
                                resultVariation[i] += $"{item.WeatherInfo} - altitude de {match.Value.Substring(3, 3)}ft";
                            }
                        }
                    }
                }
            }
            if (resultWeather.Count == 0 || resultVariation.Length == 0)
            {
                if (resultWeather.Count == 0)
                {
                    return null;
                }
                else
                {
                    return resultWeather;
                }
            }
            else
            {
                return resultWeather;
            }
        }
    }
}