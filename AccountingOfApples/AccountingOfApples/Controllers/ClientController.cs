using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.Services;
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
        return Ok(_mapper.Map<List<ClientViewModel>>(await _clientControlService.GetClientsAsync()));
    }

    [HttpGet("client/{id}")]
    public async Task<IActionResult> GetClientById(Guid id)
    {
        return Ok(_mapper.Map<ClientViewModel>(await _clientControlService.GetClientByIdAsync(id)));
    }
}
