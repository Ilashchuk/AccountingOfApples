using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AccountOfApplesContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _dbContext.Orders
            .Include(a => a.Client)
            .Include(a => a.OrderAppleVarieties).ThenInclude(a => a.Packaging)
            .Include(a => a.OrderAppleVarieties).ThenInclude(a => a.Area)
            .Include(a => a.OrderAppleVarieties).ThenInclude(a => a.AppleVariety)
            .Include(a => a.OrderAppleVarieties).ThenInclude(a => a.Area)
            .Include(a => a.OrderAppleVarieties).ThenInclude(a => a.Area).ThenInclude(a => a.Owner)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetAllByClientIdAsync(Guid ClientId)
    {
        return await _dbContext.Orders
            .Where(o => o.ClientId == ClientId)
            .Include(a => a.Client)
            .Include(a => a.OrderAppleVarieties)
            .ToListAsync();
    }
}
