using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Models.Models.Reportes
{
    public class PromedioMontoTotalPresupuestoPorMarcaModeloResult
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal PromedioMontoTotal { get; set; }
    }
}
