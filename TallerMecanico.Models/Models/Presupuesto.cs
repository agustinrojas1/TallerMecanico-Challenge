using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Models.Models
{
    public class Presupuesto
    {
        public Presupuesto()
        {
            Desperfectos = new List<Desperfecto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; } 
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set;}
        [Required]
        public string Email { get; set; }
        public decimal Total { get; set; } = 0;
        public ICollection<Desperfecto> Desperfectos { get; set; }

    }
}
