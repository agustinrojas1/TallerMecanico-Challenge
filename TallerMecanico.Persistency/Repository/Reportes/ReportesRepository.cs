using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models;
using TallerMecanico.Models.Models.Reportes;

namespace TallerMecanico.Persistence.Repository.Reportes
{
    public class ReportesRepository : IReportesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ReportesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<PromedioMontoTotalPresupuestoPorMarcaModeloResult>> GetPromedioMontoTotalPresupuestoPorMarcaModelo()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<PromedioMontoTotalPresupuestoPorMarcaModeloResult>($"PromedioMontoTotalPresupuestoPorMarcaModelo",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RepuestoMasUtilizadoPorMarcaModeloResult>> GetRepuestoMasUtilizadoPorMarcaModelo()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<RepuestoMasUtilizadoPorMarcaModeloResult>($"RepuestoMasUtilizadoPorMarcaModelo",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RepuestosExcluidosMassiveCharge>> GetRepuestosExcluidosMassiveCharge()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<RepuestosExcluidosMassiveCharge>($"MassiveCharge",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SumatoriaMontoTotalPresupuestosPorTipoVehiculoModeloResult>> GetSumatoriaMontoTotalPresupuestosPorTipoVehiculo()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<SumatoriaMontoTotalPresupuestosPorTipoVehiculoModeloResult>($"SumatoriaMontoTotalPresupuestosPorTipoVehiculo",
                commandType: CommandType.StoredProcedure);
        }
    }
}
