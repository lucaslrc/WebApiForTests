using System.Linq;

namespace WebApiForTests.Services.Methods
{
    public class GetDewPoint
    {
        public string GetDewPointMetar(string Metar)
        {
            string dewPoint = Metar.Substring(Metar.IndexOf("/"), 3).Substring(1);

            return dewPoint;
        }
    }
}