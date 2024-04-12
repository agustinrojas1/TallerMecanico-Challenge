using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Models.Dtos;
using System.Data;
using Dapper;
using Newtonsoft.Json;


namespace TallerMecanico.Persistence.Repository
{
    public class PresupuestoRepository : IRepositoryDto<Presupuesto, PresupuestoQueryDto>
    {
        private readonly IConnectionFactory _connectionFactory;

        public PresupuestoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Presupuesto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var presupuestoId = await connection.QuerySingleAsync<int>($"AddPresupuesto",
                new { entity.IdVehiculo, entity.Nombre, entity.Apellido, entity.Email, entity.Total },
                commandType: CommandType.StoredProcedure);

            entity.Id = presupuestoId;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"DeletePresupuesto",
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Presupuesto>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Presupuesto>($"GetAllPresupuestos",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Presupuesto?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<Presupuesto>($"GetPresupuestoById", 
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Presupuesto> UpdateAsync(Presupuesto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"UpdatePresupuesto",
                new { entity.Id, entity.IdVehiculo, entity.Nombre, entity.Apellido, entity.Email, entity.Total },
                commandType: CommandType.StoredProcedure);

            return entity;
        }
        public async Task<IEnumerable<Presupuesto>> GetByIdsAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Presupuesto>($"GetPresupuestosByIds", 
                new { idsString },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PresupuestoQueryDto>> GetAllDtoAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var jsonResult = await connection.QueryFirstOrDefaultAsync<string>("GetAllPresupuestosDto", commandType: CommandType.StoredProcedure);

            if (jsonResult != null)
            {
                var presupuestos = JsonConvert.DeserializeObject<IEnumerable<PresupuestoQueryDto>>(jsonResult);
                return presupuestos;
            }
            return null;

        }

        public async Task<PresupuestoQueryDto?> GetByIdDtoAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var jsonResult = await connection.QueryFirstOrDefaultAsync<string>("GetPresupuestoDtoById", new { id }, commandType: CommandType.StoredProcedure);

            if (jsonResult != null)
            {
                var presupuesto = JsonConvert.DeserializeObject<PresupuestoQueryDto>(jsonResult);
                return presupuesto;
            }

            return null;

        }

        public async Task<IEnumerable<PresupuestoQueryDto>> GetByIdsDtoAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var jsonResult = await connection.QueryFirstOrDefaultAsync<string>("GetPresupuestosDtoByIds", commandType: CommandType.StoredProcedure);

            if (jsonResult != null)
            {
                var presupuestos = JsonConvert.DeserializeObject<IEnumerable<PresupuestoQueryDto>>(jsonResult);
                return presupuestos;
            }
            return null;
        }
    }
}
