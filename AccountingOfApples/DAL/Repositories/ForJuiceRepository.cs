using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ForJuiceRepository : Repository<ForJuice>, IForJuiceRepository
{
    public ForJuiceRepository(AccountOfApplesContext context)
        : base(context)
    { 
    }
    public IEnumerable<ForJuice> GetByOwner(Owner owner)
    {
        return _dbContext.ForJuices.Include(x => x.Owner).Where(x => x.Owner == owner).ToList();
    }
}
