namespace Air_BOT.Services.Methods
{
    public class GetDate
    {
        public string ConvertDateMetar(string Metar)
        {
            var dateYY = Metar.Substring(0, 4);
            var dateMM = Metar.Substring(4, 2);
            var dateDD = Metar.Substring(6, 2);

            switch (dateMM)
            {
                case "1":
                    dateMM = "Janeiro";
                break;
                
                case "2":
                    dateMM = "Fevereiro";
                break;

                case "3":
                    dateMM = "Março";
                break;

                case "4":
                    dateMM = "Abril";
                break;

                case "5":
                    dateMM = "Maio";
                break;

                case "6":
                    dateMM = "Junho";
                break;

                case "7":
                    dateMM = "Julho";
                break;

                case "8":
                    dateMM = "Agosto";
                break;

                case "9":
                    dateMM = "Setembro";
                break;

                case "10":
                    dateMM = "Outubro";
                break;

                case "11":
                    dateMM = "Novembro";
                break;

                case "12":
                    dateMM = "Dezembro";
                break;
            }

            return $"{dateDD} de {dateMM} de {dateYY}";
        } 
    }
}