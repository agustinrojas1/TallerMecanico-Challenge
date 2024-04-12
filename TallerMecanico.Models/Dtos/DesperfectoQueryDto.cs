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
    public class DesperfectoQueryDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal ManoDeObra { get; set; }
        public int Tiempo { get; set; }
        public ICollection<RepuestoQueryDto> Repuestos { get; set; }

    }
}
