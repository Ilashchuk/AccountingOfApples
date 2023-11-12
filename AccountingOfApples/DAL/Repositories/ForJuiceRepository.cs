using DAL.Data;
using DAL.Migrations;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ForJuiceRepository : Repository<ForJuice>, IForJuiceRepository
    {
        public ForJuiceRepository(AccountOfApplesContext context)
            : base(context)
        { 
        }
        public IEnumerable<ForJuice> GetByOwner(Owner owner)
        {
            return dbContext.ForJuices.Include(x => x.Owner).Where(x => x.Owner == owner).ToList();
        }
    }
}
