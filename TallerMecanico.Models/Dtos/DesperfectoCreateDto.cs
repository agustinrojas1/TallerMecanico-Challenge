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
    public class DesperfectoCreateDto
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal ManoDeObra { get; set; }
        [Required]
        public int Tiempo { get; set; }
        public List<int> RepuestosIds { get; set; }

    }
}
