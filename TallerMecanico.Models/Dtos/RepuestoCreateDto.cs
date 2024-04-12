using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Models.Dtos
{
    public class RepuestoCreateDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
