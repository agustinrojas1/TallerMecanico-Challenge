using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models;
using TallerMecanico.Models.Models.Enums;

namespace TallerMecanico.Models.Dtos
{
    public class PresupuestoCreateDto
    {
        [Required]
        public int IdVehiculo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<DesperfectoCreateDto> Desperfectos { get; set; }
    }
}
