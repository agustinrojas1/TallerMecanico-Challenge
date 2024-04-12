using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TallerMecanico.BusinessLogic.Services;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

[Route("api/desperfectos")]
[ApiController]
public class DesperfectosController : ControllerBase
{
    private readonly IService<Desperfecto> _desperfectoService;
    private readonly IMapper _mapper;

    public DesperfectosController(IService<Desperfecto> desperfectoService, IMapper mapper)
    {
        _desperfectoService = desperfectoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDesperfecto([FromBody] DesperfectoCreateDto desperfectoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var desperfecto = _mapper.Map<Desperfecto>(desperfectoDto);

        await _desperfectoService.AddAsync(desperfecto);

        return CreatedAtAction(nameof(GetDesperfectoById), new { id = desperfecto.Id }, desperfecto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Desperfecto>> GetDesperfectoById([FromRoute] int id)
    {
        var desperfecto = await _desperfectoService.GetByIdAsync(id);

        if (desperfecto == null)
        {
            return NotFound();
        }

        return desperfecto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Desperfecto>>> GetDesperfectos()
    {
        return Ok(await _desperfectoService.GetAllAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDesperfecto([FromRoute] int id, [FromBody] DesperfectoCreateDto desperfectoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var desperfecto = _mapper.Map<Desperfecto>(desperfectoDto);

        await _desperfectoService.UpdateAsync(desperfecto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDesperfecto([FromRoute] int id)
    {
        await _desperfectoService.DeleteAsync(id);

        return NoContent();
    }
}