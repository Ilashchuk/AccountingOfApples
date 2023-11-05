using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AreaAppleVariety
    {
        public Guid Id { get; set; }
        public Guid AreaId { get; set; }
        public Guid AppleVarietyId { get; set; }
        public Area? Area { get; set; }
        public AppleVariety? AppleVariety { get; set; }
    }
}
