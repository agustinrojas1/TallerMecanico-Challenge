using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models.Reportes;

namespace TallerMecanico.BusinessLogic.Services.Reportes
{
    public interface IReportesService
    {
        Task<IEnumerable<RepuestoMasUtilizadoPorMarcaModeloResult>> GetRepuestoMasUtilizadoPorMarcaModelo();
        Task<IEnumerable<PromedioMontoTotalPresupuestoPorMarcaModeloResult>> GetPromedioMontoTotalPresupuestoPorMarcaModelo();
        Task<IEnumerable<SumatoriaMontoTotalPresupuestosPorTipoVehiculoModeloResult>> GetSumatoriaMontoTotalPresupuestosPorTipoVehiculo();
        Task<IEnumerable<RepuestosExcluidosMassiveCharge>> GetRepuestosExcluidosMassiveCharge();

    }
}
