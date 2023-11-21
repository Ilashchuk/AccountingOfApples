using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.Services;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers;

[Route("[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientControlService _clientControlService;
    private readonly IMapper _mapper;

    public ClientController(IClientControlService clientControlService, IMapper mapper)
    {
        _clientControlService = clientControlService;
        _mapper = mapper;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetGlients()
    {
        return Ok(_mapper.Map<List<ClientViewModel>>(await _clientControlService.GetAllAsync()));
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetClientById(Guid id)
    {
        return Ok(_mapper.Map<ClientViewModel>(await _clientControlService.GetByIdAsync(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> CreateClient(ClientViewModel client)
    {
        if (ModelState.IsValid)
        {
            ClientDTO? newClientDTO = await _clientControlService.CreateAsync(_mapper.Map<ClientDTO>(client));
            if (newClientDTO != null)
            {
                return StatusCode(StatusCodes.Status201Created, client);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(ClientViewModel client)
    {
        if (ModelState.IsValid)
        {
            ClientDTO? updateClientDTO = await _clientControlService.UpdateAsync(_mapper.Map<ClientDTO>(client));
            if (updateClientDTO != null)
            {
                return StatusCode(StatusCodes.Status200OK, client);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        if (await _clientControlService.Remove(id))
        {
            return NoContent();
        }
        return BadRequest("Remove Exeption!");
    }
}