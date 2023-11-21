using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers;

[Route("[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{

    private readonly IOwnerControlService _ownerControlService;
    private readonly IMapper _mapper;

    public OwnerController(IOwnerControlService ownerControlService, IMapper mapper)
    {
        _ownerControlService = ownerControlService;
        _mapper = mapper;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetOwners()
    {
        return Ok(_mapper.Map<List<OwnerViewModel>>(await _ownerControlService.GetAllAsync()));
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetOwnerById(Guid id)
    {
        return Ok(_mapper.Map<OwnerViewModel>(await _ownerControlService.GetByIdAsync(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> CreateOwner(OwnerViewModel owner)
    {
        if (ModelState.IsValid)
        {
            OwnerDTO? newOwnerDTO = await _ownerControlService.CreateAsync(_mapper.Map<OwnerDTO>(owner));
            if (newOwnerDTO != null)
            {
                return StatusCode(StatusCodes.Status201Created, owner);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(OwnerViewModel owner)
    {
        if (ModelState.IsValid)
        {
            OwnerDTO? updateOwnerDTO = await _ownerControlService.UpdateAsync(_mapper.Map<OwnerDTO>(owner));
            if (updateOwnerDTO != null)
            {
                return StatusCode(StatusCodes.Status200OK, owner);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        if (await _ownerControlService.Remove(id))
        {
            return NoContent();
        }
        return BadRequest("Remove Exeption!");
    }
}
