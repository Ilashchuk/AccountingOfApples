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
        return await _dbContext.Areas.Include(a => a.Owner).ToListAsync();
    }
}
