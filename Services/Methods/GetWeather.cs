using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using Air_BOT.Services.Helpers;
using WebApiForTests.Models;

namespace Air_BOT.Services.Methods
{
    public class GetWeather
    {
        private ListWeather ListW = new ListWeather();
        private ListVariations ListV = new ListVariations();

        public string[] GetWeatherMetar(string Metar)
        {
            List<string> infoWeather = new List<string>();

            foreach (var item in ListW.Weather)
            {
                if (Metar.Substring(Metar.IndexOf("KT")).Contains(item.WeatherTag))
                {
                    var weather = Metar.Substring(Metar.IndexOf("KT"));

                    string pattern = $@"\b{item.WeatherTag}+\w*?\b";

                    foreach (Match match in Regex.Matches(weather, pattern, RegexOptions.IgnoreCase))
                    {
                        infoWeather.Add(item.WeatherInfo);
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
                        if (String.IsNullOrWhiteSpace(match.Value.Substring(3)))
                        {
                            infoWeather.Add($"{item.WeatherInfo} - altitude desconhecida");
                        }
                        else
                        {
                            string NumberString = match.Value.Substring(3, 3);

                            if (NumberString.Substring(0).Contains("0") && NumberString.Substring(0).Contains("0"))
                            {
                                double ConvertForInt = Double.Parse(match.Value.Substring(3, 3));
                                double FeetConvert = ConvertForInt*100 / 3.281;
                                infoWeather.Add($"{item.WeatherInfo} - altitude "
                                    + $"de {match.Value.Substring(3, 3)}ft = {FeetConvert.ToString("F1", CultureInfo.InvariantCulture)}m");
                            }
                            else
                            {
                                double ConvertForInt = Double.Parse(match.Value.Substring(3, 3));
                                double FeetConvert = ConvertForInt*10 / 3.281;
                                infoWeather.Add($"{item.WeatherInfo} - altitude "
                                    + $"de {match.Value.Substring(3, 3)}ft = {FeetConvert.ToString("F1", CultureInfo.InvariantCulture)}m");
                            }
                        }
                    }
                }
            }

            if (infoWeather.Count == 0)
            {
                return null;
            }
            else
            {
                return infoWeather.ToArray();
            }
        }
    }
}