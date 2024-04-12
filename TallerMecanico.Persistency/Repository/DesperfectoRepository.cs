using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Models.Dtos;
using System.Data;
using Dapper;


namespace TallerMecanico.Persistence.Repository
{
    public class DesperfectoRepository : IRepository<Desperfecto>
    {
        private readonly IConnectionFactory _connectionFactory;

        public DesperfectoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Desperfecto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var desperfectoId = await connection.QuerySingleAsync<int>($"AddDesperfecto",
                new { entity.IdPresupuesto, entity.Descripcion, entity.ManoDeObra, entity.Tiempo },
                commandType: CommandType.StoredProcedure);

            entity.Id = desperfectoId;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"DeleteDesperfecto",
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Desperfecto>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Desperfecto>($"GetAllDesperfectos",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Desperfecto?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<Desperfecto>($"GetDesperfectoById", 
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Desperfecto> UpdateAsync(Desperfecto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"UpdateDesperfecto",
                new { entity.Id, entity.IdPresupuesto, entity.Descripcion, entity.ManoDeObra, entity.Tiempo },
                commandType: CommandType.StoredProcedure);

            return entity;
        }
        public async Task<IEnumerable<Desperfecto>> GetByIdsAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Desperfecto>($"GetDesperfectosByIds", 
                new { idsString },
                commandType: CommandType.StoredProcedure);
        }

    }
}
