using BLL.DTO;

namespace BLL.Services;

public interface IOrderControlService : IControlService<OrderDTO>
{

    Task<IEnumerable<OrderDTO>> GetAllByClientIdAsync(Guid clientId);
}
