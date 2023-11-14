using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
        public ActionResult<List<ClientViewModel>> GetGlients()
        {
            return Ok(_mapper.Map<List<ClientViewModel>>(_clientControlService.GetClients()));
        }
    }
}
