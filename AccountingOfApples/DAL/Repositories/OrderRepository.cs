using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
