using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class Area
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Square { get; set; }
        public Guid OwnerId { get; set; }
        public ICollection<OrderAppleVariety> OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();
        public Owner? Owner { get; set; }
        public ICollection<AreaAppleVariety> AreaAppleVarieties { get; set; } = new List<AreaAppleVariety>();
    }
}
