using DAL.Models;

namespace DAL.Repositories;

public interface IForJuiceRepository : IRepository<ForJuice>
{
    IEnumerable<ForJuice> GetByOwner(Owner owner);
}
