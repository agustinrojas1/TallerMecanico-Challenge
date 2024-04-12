using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

namespace TallerMecanico.BusinessLogic.Services
{
    public class AutomovilService : IServiceDto<Automovil, AutomovilQueryDto>
    {
        private readonly IRepositoryDto<Automovil, AutomovilQueryDto> _autoRepository;
        public AutomovilService(IRepositoryDto<Automovil, AutomovilQueryDto> autoRepository)
        {
            _autoRepository = autoRepository;
        }

        public async Task AddAsync(Automovil auto)
        {
            await _autoRepository.AddAsync(auto);
        }

        public async Task DeleteAsync(int id)
        {
            await _autoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Automovil>> GetAllAsync()
        {
            return await _autoRepository.GetAllAsync(); 
        }

        public async Task<Automovil?> GetByIdAsync(int id)
        {
            return await _autoRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Automovil auto)
        {
            await _autoRepository.UpdateAsync(auto);
        }
        public async Task<IEnumerable<Automovil>> GetByIdsAsync(List<int> ids)
        {
            return await _autoRepository.GetByIdsAsync(ids);
        }

        public async Task<IEnumerable<AutomovilQueryDto>> GetAllDtoAsync()
        {
            return await _autoRepository.GetAllDtoAsync();
        }

        public async Task<AutomovilQueryDto?> GetByIdDtoAsync(int id)
        {
            return await _autoRepository.GetByIdDtoAsync(id);
        }

        public async Task<IEnumerable<AutomovilQueryDto>> GetByIdsDtoAsync(List<int> ids)
        {
            return await _autoRepository.GetByIdsDtoAsync(ids);
        }
    }
}
