using System.ComponentModel.DataAnnotations;
using TallerMecanico.Models.Models.Enums;

namespace TallerMecanico.Models.Models
{
    public class Moto : Vehiculo
    {
        [Required]
        public string Cilindrada { get; set; }
    }
}
