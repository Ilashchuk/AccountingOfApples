using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers;

[Route("[controller]")]
[ApiController]
public class AreaController : ControllerBase
{
    private readonly IAreaControlService _areaControlService;
    private readonly IMapper _mapper;

    public AreaController(IAreaControlService areaControlService, IMapper mapper)
    {
        _areaControlService = areaControlService;
        _mapper = mapper;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetAreas()
    {
        var s = _mapper.Map<List<AreaViewModel>>(await _areaControlService.GetAllAsync());
        return Ok(s);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetAreaById(Guid id)
    {
        return Ok(_mapper.Map<AreaViewModel>(await _areaControlService.GetByIdAsync(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> CreateArea(AreaViewModel area)
    {
        if (ModelState.IsValid)
        {
            AreaDTO? newAreaDTO = await _areaControlService.CreateAsync(_mapper.Map<AreaDTO>(area));
            if (newAreaDTO != null)
            {
                return StatusCode(StatusCodes.Status201Created, area);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(AreaViewModel area)
    {
        if (ModelState.IsValid)
        {
            AreaDTO? updateAreaDTO = await _areaControlService.UpdateAsync(_mapper.Map<AreaDTO>(area));
            if (updateAreaDTO != null)
            {
                return StatusCode(StatusCodes.Status200OK, area);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        if (await _areaControlService.Remove(id))
        {
            return NoContent();
        }
        return BadRequest("Remove Exeption!");
    }
}
