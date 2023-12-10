using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class AreaAppleVarietyRepository : Repository<AreaAppleVariety>, IAreaAppleVarietyRepository
{
    public AreaAppleVarietyRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
