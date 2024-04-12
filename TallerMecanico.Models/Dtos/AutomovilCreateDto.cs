using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models.Enums;

namespace TallerMecanico.Models.Dtos
{
    public class AutomovilCreateDto
    {
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Patente { get; set; }
        [Required]
        public TipoAutomovilEnum Tipo { get; set; }
        [Required]
        public int CantidadPuertas { get; set; }
    }
}
