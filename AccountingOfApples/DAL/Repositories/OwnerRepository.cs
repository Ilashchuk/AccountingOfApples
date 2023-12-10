using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class OwnerRepository : Repository<Owner>, IOwnerRepository
{
    public OwnerRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
