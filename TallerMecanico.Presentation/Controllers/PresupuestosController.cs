using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TallerMecanico.BusinessLogic.Services;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

[Route("api/presupuestos")]
[ApiController]
public class PresupuestosController : ControllerBase
{
    private readonly IPresupuestoService _presupuestoService;
    private readonly IService<Desperfecto> _desperfectoService;
    private readonly IService<Repuesto> _repuestoService;
    private readonly IService<DesperfectoRepuesto> _desperfectoRepuestoService;
    private readonly IMapper _mapper;

    public PresupuestosController(IPresupuestoService presupuestoService, IService<Desperfecto> desperfectoService, IService<Repuesto> repuestoService, IService<DesperfectoRepuesto> desperfectoRepuestoService, IMapper mapper)
    {
        _presupuestoService = presupuestoService;
        _desperfectoService = desperfectoService;
        _repuestoService = repuestoService;
        _desperfectoRepuestoService = desperfectoRepuestoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePresupuesto([FromBody] PresupuestoCreateDto presupuestoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var presupuesto = _mapper.Map<Presupuesto>(presupuestoDto);
        await _presupuestoService.AddAsync(presupuesto);

        foreach (var desperfectoDto in presupuestoDto.Desperfectos)
        {
            var desperfecto = _mapper.Map<Desperfecto>(desperfectoDto);
            desperfecto.IdPresupuesto = presupuesto.Id;

            await _desperfectoService.AddAsync(desperfecto);

            //aca no sería mejor permitir la creacion de repuestos ahi mismo?

            //no deberia hacer un foreach al desperfectoDto.RepuestosIds?
            //supongo que no, porque uno puede ingresar Ids que no existan

            var repuestos = await _repuestoService.GetByIdsAsync(desperfectoDto.RepuestosIds);

            foreach (var repuesto in repuestos)
            {
                var desperfectoRepuesto = new DesperfectoRepuesto
                {
                    DesperfectoId = desperfecto.Id,
                    Desperfecto = desperfecto,
                    RepuestoId = repuesto.Id,
                    Repuesto = repuesto,
                };

                //aca se podria hacer un addRangeASync no?
                await _desperfectoRepuestoService.AddAsync(desperfectoRepuesto);
                desperfecto.DesperfectoRepuestos.Add(desperfectoRepuesto);
            }
            presupuesto.Desperfectos.Add(desperfecto);

        }

        var totalPresupuesto = await _presupuestoService.CalculateTotalCost(presupuesto);
        presupuesto.Total = totalPresupuesto;

        await _presupuestoService.UpdateAsync(presupuesto);

        var presupuestoQueryDto = _mapper.Map<PresupuestoQueryDto>(presupuesto);

        return CreatedAtAction(nameof(GetPresupuestoById), new { id = presupuesto.Id }, presupuestoQueryDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PresupuestoQueryDto>> GetPresupuestoById([FromRoute] int id)
    {
        var presupuesto = await _presupuestoService.GetByIdDtoAsync(id);

        if (presupuesto == null)
        {
            return NotFound();
        }

        return presupuesto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PresupuestoQueryDto>>> GetPresupuestos()
    {
        return Ok(await _presupuestoService.GetAllDtoAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePresupuesto([FromRoute] int id, [FromBody] PresupuestoCreateDto presupuestoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var presupuesto = _mapper.Map<Presupuesto>(presupuestoDto);

        await _presupuestoService.UpdateAsync(presupuesto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePresupuesto([FromRoute] int id)
    {
        await _presupuestoService.DeleteAsync(id);

        return NoContent();
    }
}