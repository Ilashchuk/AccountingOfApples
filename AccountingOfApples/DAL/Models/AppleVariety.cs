using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AppleVariety
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<OrderAppleVariety> OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();
        public ICollection<AreaAppleVariety> AreaAppleVarieties { get; set; } = new List<AreaAppleVariety>();
    }
}
