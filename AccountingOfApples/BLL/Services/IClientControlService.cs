using BLL.DTO;

namespace BLL.Services;

public interface IClientControlService
{
    Task<IEnumerable<ClientDTO>> GetClientsAsync();

    Task<ClientDTO> GetClientByIdAsync(Guid id);

    Task<ClientDTO?> CreateClientAsync(ClientDTO client);

    Task<ClientDTO?> UpdateClientAsync(ClientDTO client);

    Task<bool> Remove(Guid id);
}
