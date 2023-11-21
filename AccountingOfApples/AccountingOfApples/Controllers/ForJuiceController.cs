using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers;

[Route("[controller]")]
[ApiController]
public class ForJuiceController : ControllerBase
{
    private readonly IForJuiceControlService _forJuiceControlService;
    private readonly IMapper _mapper;

    public ForJuiceController(IForJuiceControlService forJuiceControlService, IMapper mapper)
    {
        _forJuiceControlService = forJuiceControlService;
        _mapper = mapper;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetForJuices()
    {
        return Ok(_mapper.Map<List<ForJuiceViewModel>>(await _forJuiceControlService.GetAllAsync()));
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetForJuiceById(Guid id)
    {
        return Ok(_mapper.Map<ForJuiceViewModel>(await _forJuiceControlService.GetByIdAsync(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> CreateForJuice(ForJuiceViewModel forJuice)
    {
        if (ModelState.IsValid)
        {
            ForJuiceDTO? newForJuiceDTO = await _forJuiceControlService.CreateAsync(_mapper.Map<ForJuiceDTO>(forJuice));
            if (newForJuiceDTO != null)
            {
                return StatusCode(StatusCodes.Status201Created, forJuice);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(ForJuiceViewModel forJuice)
    {
        if (ModelState.IsValid)
        {
            ForJuiceDTO? updateForJuiceDTO = await _forJuiceControlService.UpdateAsync(_mapper.Map<ForJuiceDTO>(forJuice));
            if (updateForJuiceDTO != null)
            {
                return StatusCode(StatusCodes.Status200OK, forJuice);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        if (await _forJuiceControlService.Remove(id))
        {
            return NoContent();
        }
        return BadRequest("Remove Exeption!");
    }
}
