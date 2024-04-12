using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models.Reportes;

namespace TallerMecanico.Persistence.Repository.Reportes
{
    public interface IReportesRepository
    {
        Task<IEnumerable<RepuestoMasUtilizadoPorMarcaModeloResult>> GetRepuestoMasUtilizadoPorMarcaModelo();
        Task<IEnumerable<PromedioMontoTotalPresupuestoPorMarcaModeloResult>> GetPromedioMontoTotalPresupuestoPorMarcaModelo();
        Task<IEnumerable<SumatoriaMontoTotalPresupuestosPorTipoVehiculoModeloResult>> GetSumatoriaMontoTotalPresupuestosPorTipoVehiculo();
        Task<IEnumerable<RepuestosExcluidosMassiveCharge>> GetRepuestosExcluidosMassiveCharge();

    }
}
