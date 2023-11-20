using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class OrderAppleVarietyRepository : Repository<OrderAppleVariety>, IOrderAppleVarietyRepository
{
    public OrderAppleVarietyRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
