using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Models.Dtos;
using System.Data;
using Dapper;


namespace TallerMecanico.Persistence.Repository
{
    public class RepuestoRepository : IRepository<Repuesto>
    {
        private readonly IConnectionFactory _connectionFactory;

        public RepuestoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Repuesto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var repuestoId = await connection.QuerySingleAsync<int>($"AddRepuesto",
                new { entity.Nombre, entity.Precio },
                commandType: CommandType.StoredProcedure);

            entity.Id = repuestoId;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"DeleteRepuesto",
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Repuesto>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Repuesto>($"GetAllRepuestos",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Repuesto?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<Repuesto>($"GetRepuestoById", 
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Repuesto> UpdateAsync(Repuesto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"UpdateRepuesto",
                new { entity.Id, entity.Nombre, entity.Precio },
                commandType: CommandType.StoredProcedure);

            return entity;
        }
        public async Task<IEnumerable<Repuesto>> GetByIdsAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Repuesto>($"GetRepuestosByIds", 
                new { Ids = idsString },
                commandType: CommandType.StoredProcedure);
        }

    }
}
