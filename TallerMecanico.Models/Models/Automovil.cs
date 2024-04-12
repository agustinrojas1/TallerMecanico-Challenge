using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models.Enums;

namespace TallerMecanico.Models.Models
{
    public class Automovil : Vehiculo
    {
        [Required]
        public TipoAutomovilEnum Tipo { get; set; }
        [Required]
        public int CantidadPuertas { get; set; }
    }
}
