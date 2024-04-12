using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Models.Models
{
    public class DesperfectoRepuesto
    {
        [Key]
        [Column(Order = 1)]
        public int DesperfectoId { get; set; }
        public Desperfecto Desperfecto { get; set; }
        [Key]
        [Column(Order = 2)]
        public int RepuestoId { get; set; }
        public Repuesto Repuesto { get; set; }
    }
}
