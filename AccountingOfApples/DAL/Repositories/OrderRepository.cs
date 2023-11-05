using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AccountOfApplesContext context)
            : base(context)
        {
        }

        public AccountOfApplesContext Context
        {
            get { return dbContext as AccountOfApplesContext; }
        }
    }
}
