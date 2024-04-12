using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

namespace TallerMecanico.BusinessLogic.Services
{
    public class DesperfectoRepuestoService : IService<DesperfectoRepuesto>
    {
        private readonly IRepository<DesperfectoRepuesto> _desperfectorepuestoRepository;
        public DesperfectoRepuestoService(IRepository<DesperfectoRepuesto> desperfectorepuestoRepository)
        {
            _desperfectorepuestoRepository = desperfectorepuestoRepository;
        }

        public async Task AddAsync(DesperfectoRepuesto entity)
        {
            await _desperfectorepuestoRepository.AddAsync(entity);
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

        public Task UpdateAsync(DesperfectoRepuesto entity)
        {
            throw new NotImplementedException();
        }
    }
}
