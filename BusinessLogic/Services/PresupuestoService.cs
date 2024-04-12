using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

namespace TallerMecanico.BusinessLogic.Services
{
    public class PresupuestoService : IPresupuestoService
    {
        private readonly IRepositoryDto<Presupuesto, PresupuestoQueryDto> _presupuestoRepository;
        public PresupuestoService(IRepositoryDto<Presupuesto, PresupuestoQueryDto> presupuestoRepository)
        {
            _presupuestoRepository = presupuestoRepository;
        }

        public async Task AddAsync(Presupuesto presupuesto)
        {
            await _presupuestoRepository.AddAsync(presupuesto);
        }

        public async Task DeleteAsync(int id)
        {
            await _presupuestoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Presupuesto>> GetAllAsync()
        {
            return await _presupuestoRepository.GetAllAsync();
        }

        public async Task<Presupuesto?> GetByIdAsync(int id)
        {
            return await _presupuestoRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Presupuesto presupuesto)
        {
            await _presupuestoRepository.UpdateAsync(presupuesto);
        }

        public async Task<IEnumerable<Presupuesto>> GetByIdsAsync(List<int> ids)
        {
            return await _presupuestoRepository.GetByIdsAsync(ids);
        }

        public async Task<decimal> CalculateTotalCost(Presupuesto presupuesto)
        {
            decimal repuestosCost = presupuesto.Desperfectos.SelectMany(d => d.DesperfectoRepuestos)
                                                            .Sum(dr => dr.Repuesto.Precio);

            decimal labourCost = presupuesto.Desperfectos.Sum(d => d.ManoDeObra);

            int daysOfWork = presupuesto.Desperfectos.Sum(d => d.Tiempo);

            decimal parkingCost = daysOfWork * 130; 

            decimal totalBeforeSurcharge = repuestosCost + labourCost + parkingCost;

            decimal workshopSurcharge = totalBeforeSurcharge * 0.10m;

            decimal totalWithSurcharge = totalBeforeSurcharge + workshopSurcharge;

            return totalWithSurcharge;
        }

        public async Task<IEnumerable<PresupuestoQueryDto>> GetAllDtoAsync()
        {
            return await _presupuestoRepository.GetAllDtoAsync();
        }

        public async Task<PresupuestoQueryDto?> GetByIdDtoAsync(int id)
        {
            return await _presupuestoRepository.GetByIdDtoAsync(id);
        }

        public async Task<IEnumerable<PresupuestoQueryDto>> GetByIdsDtoAsync(List<int> ids)
        {
            return await _presupuestoRepository.GetByIdsDtoAsync(ids);
        }
    }
}
