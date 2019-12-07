using System.Collections.Generic;

namespace WebApiForTests.Models
{
    public class JsonModel
    {
        public string Date { get; set; }
        public string Hour { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string Visibility { get; set; }
        public string[] Weather { get; set; }
        public string Temperature { get; set; }
        public string DewPoint { get; set; }
        public string Pression { get; set; }
    }
}