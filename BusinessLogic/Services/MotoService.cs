using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

namespace TallerMecanico.BusinessLogic.Services
{
    public class MotoService : IServiceDto<Moto, MotoQueryDto>
    {
        private readonly IRepositoryDto<Moto, MotoQueryDto> _motoRepository;
        public MotoService(IRepositoryDto<Moto, MotoQueryDto> motoRepository)
        {
            _motoRepository = motoRepository;
        }

        public async Task AddAsync(Moto moto)
        {
            await _motoRepository.AddAsync(moto);
        }

        public async Task DeleteAsync(int id)
        {
            await _motoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Moto>> GetAllAsync()
        {
            return await _motoRepository.GetAllAsync();
        }

        public async Task<Moto?> GetByIdAsync(int id)
        {
            return await _motoRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Moto moto)
        {
            await _motoRepository.UpdateAsync(moto);
        }

        public async Task<IEnumerable<Moto>> GetByIdsAsync(List<int> ids)
        {
            return await _motoRepository.GetByIdsAsync(ids);
        }

        public async Task<IEnumerable<MotoQueryDto>> GetAllDtoAsync()
        {
            return await _motoRepository.GetAllDtoAsync();
        }

        public async Task<MotoQueryDto?> GetByIdDtoAsync(int id)
        {
            return await _motoRepository.GetByIdDtoAsync(id);
        }

        public async Task<IEnumerable<MotoQueryDto>> GetByIdsDtoAsync(List<int> ids)
        {
            return await _motoRepository.GetByIdsDtoAsync(ids);
        }
    }
}
