using AutoMapper;
using BLL.DTO;
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

    public async Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ClientDTO>>(await _unitOfWork.Clients.GetAllAsync());
    }

    public async Task<ClientDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ClientDTO>(await _unitOfWork.Clients.GetByIdAsync(id));
    }

    public async Task<ClientDTO?> CreateAsync(ClientDTO client)
    {
        await _unitOfWork.Clients.AddAsync(_mapper.Map<Client>(client));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return client;
    }

    public async Task<ClientDTO?> UpdateAsync(ClientDTO clientDTO)
    {
        Client? client = await _unitOfWork.Clients.GetByIdAsync(clientDTO.Id);
        if (client != null)
        {
            client = _mapper.Map<Client>(clientDTO);
            _unitOfWork.Clients.Update(client);
            _unitOfWork.Complete();
            return clientDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        Client? client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client != null)
        {
            _unitOfWork.Clients.Remove(client);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
