using System.ComponentModel.DataAnnotations;

namespace WebApiForTests.Models
{
    public class IcaoModel
    {
        [Required]
        public string Icao { get; set; }
    }
}