using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AreaAppleVarietyRepository : Repository<AreaAppleVariety>, IAreaAppleVarietyRepository
    {
        public AreaAppleVarietyRepository(AccountOfApplesContext context)
            : base(context)
        {
        }
    }
}
