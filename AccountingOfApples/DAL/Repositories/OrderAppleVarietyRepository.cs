using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class OrderAppleVarietyRepository : Repository<OrderAppleVariety>, IOrderAppleVarietyRepository
{
    public OrderAppleVarietyRepository(AccountOfApplesContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<OrderAppleVariety>> GetAllAsync()
    {
        return await _dbContext.OrderAppleVarieties
            .Include(a => a.Order).Include(a => a.Area).ThenInclude(a => a.Owner)
            .Include(a => a.AppleVariety)
            .Include(a => a.Packaging)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderAppleVariety>> GetAllByOrderIdAsync(Guid OrderId)
    {
        return await _dbContext.OrderAppleVarieties
            .Where(o => o.OrderId == OrderId)
            .Include(a => a.Order)
            .Include(a => a.Area).ThenInclude(a => a.Owner)
            .Include(a => a.AppleVariety)
            .ToListAsync();
    }
}
