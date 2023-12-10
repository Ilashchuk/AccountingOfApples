using DAL.Models;

namespace DAL.Repositories;

public interface IOrderAppleVarietyRepository : IRepository<OrderAppleVariety>
{
    Task<IEnumerable<OrderAppleVariety>> GetAllByOrderIdAsync(Guid OrderId);
}
