using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Models.Dtos;
using System.Data;
using Dapper;


namespace TallerMecanico.Persistence.Repository
{
    public class MotoRepository : IRepositoryDto<Moto, MotoQueryDto>
    {
        private readonly IConnectionFactory _connectionFactory;

        public MotoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Moto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var motoId = await connection.QuerySingleAsync<int>($"AddMoto",
                new { entity.Marca, entity.Modelo, entity.Patente, entity.Cilindrada },
                commandType: CommandType.StoredProcedure);

            entity.Id = motoId;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"DeleteMoto",
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Moto>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Moto>($"GetAllMotos",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Moto?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<Moto>($"GetMotoById", 
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Moto> UpdateAsync(Moto entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync($"UpdateMoto",
                new { entity.Id, entity.Marca, entity.Modelo, entity.Patente, entity.Cilindrada },
                commandType: CommandType.StoredProcedure);

            return entity;
        }
        public async Task<IEnumerable<Moto>> GetByIdsAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Moto>($"GetMotosByIds", 
                new { idsString },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MotoQueryDto>> GetAllDtoAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<MotoQueryDto>($"GetAllMotosDto",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<MotoQueryDto?> GetByIdDtoAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<MotoQueryDto>($"GetMotoDtoById", 
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MotoQueryDto>> GetByIdsDtoAsync(List<int> ids)
        {
            string idsString = string.Join(",", ids);

            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<MotoQueryDto>($"GetMotosDtoByIds", 
                new { idsString },
                commandType: CommandType.StoredProcedure);
        }
    }
}
