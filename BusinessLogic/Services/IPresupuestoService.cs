using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;

namespace TallerMecanico.BusinessLogic.Services
{
    public interface IPresupuestoService : IServiceDto<Presupuesto, PresupuestoQueryDto>
    {
       Task<decimal> CalculateTotalCost(Presupuesto presupuesto);
    }
}
