using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Models.Dtos;
using System.Data;
using Dapper;

namespace TallerMecanico.Persistence.Repository
{
    public class DesperfectoRepuestoRepository : IRepository<DesperfectoRepuesto>
    {
        private readonly IConnectionFactory _connectionFactory;

        public DesperfectoRepuestoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(DesperfectoRepuesto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"AddDesperfectoRepuesto",
                new { entity.DesperfectoId, entity.RepuestoId},
                commandType: CommandType.StoredProcedure);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DesperfectoRepuesto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DesperfectoRepuesto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DesperfectoRepuesto>> GetByIdsAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<DesperfectoRepuesto> UpdateAsync(DesperfectoRepuesto entity)
        {
            throw new NotImplementedException();
        }
    }
}
