using DAL.Models;

namespace BLL.Services;

public interface IClientControlService
{
    Task<IEnumerable<ClientDTO>> GetClientsAsync();

    Task<ClientDTO> GetClientByIdAsync(Guid id);
}
