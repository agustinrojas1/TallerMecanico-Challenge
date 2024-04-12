using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Models.Dtos;
using System.Data;
using Dapper;


namespace TallerMecanico.Persistence.Repository
{
    public class AutomovilRepository : IRepositoryDto<Automovil, AutomovilQueryDto>
    {
        private readonly IConnectionFactory _connectionFactory;

        public AutomovilRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Automovil entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var automovilId = await connection.QuerySingleAsync<int>($"AddAutomovil",
                new { entity.Marca, entity.Modelo, entity.Patente, Tipo = (int)entity.Tipo, entity.CantidadPuertas},
                commandType: CommandType.StoredProcedure);

            entity.Id = automovilId;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"DeleteAutomovil",
                new {id}, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Automovil>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Automovil>($"GetAllAutomoviles", 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Automovil?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<Automovil>($"GetAutomovilById", 
                new {id},
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Automovil> UpdateAsync(Automovil entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"UpdateAutomovil",
                new {entity.Id, entity.Marca, entity.Modelo, entity.Patente, Tipo = (int)entity.Tipo, entity.CantidadPuertas },
                commandType: CommandType.StoredProcedure);

            return entity;
        }
        public async Task<IEnumerable<Automovil>> GetByIdsAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Automovil>($"GetAutomovilesByIds", new { idsString },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AutomovilQueryDto>> GetAllDtoAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<AutomovilQueryDto>($"GetAllAutomovilesDto",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<AutomovilQueryDto?> GetByIdDtoAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<AutomovilQueryDto>($"GetAutomovilDtoById", 
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AutomovilQueryDto>> GetByIdsDtoAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<AutomovilQueryDto>($"GetAutomovilesDtoByIds", 
                new { idsString },
                commandType: CommandType.StoredProcedure);
        }
    }
}
