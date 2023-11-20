using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
