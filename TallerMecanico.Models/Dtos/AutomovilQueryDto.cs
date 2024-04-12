using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models.Enums;

namespace TallerMecanico.Models.Dtos
{
    public class AutomovilQueryDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public TipoAutomovilEnum Tipo { get; set; }
        public int CantidadPuertas { get; set; }
    }
}
