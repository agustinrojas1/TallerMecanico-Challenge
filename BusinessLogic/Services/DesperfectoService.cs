using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

namespace TallerMecanico.BusinessLogic.Services
{
    public class DesperfectoService : IService<Desperfecto>
    {
        private readonly IRepository<Desperfecto> _desperfectoRepository;
        public DesperfectoService(IRepository<Desperfecto> desperfectoRepository)
        {
            _desperfectoRepository = desperfectoRepository;
        }

        public async Task AddAsync(Desperfecto desperfecto)
        {
            await _desperfectoRepository.AddAsync(desperfecto);
        }

        public async Task DeleteAsync(int id)
        {
            await _desperfectoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Desperfecto>> GetAllAsync()
        {
            return await _desperfectoRepository.GetAllAsync();
        }

        public async Task<Desperfecto?> GetByIdAsync(int id)
        {
            return await _desperfectoRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Desperfecto desperfecto)
        {
            await _desperfectoRepository.UpdateAsync(desperfecto);
        }

        public async Task<IEnumerable<Desperfecto>> GetByIdsAsync(List<int> ids)
        {
            return await _desperfectoRepository.GetByIdsAsync(ids);
        }
    }
}
