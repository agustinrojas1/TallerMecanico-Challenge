using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TallerMecanico.BusinessLogic.Services;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

[Route("api/repuestos")]
[ApiController]
public class RepuestosController : ControllerBase
{
    private readonly IService<Repuesto> _repuestoService;
    private readonly IMapper _mapper;

    public RepuestosController(IService<Repuesto> repuestoService, IMapper mapper)
    {
        _repuestoService = repuestoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateRepuesto([FromBody] RepuestoCreateDto repuestoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var repuesto = _mapper.Map<Repuesto>(repuestoDto);

        await _repuestoService.AddAsync(repuesto);

        return CreatedAtAction(nameof(GetRepuestoById), new { id = repuesto.Id }, repuesto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Repuesto>> GetRepuestoById([FromRoute] int id)
    {
        var repuesto = await _repuestoService.GetByIdAsync(id);

        if (repuesto == null)
        {
            return NotFound();
        }

        return repuesto;
    }

    [HttpGet("{ids}")]
    public async Task<ActionResult<Repuesto>> GetRepuestosByIds([FromRoute] List<int> ids)
    {
        return Ok(await _repuestoService.GetByIdsAsync(ids));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Repuesto>>> GetRepuestos()
    {
        return Ok(await _repuestoService.GetAllAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRepuesto([FromRoute] int id, [FromBody] RepuestoCreateDto repuestoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var repuesto = _mapper.Map<Repuesto>(repuestoDto);

        await _repuestoService.UpdateAsync(repuesto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRepuesto([FromRoute] int id)
    {
        await _repuestoService.DeleteAsync(id);

        return NoContent();
    }
}