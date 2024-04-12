using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

namespace TallerMecanico.BusinessLogic.Services
{
    public class RepuestoService : IService<Repuesto>
    {
        private readonly IRepository<Repuesto> _repuestoRepository;
        public RepuestoService(IRepository<Repuesto> repuestoRepository)
        {
            _repuestoRepository = repuestoRepository;
        }

        public async Task AddAsync(Repuesto repuesto)
        {
            await _repuestoRepository.AddAsync(repuesto);
        }

        public async Task DeleteAsync(int id)
        {
            await _repuestoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Repuesto>> GetAllAsync()
        {
            return await _repuestoRepository.GetAllAsync();
        }

        public async Task<Repuesto?> GetByIdAsync(int id)
        {
            return await _repuestoRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Repuesto repuesto)
        {
            await _repuestoRepository.UpdateAsync(repuesto);
        }

        public async Task<IEnumerable<Repuesto>> GetByIdsAsync(List<int> ids)
        {
            return await _repuestoRepository.GetByIdsAsync(ids);
        }
    }
}
