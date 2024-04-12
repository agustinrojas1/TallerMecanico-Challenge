using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Models.Models.Reportes
{
    public class RepuestoMasUtilizadoPorMarcaModeloResult
    {
        public string RepuestoNombre{ get; set; }
        public int CantidadVecesUsado { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}
