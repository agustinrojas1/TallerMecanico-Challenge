using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerMecanico.BusinessLogic.Services.Reportes;
using TallerMecanico.Models.Models;
using TallerMecanico.Models.Models.Reportes;

namespace TallerMecanico.Presentation.Controllers.Reportes
{
    [ApiController]
    [Route("api/reportes")]
    public class ReportesController : Controller
    {
        private readonly IReportesService _reportesService;
        public ReportesController(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        /* Repuesto más utilizado agrupado por Marca/Modelo en las reparaciones realizadas
        (mostrar Descripción del Repuesto y cantidad de veces usado)*/

        // GET /api/reportes/repuestos-mas-utilizados
        [HttpGet("repuestos-mas-utilizados")]
        public async Task<IEnumerable<RepuestoMasUtilizadoPorMarcaModeloResult>> GetRepuestoMasUtilizadoPorMarcaModelo()
        {
            return await _reportesService.GetRepuestoMasUtilizadoPorMarcaModelo();
        }

        /* Promedio del Monto Total de Presupuestos agrupado por Marca/Modelo */

        // GET /api/reportes/promedio-montos-presupuestos
        [HttpGet("promedio-montos-presupuestos")]
        public async Task<IEnumerable<PromedioMontoTotalPresupuestoPorMarcaModeloResult>> GetPromedioMontoTotalPresupuestoPorMarcaModelo()
        {
            return await _reportesService.GetPromedioMontoTotalPresupuestoPorMarcaModelo();
        }

        /* Sumatoria del Monto Total de Presupuestos para Autos y para Motos */

        // GET /api/reportes/sumatoria-montos-presupuestos
        [HttpGet("sumatoria-montos-presupuestos")]
        public async Task<IEnumerable<SumatoriaMontoTotalPresupuestosPorTipoVehiculoModeloResult>> GetSumatoriaMontoTotalPresupuestosPorTipoVehiculo()
        {
            return await _reportesService.GetSumatoriaMontoTotalPresupuestosPorTipoVehiculo();
        }

        /* Listado de Repuestos Excluidos en la carga masiva de presupuestos */

        // GET /api/reportes/repuestos-exluidos-massivecharge
        [HttpGet("repuestos-exluidos-massivecharge")]
        public async Task<IEnumerable<RepuestosExcluidosMassiveCharge>> GetRepuestosExcluidosMassiveCharges()
        {
            return await _reportesService.GetRepuestosExcluidosMassiveCharge();
        }
    }
}
