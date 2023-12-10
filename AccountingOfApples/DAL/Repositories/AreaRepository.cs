using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class AreaRepository : Repository<Area>, IAreaRepository
{
    public AreaRepository(AccountOfApplesContext context)
        : base(context)
    { }

    public override async Task<IEnumerable<Area>> GetAllAsync()
    {
        var s = await _dbContext.Areas
            .Include(a => a.Owner)
            .Include(a => a.AreaAppleVarieties).ThenInclude(a => a.AppleVariety)
            .ToListAsync();
        
        return s;
    }

    public override async Task<Area?> GetByIdAsync(Guid id)
    {
        var s = await _dbContext.Areas
            .Include(a => a.Owner)
            .Include(a => a.AreaAppleVarieties).ThenInclude(a => a.AppleVariety)
            .FirstOrDefaultAsync(x => x.Id == id);
        return s;
    }
}
