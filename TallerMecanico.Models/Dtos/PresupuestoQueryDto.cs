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
    public class PresupuestoQueryDto
    {
        public int Id { get; set; }
        public int IdVehiculo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public ICollection<DesperfectoQueryDto> Desperfectos { get; set; }
    }
}
