using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(AccountOfApplesContext context)
        : base(context)
    {
    }
}
