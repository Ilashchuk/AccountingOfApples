using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class Order
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public Guid ClientId { get; set; }

        public Client? Client { get; set; }
        public ICollection<OrderAppleVariety> OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();
    }
}
