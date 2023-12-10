using DAL.Models;

namespace DAL.Repositories;

public interface IOrderRepository : IRepository<Order>
{

    Task<IEnumerable<Order>> GetAllByClientIdAsync(Guid ClientId);
}
