﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Models.Models
{
    public class Repuesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre{ get; set; }
        [Required]
        public decimal Precio { get; set; }
        public ICollection<DesperfectoRepuesto> DesperfectoRepuestos { get; set; }

    }
}
