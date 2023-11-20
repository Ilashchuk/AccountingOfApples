using AutoMapper;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class ClientControlService : IClientControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDTO>> GetClientsAsync()
    {
        return _mapper.Map<IEnumerable<ClientDTO>>(await _unitOfWork.Clients.GetAllAsync());
    }

    public async Task<ClientDTO> GetClientByIdAsync(Guid id)
    {
        return _mapper.Map<ClientDTO>(await _unitOfWork.Clients.GetByIdAsync(id));
    }
}
