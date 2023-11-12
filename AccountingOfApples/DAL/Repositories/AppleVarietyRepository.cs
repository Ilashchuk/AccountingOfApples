using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AppleVarietyRepository : Repository<AppleVariety>, IAppleVarietyRepository
    {
        public AppleVarietyRepository(AccountOfApplesContext context)
            : base(context)
        {
        }
    }
}
