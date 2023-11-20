using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class AreaRepository : Repository<Area>, IAreaRepository
{
    public AreaRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
