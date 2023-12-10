using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers;

[Route("[controller]")]
[ApiController]
public class PackagingController : ControllerBase
{
    private readonly IPackagingControlService _packagingControlService;
    private readonly IMapper _mapper;

    public PackagingController(IPackagingControlService packagingControlService, IMapper mapper)
    {
        _packagingControlService = packagingControlService;
        _mapper = mapper;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetPackagings()
    {
        return Ok(_mapper.Map<List<PackagingViewModel>>(await _packagingControlService.GetAllAsync()));
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetPackagingById(Guid id)
    {
        return Ok(_mapper.Map<PackagingViewModel>(await _packagingControlService.GetByIdAsync(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> CreatePackaging(PackagingViewModel packaging)
    {
        if (ModelState.IsValid)
        {
            PackagingDTO? newPackagingDTO = await _packagingControlService.CreateAsync(_mapper.Map<PackagingDTO>(packaging));
            if (newPackagingDTO != null)
            {
                return StatusCode(StatusCodes.Status201Created, packaging);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(PackagingViewModel packaging)
    {
        if (ModelState.IsValid)
        {
            PackagingDTO? updatePackagingDTO = await _packagingControlService.UpdateAsync(_mapper.Map<PackagingDTO>(packaging));
            if (updatePackagingDTO != null)
            {
                return StatusCode(StatusCodes.Status200OK, packaging);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        if (await _packagingControlService.Remove(id))
        {
            return NoContent();
        }
        return BadRequest("Remove Exeption!");
    }
}
