using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class AppleVarietyRepository : Repository<AppleVariety>, IAppleVarietyRepository
{
    public AppleVarietyRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
