using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IForJuiceRepository : IRepository<ForJuice>
    {
        IEnumerable<ForJuice> GetByOwner(Owner owner);
    }
}
