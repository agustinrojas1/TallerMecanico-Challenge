using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Persistence.Repository
{
    public interface IRepositoryDto<T, TDto> : IRepository<T>
    {
        Task<IEnumerable<TDto>> GetAllDtoAsync();
        Task<TDto?> GetByIdDtoAsync(int id);
        Task<IEnumerable<TDto>> GetByIdsDtoAsync(List<int> ids);
    }

}
