using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TallerMecanico.BusinessLogic.Services;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Models.Models.Enums;
using TallerMecanico.Persistence.Repository;

[Route("api/autos")]
[ApiController]
public class AutosController : ControllerBase
{
    private readonly IServiceDto<Automovil, AutomovilQueryDto> _autoService;
    private readonly IMapper _mapper;

    public AutosController(IServiceDto<Automovil, AutomovilQueryDto> autoService, IMapper mapper)
    {
        _autoService = autoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAuto([FromBody] AutomovilCreateDto autoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var auto = _mapper.Map<Automovil>(autoDto);

        await _autoService.AddAsync(auto);

        return CreatedAtAction(nameof(GetAutoById), new { id = auto.Id }, auto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AutomovilQueryDto>> GetAutoById([FromRoute] int id)
    {
        var auto = await _autoService.GetByIdDtoAsync(id);

        if (auto == null)
        {
            return NotFound();
        }

        return auto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutomovilQueryDto>>> GetAutos()
    {
        return Ok(await _autoService.GetAllDtoAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuto([FromRoute] int id, [FromBody] AutomovilCreateDto autoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if(await _autoService.GetByIdAsync(id) == null)
        {
            return NotFound(ModelState);    
        }

        var auto = _mapper.Map<Automovil>(autoDto);
        auto.Id = id;

        await _autoService.UpdateAsync(auto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuto([FromRoute] int id)
    {
        await _autoService.DeleteAsync(id);

        return NoContent();
    }
}