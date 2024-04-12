using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TallerMecanico.BusinessLogic.Services;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence.Repository;

[Route("api/motos")]
[ApiController]
public class MotosController : ControllerBase
{
    private readonly IServiceDto<Moto, MotoQueryDto> _motoService;
    private readonly IMapper _mapper;

    public MotosController(IServiceDto<Moto, MotoQueryDto> motoService, IMapper mapper)
    {
        _motoService = motoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateMoto([FromBody] MotoCreateDto motoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var moto = _mapper.Map<Moto>(motoDto);

        await _motoService.AddAsync(moto);

        return CreatedAtAction(nameof(GetMotoById), new { id = moto.Id }, moto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MotoQueryDto>> GetMotoById([FromRoute] int id)
    {
        var moto = await _motoService.GetByIdDtoAsync(id);
        
        if (moto == null)
        {
            return NotFound();
        }

        return moto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MotoQueryDto>>> GetMotos()
    {
        return Ok(await _motoService.GetAllDtoAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateMoto([FromRoute] int id, [FromBody] MotoCreateDto motoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var moto = _mapper.Map<Moto>(motoDto);
        moto.Id = id;

        await _motoService.UpdateAsync(moto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMoto([FromRoute] int id)
    {
        await _motoService.DeleteAsync(id);

        return NoContent();
    }
}