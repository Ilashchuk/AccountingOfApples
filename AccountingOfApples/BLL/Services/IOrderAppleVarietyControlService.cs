using BLL.DTO;

namespace BLL.Services;

public interface IOrderAppleVarietyControlService : IControlService<OrderAppleVarietyDTO>
{
    Task<IEnumerable<OrderAppleVarietyDTO>> GetAllByOrderIdAsync(Guid clientId);


}
