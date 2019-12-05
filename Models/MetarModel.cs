using System.ComponentModel.DataAnnotations;

namespace WebApiForTests.Models
{
    public class MetarModel
    {
        [Required]
        public string Metar { get; set; }
    }
}