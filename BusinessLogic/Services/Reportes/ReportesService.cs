using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models.Reportes;
using TallerMecanico.Persistence.Repository.Reportes;

namespace TallerMecanico.BusinessLogic.Services.Reportes
{
    public class ReportesService : IReportesService
    {
        private readonly IReportesRepository _reportesRepository;
        public ReportesService(IReportesRepository reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }
        public async Task<IEnumerable<PromedioMontoTotalPresupuestoPorMarcaModeloResult>> GetPromedioMontoTotalPresupuestoPorMarcaModelo()
        {
           return await _reportesRepository.GetPromedioMontoTotalPresupuestoPorMarcaModelo();
        }

        public async Task<IEnumerable<RepuestoMasUtilizadoPorMarcaModeloResult>> GetRepuestoMasUtilizadoPorMarcaModelo()
        {
            return await _reportesRepository.GetRepuestoMasUtilizadoPorMarcaModelo();
        }

        public async Task<IEnumerable<RepuestosExcluidosMassiveCharge>> GetRepuestosExcluidosMassiveCharge()
        {
            return await _reportesRepository.GetRepuestosExcluidosMassiveCharge();
        }

        public async Task<IEnumerable<SumatoriaMontoTotalPresupuestosPorTipoVehiculoModeloResult>> GetSumatoriaMontoTotalPresupuestosPorTipoVehiculo()
        {
            return await _reportesRepository.GetSumatoriaMontoTotalPresupuestosPorTipoVehiculo();
        }
    }
}
