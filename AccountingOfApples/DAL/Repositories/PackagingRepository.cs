using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class PackagingRepository : Repository<Packaging>, IPackagingRepository
{
    public PackagingRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
