using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Models.Models
{
    public class Desperfecto
    {
        public Desperfecto()
        {
            DesperfectoRepuestos = new List<DesperfectoRepuesto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdPresupuesto { get; set; }
        public Presupuesto Presupuesto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal ManoDeObra { get; set; }
        [Required]
        public int Tiempo { get; set; }
        public ICollection<DesperfectoRepuesto> DesperfectoRepuestos { get; set; }

    }
}
