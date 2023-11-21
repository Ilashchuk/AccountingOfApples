using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers;

[Route("[controller]")]
[ApiController]
public class AppleVarietyController : ControllerBase
{
    private readonly IAppleVarietyControlService _appleVarietyControlService;
    private readonly IMapper _mapper;

    public AppleVarietyController(IAppleVarietyControlService appleVarietyControlService, IMapper mapper)
    {
        _appleVarietyControlService = appleVarietyControlService;
        _mapper = mapper;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetAppleVarieties()
    {
        return Ok(_mapper.Map<List<AppleVarietyViewModel>>(await _appleVarietyControlService.GetAllAsync()));
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetAppleVarietyById(Guid id)
    {
        return Ok(_mapper.Map<AppleVarietyViewModel>(await _appleVarietyControlService.GetByIdAsync(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> CreateAppleVariety(AppleVarietyViewModel appleVariety)
    {
        if (ModelState.IsValid)
        {
            AppleVarietyDTO? newAppleVarietyDTO = await _appleVarietyControlService.CreateAsync(_mapper.Map<AppleVarietyDTO>(appleVariety));
            if (newAppleVarietyDTO != null)
            {
                return StatusCode(StatusCodes.Status201Created, appleVariety);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(AppleVarietyViewModel appleVariety)
    {
        if (ModelState.IsValid)
        {
            AppleVarietyDTO? updateAppleVarietyDTO = await _appleVarietyControlService.UpdateAsync(_mapper.Map<AppleVarietyDTO>(appleVariety));
            if (updateAppleVarietyDTO != null)
            {
                return StatusCode(StatusCodes.Status200OK, appleVariety);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        if (await _appleVarietyControlService.Remove(id))
        {
            return NoContent();
        }
        return BadRequest("Remove Exeption!");
    }
}
