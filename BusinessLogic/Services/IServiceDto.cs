using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

namespace TallerMecanico.BusinessLogic.Services
{
    public interface IServiceDto<T, TDto> : IService<T>
    {
        Task<IEnumerable<TDto>> GetAllDtoAsync();
        Task<TDto?> GetByIdDtoAsync(int id);
        Task<IEnumerable<TDto>> GetByIdsDtoAsync(List<int> ids);
    }
}
